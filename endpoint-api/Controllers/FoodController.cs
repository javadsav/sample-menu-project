using application.services.food;
using application.services.food.Dtos;
using domain.entities;
using Microsoft.AspNetCore.Mvc;

namespace endpoint_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        [HttpGet]
        public IActionResult GettAllFood() 
        {
            return Ok(_foodService.GetFoods());
        }
        [HttpGet("{id}")]
        public IActionResult GetFoodByid(int id)
        {
            var food = _foodService.GetFoodsByid(id);
            if (food == null) 
            {
                return NotFound();
            }
            return Ok(food);
        }
        [HttpPost]
        public IActionResult AddFood(addfooddto Addfooddto)
        {
            var food = _foodService.AddFood(Addfooddto);
            return Ok(food);
        }
        [HttpPut("{id}")]
        public IActionResult Updatefood(int id, updatefoodDto UpdatefoodDto)
        {
            var upfood = _foodService.Updatefood(id, UpdatefoodDto); 
            return Ok(upfood);
        }
        [HttpDelete]
        public IActionResult Deletefood(int id) 
        {
            var deletFood = _foodService.Deletefood(id);
            return Ok(deletFood);
        }


    }
}
