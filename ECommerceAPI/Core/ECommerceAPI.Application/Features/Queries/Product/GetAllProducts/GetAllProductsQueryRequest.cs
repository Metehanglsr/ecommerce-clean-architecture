using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Product.GetAllProducts
{
    public sealed class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
    }
}
