using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services.order.Dtos
{
    public class OrderDto
    {
        public int TableNumber { get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
