using application.Interfaces;
using application.services.food.Dtos;
using domain.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services.food
{
    public interface IFoodService
    {
        public Food AddFood(addfooddto addfooddto);
        public List<Food> GetFoods();
        public Food GetFoodsByid(int id);
        public Food Updatefood(int id, updatefoodDto updatefoodDto);
        public Food Deletefood(int id);
    }
    public class FoodService : IFoodService
    {
        private readonly IMenuDbContext _menuDbContext;

        public FoodService(IMenuDbContext menuDbContext)
        {
            _menuDbContext = menuDbContext;
        }
        public List<Food> GetFoods()
        {
            var foods = _menuDbContext.Foods
                .Include(x => x.Category).ToList();
            //List<addfooddto> addfoodlist = new List<addfooddto>();
            //foreach (var item in foods) 
            //{
            //    var newdto = new addfooddto();
            //    newdto.picture = item.picture;
            //    newdto.Name = item.Name;
            //    newdto.Description = item.Description;
            //    newdto.Price = item.Price;
            //   // newdto.CategoryName = item.CategoryName;
            //    newdto.CategoryId = item.CategoryId;


                

            //    addfoodlist.Add(newdto);
            //}
            return foods;
        }
        public Food GetFoodsByid(int id) 
        {
            var food = _menuDbContext.Foods.Find(id);
            if( food == null) 
            {
                return null;
            }
            return food;
        
        }
            public Food AddFood(addfooddto Addfooddto) 
            {
                var addfood = new Food()
                {
                    Name = Addfooddto.Name,
                    CategoryId = Addfooddto.CategoryId,
                    Price = Addfooddto.Price,
                    picture =Addfooddto.picture,
                    //CategoryName = Addfooddto.CategoryName,
                    vegeterian = Addfooddto.vegeterian,
                    Description = Addfooddto.Description,


                };
                _menuDbContext.Foods.Add(addfood);
            _menuDbContext.SaveChanges();
            
                return addfood;


        }

        public Food Updatefood(int id, updatefoodDto UpdatefoodDto)
        {
            var upfood = _menuDbContext.Foods.Find(id);
            if( upfood == null) 
            {
                return null;
            }
            upfood.Name = UpdatefoodDto.Name;
            upfood.picture  = UpdatefoodDto.picture;
            upfood.Description = UpdatefoodDto.Description;
            upfood.vegeterian = UpdatefoodDto.vegeterian;
           upfood.CategoryId = UpdatefoodDto.CategoryId;
            //upfood.CategoryName = UpdatefoodDto.CategoryName;
            _menuDbContext.SaveChanges();
            return upfood;

        }
        public Food Deletefood(int id) 
        {
            var deletefood = _menuDbContext.Foods.Find(id);
            if (deletefood == null) 
            {
                return null;
            }
            _menuDbContext.Foods.Remove(deletefood);
            _menuDbContext.SaveChanges();
            return deletefood;
        }
        
    }
}
