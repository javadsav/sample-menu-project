using application.Interfaces;
using application.services.orderDetail.Dtos;
using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services.orderDetail
{
    public interface IOrderDetailService 
    {
        public List<OrderDetailDto> GetAllOrderDetails();
        public OrderDetailDto GetOrderDetailByid(int id);
        public bool addorderdetail(List<AddOrderdetailDto> addOrderdetailDto);

    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IMenuDbContext _menuDbContext;

        public OrderDetailService(IMenuDbContext menuDbContext) 
        {
            _menuDbContext = menuDbContext;
        }
        public List<OrderDetailDto> GetAllOrderDetails()
        {
            var orderdetail = _menuDbContext.OrderDetails.ToList();
            List<OrderDetailDto> orderdetaillist = new List<OrderDetailDto>();

            foreach (var item in orderdetail)
            {
                var newlist = new OrderDetailDto
                {
                    Description = item.Description,
                    OrderId = item.OrderId,
                    FoodId = item.FoodId,
                    Price = item.Price,
                    Id = item.Id,
                    Count = item.Count
                };

                orderdetaillist.Add(newlist);
            }

            return orderdetaillist;
        }
        public OrderDetailDto GetOrderDetailByid(int id) 
        {
            var getorderdetailbyid = _menuDbContext.OrderDetails.Find();
            var orderdetaillist = new OrderDetailDto();
            orderdetaillist.Description = getorderdetailbyid.Description;
            orderdetaillist.OrderId = getorderdetailbyid.OrderId;
            orderdetaillist.FoodId = getorderdetailbyid.FoodId;
            orderdetaillist.Id = getorderdetailbyid.Id;
            orderdetaillist.Price = getorderdetailbyid.Price;
            orderdetaillist.Count = getorderdetailbyid.Count;
            
            if(getorderdetailbyid == null) 
            {
                return null;
            }
            return orderdetaillist;
        }
        public bool addorderdetail(List<AddOrderdetailDto>  addOrderdetailDto) 
        {
            foreach (var item in addOrderdetailDto) {
                var addorderdetail = new OrderDetail()
                {
                    OrderId = item.OrderId,
                    FoodId = item.FoodId,
                    Price = item.Price,
                    Count = item.Count,
                    Description = item.Description,
                };
                _menuDbContext.OrderDetails.Add(addorderdetail);

               }
            _menuDbContext.SaveChanges();
            return true;
            

        }
    }
}
