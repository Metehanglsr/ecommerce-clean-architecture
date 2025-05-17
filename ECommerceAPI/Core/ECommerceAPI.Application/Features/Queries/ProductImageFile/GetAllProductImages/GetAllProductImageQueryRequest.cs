using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetAllProductImages
{
    public sealed class GetAllProductImageQueryRequest : IRequest<GetAllProductImageQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}