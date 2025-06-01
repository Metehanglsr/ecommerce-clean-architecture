using ECommerceAPI.Application.Features.Queries.Customer.GetByIdCustomer;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        readonly IMediator _mediator;
        readonly IUnitOfWork _unitOfWork;

        public CustomersController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            await _unitOfWork.WriteRepository<Category>().AddAsync(new()
            {
                Name = "Phone",
                Description = "Phone123"
            });
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var category = _unitOfWork.ReadRepository<Category>().GetAll(false).FirstOrDefault();
            await _unitOfWork.WriteRepository<Product>().AddAsync(new()
            {
                Name = "Samsung",
                Price = 12,
                Stock = 2531,
                CategoryId = category!.Id
            });
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var product = _unitOfWork.ReadRepository<Product>().GetAll(false).FirstOrDefault();
            return Ok(product);
        }
    }
}