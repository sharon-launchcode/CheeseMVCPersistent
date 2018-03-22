using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddMenuItemViewModel
    {
        public int cheeseID { get; set; }
        public int menuID { get; set; }

        public Menu Menu { get; set; }
        public List<SelectListItem> Cheeses{ get; set; }

        public AddMenuItemViewModel() { }

        public AddMenuItemViewModel (Menu menu, IEnumerable<Cheese> cheeses)
        {
            Menu = menu;
            //per instructions initialize Cheeses to an empty list
            Cheeses = new List<SelectListItem>();
            //copied from instructions
            Cheeses.Add(new SelectListItem
            {
                Value = cheese.ID.ToString(),
                Text = cheese.Name
            });
        //the lowercase cheese is underlined in red
        }

    }
}
