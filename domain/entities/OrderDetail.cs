using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int FoodId {  get; set; }
        public Food Food { get; set; }
        public int Count {  get; set; }
        public Decimal Price {  get; set; }
        public string Description {  get; set; }
        public Order Order { get; set; }

    }
}
