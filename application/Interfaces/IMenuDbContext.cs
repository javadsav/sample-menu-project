using domain.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Interfaces
{
    public interface IMenuDbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }    
        public DbSet<OrderDetail> OrderDetails { get; set; }
     

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
