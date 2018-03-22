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

        //Get controller 
       public IActionResult Index()
       {
            List<Menu> menus = context.Menus.ToList();
            return View(menus);
       }
        /*
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
        */
        public IActionResult Add()

        {
            AddMenuViewModel addMenuViewModel= new AddMenuViewModel();
            return View(menus);
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

        [HttpGet]
        public IActionResult ViewMenu(int id)
        {

            Menu menu = context.Menus.Single(m => m.ID == id);
            List<CheeseMenu> items = context
                .CheeseMenus
                .Include(item => item.Cheese)
                .Where(cm => cm.MenuID == id)
                .ToList();

            ViewMenuViewModel viewMenuViewModel = new ViewMenuViewModel()
            //use the items and the menu object found above
            //to build a ViewMenuViewModel and passit into the view
            {
                Menu = menu,
                Items = items
            };

            return View(viewMenuViewModel);

        }
        [HttpGet]
        public IActionResult AddItem(int id)
        {
            Menu menu = context.Menus.Single(m => m.ID == id);
        }
        return View(new AddMenuItemViewModel, menu);

        public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
            //instructions AddItem create an instance of AddMenuItemViewModel
        {
            //with the given model object
            if (ModelState.IsValid)
            {
                var cheeseID = addMenuItemViewModel.cheeseID;
                var menuID = addMenuItemViewModel.menuID;
                //as well as all the list of Cheese Items from the database
                IList<CheeseMenu> cheesyItems = context.CheeseMenus


            }
        }

    }
}