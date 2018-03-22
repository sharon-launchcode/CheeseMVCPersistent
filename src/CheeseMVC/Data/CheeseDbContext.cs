using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Data
{
    public class CheeseDbContext : DbContext
        //from video DbContext is what allows us to interact
        //with objects via the Data Layer Lesson 13 4:34 of 7:30
        //to get them out of and into the database and to manage
        //those relationships in the table side
        //
        //So simply putting these DbSets in a DbContext and declaring them
        //within our CheeseDbContext is going to allow us to access these collections
        //of objects via the datalayer database using the entifi framework
        //
        //we still need to set up the primary key associated within our 
        //new cheesemenu classes

    {
        public DbSet<Cheese> Cheeses { get; set; }
        //allow us to reference Cheeses objects

        public DbSet<CheeseCategory> Categories { get; set; }
        //alllow us to reference Categories objects

        public DbSet<Menu> Menus { get; set; }
        public DbSet<CheeseMenu> CheeseMenus { get; set; }

        public CheeseDbContext(DbContextOptions<CheeseDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheeseMenu>()
                .HasKey(c => new { c.CheeseID, c.MenuID });
        }



    }
}
