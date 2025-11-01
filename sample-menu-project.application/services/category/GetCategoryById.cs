using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sample_menu_project.domain.entites;

namespace sample_menu_project.application.services.category
{
    public class GetCategoryById
    {
        public void getCategory()
        {
            Category category = new Category()
            {
                Id = 1,
                Name = "Test",
            };
        }
    }
}
