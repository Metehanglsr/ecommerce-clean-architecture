using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.DTOs;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetByIdProductImages
{
    public sealed class GetByIdProductImagesQueryResponse
    {
        public FileContentDto FileContent { get; set; } = default!;
    }
}