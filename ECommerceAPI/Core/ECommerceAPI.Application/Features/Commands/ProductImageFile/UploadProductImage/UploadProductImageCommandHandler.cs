using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Services;
using MediatR;
using P = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public sealed class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest,UploadProductImageCommandResponse>
    {
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IFileService _fileService;

        public UploadProductImageCommandHandler(IProductImageFileWriteRepository productImageFileWriteRepository, IFileService fileService)
        {
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _fileService = fileService;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Files == null || request.Files.Count == 0)
                return new() { Message = "No File Found" };

            FileDto result = await _fileService.UploadAsync(request.Files, request.UploadPath);
            List<P.ProductImageFile> productImageFiles = result.Files.Select(file => new P.ProductImageFile
            {
                Name = file.uniquePath,
                Path = request.Path,
            }).ToList();
            if (result.Files.Count == 0)
                return new() { Message = "File upload failed because none of the files had an allowed extension." };
            await _productImageFileWriteRepository.AddRangeAsync(productImageFiles);
            await _productImageFileWriteRepository.SaveAsync();
            return new() { Message = result.Message };
        }
    }
}