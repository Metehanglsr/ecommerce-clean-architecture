using ECommerceAPI.Application.Features.Commands.Product.CreateProduct;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryRequest request)
        {
            GetAllProductsQueryResponse response = await _mediator.Send(request);
            return Ok(response.products);
        }

        [HttpGet("Hello")]
        public IActionResult SayHello()
        {
            return Ok("hello");
        }
        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct(CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
