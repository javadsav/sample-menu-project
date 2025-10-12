using application.Interfaces;
using application.services.category.Dtos;
using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.services.category
{
    public interface ICategoryService 
    {

        public List<Category> GetCategories();
        public Category GetCategoriesByid(int id);
        public Category AddCategory(addcategoryDto AddcategoryDto);
        public Category UpdatateCategory(int id,updatecategoryDto UpdatateCategoryDto);

    }
    public class CategoryService : ICategoryService
    {
        private readonly IMenuDbContext _menuDbContext;

        public CategoryService(IMenuDbContext menuDbContext)
        {
            _menuDbContext = menuDbContext;
        }
        public List<Category> GetCategories()
        {
            var getcategory = _menuDbContext.Categories.ToList();
            return getcategory;

        }
        public Category GetCategoriesByid(int id) 
        {
            var category = _menuDbContext.Categories.Find(id);
            if (category == null) 
            {
                return null;
            }
            return category;
        }
        public Category AddCategory(addcategoryDto AddcategoryDto) 
        {
            var newcategory = new Category()
            {
                Id = AddcategoryDto.Id,
                Name = AddcategoryDto.Name,
            };
            _menuDbContext.Categories.Add(newcategory);
            _menuDbContext.SaveChanges();
            return newcategory;
            
        }
        public Category UpdatateCategory(int id,updatecategoryDto UpdatateCategoryDto) 
        {
            var upcategory = _menuDbContext.Categories.Find(id);
            if (upcategory == null) 
            {
                return null;
            }

            upcategory.Name = UpdatateCategoryDto.Name;
            upcategory.Id = UpdatateCategoryDto.Id;
                
            _menuDbContext.SaveChanges();
            return upcategory;

        }
        public Category deleteCategory(int id) 
        {
            var delcategory = _menuDbContext.Categories.Find(id);
            if(delcategory == null) 
            {
                return null;
            }
            _menuDbContext.Categories.Remove(delcategory);
            _menuDbContext.SaveChanges();
            return delcategory;
        }


    }
    
}
