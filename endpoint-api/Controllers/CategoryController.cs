using application.services.category;
using application.services.category.Dtos;
using application.services.food;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace endpoint_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult GetAllcategories() 
        { 
            return Ok(_categoryService.GetCategories());
        }
        [HttpGet("{id}")]
        public IActionResult GetCategoryByid(int id) 
        { 
            var getcategorybyid = _categoryService.GetCategoriesByid(id);
            if (getcategorybyid == null) 
            {
                return NotFound();
            }
            return Ok(getcategorybyid);
        }
        [HttpPost]
        public IActionResult AddCategory(addcategoryDto AddcategoryDto)
        {
            var addcategory = _categoryService.AddCategory(AddcategoryDto);
            return Ok(addcategory); 
        }

        [HttpPut("{id}")]
        public IActionResult updatateCategory(int id,updatecategoryDto UpdatecategoryDto) 
        {
            var upcategory = _categoryService.UpdatateCategory(id,UpdatecategoryDto);
            return Ok(upcategory);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var delcategory = _categoryService.deleteCategory(id);  
            return Ok(delcategory);
        }

        }
    
    }
    

