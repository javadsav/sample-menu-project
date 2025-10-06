using application.services.food;
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
        public IActionResult AddFood()
        {
            var food = new Food();
            return Ok(food);
        }
    }
}
