using application.Interfaces;
using application.services.food.Dtos;
using application.services.order.Dtos;
using application.services.orderDetail.Dtos;
using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services.order
{
    public interface IOrderService
    {
        public List<OrderDto> GetOrders();
        public OrderDto GetOrderById(int id);
        public Order AddOrder(AddOrderDto addOrderDto);
       public int AddorderwithDetail(OrderWithDetailDto addOrderDetailDto);
        public Order UpdateOrder(int id, UpdateOrderDto updateOrderDto);
        public Order DeleteOrder(int id);
    }
    public class OrderService : IOrderService 
    {
        private readonly IMenuDbContext _menuDbContext;

        public OrderService(IMenuDbContext menuDbContext) 
        {
            _menuDbContext = menuDbContext;
        }
        public List<OrderDto> GetOrders() 
        {
            var orderlists = _menuDbContext.Orders.ToList();
            List<OrderDto> orderslist = new List<OrderDto>();
            foreach (var item in orderlists) 
            {
                var newlist = new OrderDto();
                newlist.TotalPrice =item.TotalPrice;
                newlist.TableNumber = item.TableNumber;
                newlist.DateTime = item.DateTime;

                orderslist.Add(newlist);
            }
            return orderslist;
           
        }
        public OrderDto GetOrderById(int id)
        {
            var getorderbyid = _menuDbContext.Orders.Find(id);
            var orderdto = new OrderDto();
            orderdto.TotalPrice = getorderbyid.TotalPrice;
            orderdto.TableNumber = getorderbyid.TableNumber;
            orderdto.DateTime = getorderbyid.DateTime;
            
            
            if(getorderbyid == null) 
            {
                return null;
            }
            return orderdto;
        }
        public Order AddOrder(AddOrderDto addOrderDto) 
        {
            var addorder = new Order()
            {
                Id = addOrderDto.Id,
                DateTime = addOrderDto.DateTime,
                TableNumber = addOrderDto.TableNumber,
                TotalPrice = addOrderDto.TotalPrice,
            };
            _menuDbContext.Orders.Add(addorder);
            _menuDbContext.SaveChanges();   
            return addorder;
        }
        public Order UpdateOrder(int id, UpdateOrderDto updateOrderDto)
        {
            var uporder = _menuDbContext.Orders.Find(id);
            if(uporder == null) 
            {
                return null;
            }
            //uporder.Id = updateOrderDto.Id;
            uporder.DateTime = updateOrderDto.DateTime;
            uporder.TableNumber = updateOrderDto.TableNumber;
            uporder.TotalPrice = updateOrderDto.TotalPrice;
            _menuDbContext.SaveChanges();
            return uporder;

        }
        public Order DeleteOrder(int id) 
        {
            var delorder = _menuDbContext.Orders.Find(id);
            _menuDbContext.Orders.Remove(delorder);
            _menuDbContext.SaveChanges();
            return delorder;
        }
        public int AddorderwithDetail(OrderWithDetailDto orderWithDetailDto)
        {
            Order myorder=new Order();
            myorder.TableNumber=orderWithDetailDto.addOrderDto.TableNumber;
            myorder.DateTime = orderWithDetailDto.addOrderDto.DateTime;
            myorder.Details = new List<OrderDetail>();
            foreach (var item in orderWithDetailDto.addOrders)
            {

                var newdetail = new OrderDetail()
                {
                    Count = item.Count,
                    Description = item.Description,
                    FoodId = item.FoodId,
                    OrderId = item.OrderId,
                    Price = item.Price,
                };
                myorder.Details.Add(newdetail);
                //myorder.TotalPrice += item.Price;
            }
          myorder.TotalPrice=  myorder.Details.Sum(item =>( item.Price)*item.Count);
            _menuDbContext.Orders.Add(myorder);
            _menuDbContext.SaveChanges();
            return myorder.Id;
        }
    }
}
