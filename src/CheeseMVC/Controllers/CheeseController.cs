using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private readonly CheeseDbContext context;

        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //new line below from video instructions
            IList<Cheese> cheeses = context.Cheeses.Include(c => c.Category).ToList();
            //List<Cheese> cheeses = context.Cheeses.ToList();
            return View(cheeses);
            //return View();
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(context.Categories.ToList());
            // AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {


                CheeseCategory newCheeseCategory = context.Categories.Single(c => c.ID == addCheeseViewModel.CategoryID);
                
                // Add the new cheese to my existing cheeses
                Cheese newCheese = new Cheese

                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Category = newCheeseCategory
                };

                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }
        //below from video 11 minute time frame
        /*
        public IActionResult Category(int id)
        {
            if (id == 0)
            {
                return Redirect("/Category");
            }
            CheeseCategory theCategory = context.Categories
                .Include(cat => cat.Cheeses)
                .Single(cat =? cat.ID == ID);
        }

        ViewBag.title = "Cheeses in category:" + theCategoryName;
        return View("Index", theCategory.Cheeses);
        */
    }
}
