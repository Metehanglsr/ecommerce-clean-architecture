using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public sealed class UploadProductImageCommandRequest :IRequest<UploadProductImageCommandResponse>
    {
        public IFormFileCollection Files { get; set; } = default!;
        public string Path { get; set; } = string.Empty;
        public string UploadPath { get; set; } = string.Empty;
    }
}