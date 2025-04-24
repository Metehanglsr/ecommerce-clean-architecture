using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Persistence.Concretes
{
    internal class ProductService : IProductService
    {
        public List<Product> GetProducts() => new()
        {
            new()
            {
                Stock = 1,
                Price = 1
            },new()
            {
                Stock = 2,
                Price = 2
            },new()
            {
                Stock = 3,
                Price = 3
            }
        };
    }
}
