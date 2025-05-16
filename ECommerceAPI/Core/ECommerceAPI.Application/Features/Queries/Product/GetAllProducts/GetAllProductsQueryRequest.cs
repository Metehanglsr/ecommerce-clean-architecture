using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.RequestParameters;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Product.GetAllProducts
{
    public sealed class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
