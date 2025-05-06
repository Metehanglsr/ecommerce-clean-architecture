using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Repositories;
using P = ECommerceAPI.Domain.Entities;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Product.GetAllProducts
{
    public sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetAllProductsQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var productList = _productReadRepository.GetAll(false).Select(p => new P.Product
            {
                Id = p.Id,
                Name = p.Name,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                Price = p.Price,
                Stock = p.Stock,
            }).ToList();
            GetAllProductsQueryResponse response = new()
            {
                products = productList
            };
            return Task.FromResult(response);
        }
    }
}
