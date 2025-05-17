using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetByIdProductImages
{
    internal class GetByIdProductImagesQueryHandler : IRequestHandler<GetByIdProductImagesQueryRequest, GetByIdProductImagesQueryResponse>
    {
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IFileService _fileService;

        public GetByIdProductImagesQueryHandler(IProductImageFileReadRepository productImageFileReadRepository, IFileService fileService)
        {
            _productImageFileReadRepository = productImageFileReadRepository;
            _fileService = fileService;
        }

        public async Task<GetByIdProductImagesQueryResponse> Handle(GetByIdProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            var productImageFile = await _productImageFileReadRepository
                                                            .GetByIdAsync(request.Id, false);
            if (productImageFile == null)
            {
                return new GetByIdProductImagesQueryResponse();
            }
            FileContentDto fileContent =  await _fileService.GetFileByNameAsync(productImageFile.Name, productImageFile.Path);
            return new()
            {
                FileContent = fileContent
            };
        }
    }
}
