using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DBLab2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Season> Seasons { get; set; }

    }
}