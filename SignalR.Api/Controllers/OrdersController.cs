using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BussinessLayer.Abstract;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }

        [HttpGet("AktiveOrderCount")]
        public IActionResult AktiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }

        [HttpGet("TotalTodayPrice")]
        public IActionResult TotalTodayPrice()
        {
            return Ok(_orderService.TTotalTodayPrice());
        }

        [HttpGet("LastOrderPriceCount")]
        public IActionResult LastOrderPriceCount()
        {
            return Ok(_orderService.TLastOrderPriceCount());
        }
    }
}
