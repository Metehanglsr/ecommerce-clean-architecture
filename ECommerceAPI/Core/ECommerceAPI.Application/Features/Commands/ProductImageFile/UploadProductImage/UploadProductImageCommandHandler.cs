using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.Repositories;
using MediatR;
using P = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public sealed class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest,UploadProductImageCommandResponse>
    {
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IStorageService _storageService;

        public UploadProductImageCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository, IStorageService storageService)
        {
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _storageService = storageService;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Files == null || request.Files.Count == 0)
                return new() { Message = "No File Found" };

            FileDto result = await _storageService.UploadAsync(request.Files, request.UploadPath);
            List<P.ProductImageFile> productImageFiles = result.Files.Select(file => new P.ProductImageFile
            {
                Name = file.uniquePath,
                Path = request.Path,
                Storage = _storageService.StorageName
            }).ToList();
            if (result.Files.Count == 0)
                return new() { Message = "File upload failed because none of the files had an allowed extension." };
            await _productImageFileWriteRepository.AddRangeAsync(productImageFiles);
            await _productImageFileWriteRepository.SaveAsync();
            return new() { Message = result.Message };
        }
    }
}