using application.services.orderDetail.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services.order.Dtos
{
    public class OrderWithDetailDto
    {
        public AddOrderDto addOrderDto { get; set; }
        public List<AddOrderdetailDto> addOrders { get; set; }
    }
}
