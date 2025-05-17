using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Services;
using MediatR;

namespace ECommerceAPI.Application.Features.Queries.ProductImageFile.GetAllProductImages
{
    public class GetAllProductImageQueryHandler : IRequestHandler<GetAllProductImageQueryRequest, GetAllProductImageQueryResponse>
    {
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IFileService _fileService;

        public GetAllProductImageQueryHandler(IProductImageFileReadRepository productImageFileReadRepository, IFileService fileService)
        {
            _productImageFileReadRepository = productImageFileReadRepository;
            _fileService = fileService;
        }

        public async Task<GetAllProductImageQueryResponse> Handle(GetAllProductImageQueryRequest request, CancellationToken cancellationToken)
        {
            var productImageFileNameList = _productImageFileReadRepository
                .GetAll(false)
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToList();
            FileContentDto fileContent = await _fileService.GetFileByNameRangeAsync(productImageFileNameList) ?? new();
            GetAllProductImageQueryResponse response = new()
            {
                FileContent = fileContent
            };
            return response;
        }
    }
}