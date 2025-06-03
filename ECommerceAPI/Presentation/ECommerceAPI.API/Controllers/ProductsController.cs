using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Features.Commands.Category.Create;
using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProducts;
using ECommerceAPI.Application.Features.Queries.ProductImageFile.GetAllProductImages;
using ECommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IWebHostEnvironment _env;
        readonly string path = "resource-product-images";


        public ProductsController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.Errors?.Count > 0)
                return BadRequest(response.Errors);
            return Ok("Category succesfuly added");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryRequest request)
        {
            GetAllProductsQueryResponse response = await _mediator.Send(request);
            return Ok(response.products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            if (!Request.HasFormContentType)
                return BadRequest("No File Found");
            var files = Request.Form.Files;
            string uploadPath = Path.Combine(_env.WebRootPath, path);
            UploadProductImageCommandResponse response = await _mediator.Send(new UploadProductImageCommandRequest
            {
                Files = files,
                UploadPath = uploadPath,
                Path = path
            });
            return Ok(response.Message);
        }
        [HttpGet]
        public async Task<IActionResult> GetUploadedFiles([FromQuery] GetAllProductImageQueryRequest request)
        {
            GetAllProductImageQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}