using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.Services;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Infrastructure
{
    public sealed class FileService : IFileService
    {
        public async Task<FileContentDto> GetFileByNameAsync(string name, string path)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path, name);

            if (!System.IO.File.Exists(filePath))
                return null!;

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            var contentType = GetContentType(filePath);

            return new FileContentDto
            {
                Bytes = bytes,
                ContentType = contentType,
                FileName = name
            };
        }
        public async Task<FileContentDto?> GetFileByNameRangeAsync(List<ProductImageFile> files)
        {
            var memoryStream = new MemoryStream();
            using (var archive = new System.IO.Compression.ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                foreach (var file in files)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.Path, file.Name);
                    if (!System.IO.File.Exists(filePath))
                        continue;

                    var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                    var entry = archive.CreateEntry(file.Name, CompressionLevel.Fastest);
                    using var entryStream = entry.Open();
                    await entryStream.WriteAsync(fileBytes, 0, fileBytes.Length);
                }
            }
            return new FileContentDto
            {
                Bytes = memoryStream.ToArray(),
                ContentType = "application/zip",
                FileName = "files.zip"
            };
        }

        private string GetContentType(string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLowerInvariant();

            return ext switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".txt" => "text/plain",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };
        }

        public async Task<FileDto> UploadAsync(IFormFileCollection files,string filePath)
        {
            int successCount = 0;
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            List<(IFormFile,string)> addedFiles = new();
            string[] permittedExtensions = { ".jpg", ".jpeg", ".png", ".txt" };
            foreach (var file in files)
            {
                if (file.Length == 0)
                    continue;

                string ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!permittedExtensions.Contains(ext))
                    continue;

                string uniqueFileName = Guid.NewGuid() + ext;
                string fullPath = Path.Combine(filePath, uniqueFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                addedFiles.Add((file,uniqueFileName));
                successCount++;
            }
            if (addedFiles.Count == 0)
                return new()
                {
                    Message = "No files found"
                };
            FileDto fileDto = new()
            {
                Files = addedFiles,
                Message = $"{files.Count} files received. {successCount} uploaded successfully, {files.Count - successCount} failed.",
            };
            return fileDto;
        }
    }
}