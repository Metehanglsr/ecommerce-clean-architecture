using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetAllProductImages
{
    public sealed class GetAllProductImageQueryResponse
    {
        public FileContentDto FileContent { get; set; } = default!;
    }
}