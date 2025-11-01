using application.services.order;
using application.services.order.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace endpoint_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderService.GetOrders());
        }
        [HttpGet("{id}")]
        public IActionResult GetOrdersById(int id)
        {
            var ordersbyid = _orderService.GetOrderById(id);
            if (ordersbyid == null) 
            {
                return NotFound();

            }
            return Ok(ordersbyid);
        }
        [HttpPost]
        public IActionResult AddOrder(AddOrderDto addOrderDto) 
        {
            var addorder = _orderService.AddOrder(addOrderDto);
            return Ok(addorder);
        }
        [HttpPost("{id}")]
        public IActionResult AddOrderthDetail(OrderWithDetailDto orderWithDetailDto )
        {
            var addorder = _orderService.AddorderwithDetail(orderWithDetailDto);
            return Ok(addorder);
        }

        [HttpPut]
        public IActionResult Updateorder(int id,UpdateOrderDto updateOrderDto) 
        {
            var uporder = _orderService.UpdateOrder(id, updateOrderDto);
            return Ok(uporder);
        }
        [HttpDelete]
        public IActionResult DeleteOrder(int id) 
        {
            var delorder = _orderService.DeleteOrder(id);
            return Ok(delorder);
        }
    }
}
