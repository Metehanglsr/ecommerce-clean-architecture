using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.Repositories;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetAllProductImages
{
    public class GetAllProductImageQueryHandler : IRequestHandler<GetAllProductImageQueryRequest, GetAllProductImageQueryResponse>
    {
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IStorageService _storageService;

        public GetAllProductImageQueryHandler(IProductImageFileReadRepository productImageFileReadRepository, IStorageService storageService)
        {
            _productImageFileReadRepository = productImageFileReadRepository;
            _storageService = storageService;
        }

        public Task<GetAllProductImageQueryResponse> Handle(GetAllProductImageQueryRequest request, CancellationToken cancellationToken)
        {

            List<string> files =  _storageService.GetAllFiles("resource-product-images");
            GetAllProductImageQueryResponse response = new()
            {
                Files = files
            };
            return Task.FromResult(response);
        }
    }
}