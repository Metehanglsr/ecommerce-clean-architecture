using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories;
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

        public CustomersController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            IQueryable customerList = _customerReadRepository.GetAll();
            return Ok(customerList);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Customer> customers = new();
            Customer customer = new Customer
                {
                Name = "mete4",
                SurName = "han"
            };
            Customer customer2 = new Customer
            {
                Name = "mete5",
                SurName = "han"
            };
            customers.Add(customer);
            customers.Add(customer2);
            await _customerWriteRepository.AddRangeAsync(customers);
            await _customerWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
