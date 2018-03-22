﻿using System;
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
            List<Menu> menus = context.Menus.ToList();
            return View(menus);
       }

        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel= new AddMenuViewModel();
            return View(addMenuViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu();
         
                {
                    Name = addMenuViewModel.Name
                };
                context.Menus.Add(newMenu);
                context.SaveChanges();

                return Redirect("/Menu");
                //return Redirect("/Menu/ViewMenu/" + newMenu.ID);
            }
            return View(addMenuViewModel);
        }

        [HttpGet]
        public IActionResult ViewMenu(int id)
        { 
            // From video Lesson 13 11:52 of 27:20 recall we dont want to retrieve a list of Cheeses 
            //we want to retrieve of Cheese Menus because
            //the CheeseMenu objects are what describe
            //the relationship between the Cheese Class and the Menu Class
            List<CheeseMenu> items = context
                .CheeseMenus
                .Include(item => item.Cheese)
                .Where(cm => cm.MenuID == id)
                .ToList();
            Menu menu = context.Menus.Single(m => m.ID == id);

            ViewMenuViewModel viewModel = new ViewMenuViewModel()
            //use the items and the menu object found above
            //to build a ViewMenuViewModel and passit into the view
            {
                Menu = menu,
                Items = items
            };

            return View(viewModel);

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