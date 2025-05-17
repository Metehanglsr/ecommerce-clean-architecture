using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.DTOs
{
    public sealed class FileDto
    {
        public List<(IFormFile file,string uniquePath)> Files { get; set; } = default!;
        public string Message { get; set; } = string.Empty;
    }
}