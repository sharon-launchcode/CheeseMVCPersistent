using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<CheeseMenu> CheeseMenus { get; set; } = new List<CheeseMenu>();
        //from video its not a list of cheeses it is a bunch of RELATIONSHIPS to cheeses

    }
}
