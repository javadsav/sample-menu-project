using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presistance.Context
{
    
    
        public class MenuDbContextFactory : IDesignTimeDbContextFactory<MenuDbContext>
        {
            public MenuDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<MenuDbContext>();

                // ⚠️ این connection string رو با مال خودت جایگزین کن
                optionsBuilder.UseSqlServer("Server=.;Database=MenuDb;Trusted_Connection=True;TrustServerCertificate=True;");

                return new MenuDbContext(optionsBuilder.Options);
            }
        }
    }

