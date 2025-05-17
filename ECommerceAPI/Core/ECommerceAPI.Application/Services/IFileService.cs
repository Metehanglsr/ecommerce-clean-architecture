using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Services
{
    public interface IFileService
    {
        public Task<FileDto> UploadAsync(IFormFileCollection files, string filePath);
        public Task<FileContentDto> GetFileByNameAsync(string name, string path);
        public Task<FileContentDto?> GetFileByNameRangeAsync(List<ProductImageFile> files);
    }
}