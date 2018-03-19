using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Cheese> Cheeses { get; set; }
       //After we set up the Cheese class to work with CheeseCategory
       //objects, this list will represent the list of all items in a category


    }   
}
