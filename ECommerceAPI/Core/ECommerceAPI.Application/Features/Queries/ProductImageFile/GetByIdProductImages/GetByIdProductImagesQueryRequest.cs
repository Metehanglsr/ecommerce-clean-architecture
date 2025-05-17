using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetByIdProductImages
{
    public sealed class GetByIdProductImagesQueryRequest : IRequest<GetByIdProductImagesQueryResponse>
    {
        public string Id { get; set; } = string.Empty;
    }
}