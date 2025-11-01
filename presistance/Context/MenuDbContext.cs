using application.Interfaces;
using domain.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace presistance.Context
{
    public class MenuDbContext : DbContext , IMenuDbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options)
        {

        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders {  get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
