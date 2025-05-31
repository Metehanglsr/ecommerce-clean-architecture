using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Infrastructure.Services.Storage
{
    internal class StorageService : IStorageService
    {
        readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public bool Delete(string fileName, string path)
        {
            return _storage.Delete(fileName, path);
        }

        public List<string> GetAllFiles(string pathOrContainer)
        {
            return _storage.GetAllFiles(pathOrContainer);
        }

        public bool IsFileExist(string pathOrContainer)
        {
            return _storage.IsFileExist(pathOrContainer);
        }

        public Task<FileDto> UploadAsync(IFormFileCollection files, string pathOrContainer)
        {
            return _storage.UploadAsync(files, pathOrContainer);
        }
    }
}