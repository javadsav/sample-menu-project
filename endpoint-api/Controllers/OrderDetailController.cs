using application.services.orderDetail;
using application.services.orderDetail.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace endpoint_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService) 
        {
            _orderDetailService = orderDetailService;
        }
        [HttpGet]
        public IActionResult GetAllOrderDetail() 
        {
            var getallorddetail = _orderDetailService.GetAllOrderDetails();
            return Ok(getallorddetail);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrderDetailByid(int id) 
        {
            var orderdetailbyid = _orderDetailService.GetOrderDetailByid(id);
            if (orderdetailbyid == null) 
            {
                return NotFound();
            }
            return Ok(orderdetailbyid);
        }
        [HttpPost]
        public IActionResult AddorderDetail(List<AddOrderdetailDto> addOrderdetailDto) 
        {
            var addorderdetail = _orderDetailService.addorderdetail(addOrderdetailDto);
            return Ok(addorderdetail);
        }
    }
}
