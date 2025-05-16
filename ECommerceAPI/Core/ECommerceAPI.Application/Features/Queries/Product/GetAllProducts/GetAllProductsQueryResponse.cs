using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Queries.Product.GetAllProducts
{
    public sealed class GetAllProductsQueryResponse
    {
        public List<P.Product> products = new List<P.Product>();
    }
}