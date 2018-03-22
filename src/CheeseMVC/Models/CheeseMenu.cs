using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
//from video this is the join class for cheese and menu
{
    public class CheeseMenu
    {
        public int MenuID { get; set; }
        public Menu Menu { get; set; }
        //Menu is the Navigation property, a reference to MenuID

        public int CheeseID { get; set; }
        public Cheese Cheese { get; set; }
        //Cheese is the Navigation property a reference to CheeseID
    }
}
