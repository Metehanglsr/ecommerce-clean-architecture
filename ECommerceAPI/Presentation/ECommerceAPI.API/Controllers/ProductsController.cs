using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ECommerceAPI.Application.Features.Queries.Customer.GetByIdCustomer;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProducts;
using ECommerceAPI.Application.Features.Queries.ProductImageFile.GetAllProductImages;
using ECommerceAPI.Application.Features.Queries.ProductImageFile.GetByIdProductImages;
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

        public ProductsController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;

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
            string path = "resource-product-images";
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
            return File(response.FileContent.Bytes, response.FileContent.ContentType, response.FileContent.FileName);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUploadedFileById([FromRoute] GetByIdProductImagesQueryRequest request)
        {
            GetByIdProductImagesQueryResponse response = await _mediator.Send(request);
            return File(response.FileContent.Bytes, response.FileContent.ContentType, response.FileContent.FileName);
        }
    }
}