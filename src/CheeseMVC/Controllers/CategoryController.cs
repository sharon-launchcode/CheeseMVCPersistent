using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        //From Paticks notes
        [HttpGet]
        public IActionResult Index() => View(context.Categories.ToList());
        //{
            //View(context.Categories.ToList());
            //return View();
       // }
    }
}