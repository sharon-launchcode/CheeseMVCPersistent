using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
    {
        public DbSet<Cheese> Cheeses { get; set; }
        //allow us to reference Cheeses objects

        public DbSet<CheeseCategory> Categories { get; set; }
        //alllow us to reference Categories objects

        public DbSet<Menu> Menus { get; set; }
        public DbSet<CheeseMenu> CheeseMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheeseMenu>()
                .HasKey(c => new { c.CheeseID, c.MenuID });
        }

        public CheeseDbContext(DbContextOptions<CheeseDbContext> options) 
            : base(options)
        { }

    }
}
