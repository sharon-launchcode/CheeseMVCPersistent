using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
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
        [HttpGet]
        public IActionResult Add()
        {
            return View(new ViewModels.AddMenuViewModel());
        }
        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (!ModelState.IsValid)
                return View("Add");
            Menu newMenu = new Menu();
            context.Menus.Add(new Menu
            {
                Name = addMenuViewModel.Name
            });
            context.SaveChanges();
            return Redirect("/Menu/ViewMenu/" + newMenu.ID);
        }
        /*
         * 
       public IActionResult Index()
       {
           return View();
       }
       */
    }
}