using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Abstractions.Storage
{
    public interface IStorage
    {
        Task<FileDto> UploadAsync(IFormFileCollection files, string pathOrContainer);
        bool Delete(string fileName, string path);
        List<string> GetAllFiles(string pathOrContainer);
        bool IsFileExist(string pathOrContainer);
    }
}