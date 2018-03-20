using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            this.context = dbContext;
        }
        public IActionResult Index()

        {

          List<CheeseCategory> Categories = context.Categories.ToList();

            return View(Categories);

        }




        //From Paticks notes  IMPORTANT ONLY FOR SINGLE LINERS
        //[HttpGet]
        //public IActionResult Index() => View(context.Categories.ToList());
        //{
        //View(context.Categories.ToList());
        //return View();
        // }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new AddCategoryViewModel());
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (!ModelState.IsValid)
            return View("Add");

            context.Categories.Add(new CheeseCategory
            {
                Name = addCategoryViewModel.Name
            });
            context.SaveChanges();
            return Redirect("/Category");
        }

    }
}