using System.Collections.Generic;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CheeseCategory Category { get; set; }
        public int CategoryID { get; set; }

        public List<CheeseMenu> CheeseMenus { get; set; }
        //from video Lesson 13  at 4:04 of 7:30 we should think of this intermediary class
        //CheeseMenus as constituting a relationship between two classes
    }
}
