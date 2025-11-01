using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TableNumber {  get; set; }
        public DateTime DateTime { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> Details { get; set; }

    }
}
