using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
           this.context = dbContext;
        }

        public IActionResult Index()
        {
            IList<CheeseMenu> Menus = context.CheeseMenus.ToList();
            return View("Views/Menu/Index.cshtml");
        }
         /*
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}