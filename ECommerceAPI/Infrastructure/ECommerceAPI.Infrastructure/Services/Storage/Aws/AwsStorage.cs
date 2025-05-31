using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Abstractions.Storage.Aws;
using ECommerceAPI.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Infrastructure.Services.Storage.Aws
{
    internal class AwsStorage : IAwsStorage
    {
        public bool Delete(string fileName, string path)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllFiles(string pathOrContainer)
        {
            throw new NotImplementedException();
        }

        public bool IsFileExist(string pathOrContainer)
        {
            throw new NotImplementedException();
        }

        public Task<FileDto> UploadAsync(IFormFileCollection files, string pathOrContainer)
        {
            throw new NotImplementedException();
        }
    }
}
