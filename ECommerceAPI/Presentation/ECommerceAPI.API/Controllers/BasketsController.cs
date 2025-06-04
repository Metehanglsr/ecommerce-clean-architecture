using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //public IActionResult GetBasketItems(GetBasketItemsQueryRequest getBasketItemsQueryRequest)
        //{

        //}

        //[HttpPost]
        //public IActionResult AddItemToBasket(AddItemToBasketCommandRequest addItemToBasketCommandRequest)
        //{

        //}

        //[HttpPut]
        //public IActionResult UpdateQuantity(UpdateQuantityCommandRequest updateQuantityCommandRequest)
        //{

        //}

        //[HttpDelete("{BasketItemId}")]
        //public IActionResult RemoveBasketItem(RemoveBasketItemCommandRequest removeBasketItemCommandRequest)
        //{

        //}
    }
}
