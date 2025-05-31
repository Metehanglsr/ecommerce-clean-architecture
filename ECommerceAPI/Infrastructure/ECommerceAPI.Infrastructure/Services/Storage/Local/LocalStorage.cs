using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Abstractions.Storage.Local;
using ECommerceAPI.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Infrastructure.Services.Storage.Local
{
    public sealed class LocalStorage : ILocalStorage
    {
        public bool Delete(string fileName, string path)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);
            var directory = new DirectoryInfo(fullPath);

            var file = directory.GetFiles().FirstOrDefault(f => f.Name == fileName);

            if (file == null)
                return false;

            file.Delete();
            return true;
        }

        public List<string> GetAllFiles(string path)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);
            DirectoryInfo directory = new(fullPath);
            return directory.Exists ? directory.GetFiles().Select(f => f.Name).ToList()
                : new List<string>();
        }

        public bool IsFileExist(string path)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);
            DirectoryInfo directory = new(fullPath);
            return directory.Exists && directory.GetFiles().Length > 0;
        }

        public async Task<FileDto> UploadAsync(IFormFileCollection files, string filePath)
        {
            int successCount = 0;
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            List<(IFormFile, string)> addedFiles = new();
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
                addedFiles.Add((file, uniqueFileName));
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
