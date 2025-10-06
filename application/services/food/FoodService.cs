using application.Interfaces;
using application.services.food.Dtos;
using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services.food
{
    public interface IFoodService
    {
        public List<Food> GetFoods();
        public Food GetFoodsByid(int id);
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
            var foods = _menuDbContext.Foods.ToList();
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

            };
            _menuDbContext.Foods.Add(addfood);
            return addfood;


        }
        
    }
}
