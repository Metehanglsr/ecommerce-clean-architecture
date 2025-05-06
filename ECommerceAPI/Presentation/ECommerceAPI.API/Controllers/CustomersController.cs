using ECommerceAPI.Application.Features.Queries.Customer.GetByIdCustomer;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        readonly IMediator _mediator;

        public CustomersController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, IMediator mediator)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _mediator = mediator;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            IQueryable customerList = _customerReadRepository.GetAll();
            return Ok(customerList);
        }
        [HttpGet]
        public async Task<IActionResult> Get(GetByIdCustomerQueryRequest getByIdCustomerQueryRequest)
        {
            GetByIdCustomerQueryResponse response = await _mediator.Send(getByIdCustomerQueryRequest);
            return Ok(response);
        }
    }
}