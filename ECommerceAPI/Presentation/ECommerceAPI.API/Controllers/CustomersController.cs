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
            var customer = await _customerReadRepository.GetByIdAsync("2adeb594-ac57-4a1f-bde8-95253ecb282b");
            if(customer!=null)
            {
                customer.Name = "metehan";
                _customerWriteRepository.Update(customer);
            }
            await _customerWriteRepository.AddAsync(new Customer
                {
                Name = "mete",
                SurName="han"
            });
            await _customerWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
