namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public CheeseType Type { get; set; }
        public CheeseCategory Category { get; set; }
        public int CategoryID { get; set; }
        //Allows entity framework to recognize CategoryID as the property
        //corresponding to the id of the Category when mapping classes
        public int ID { get; set; }
        //When we retrieve a Cheese object from the database
        //both the Category and CategoryID will be properly initialized
        //the value of the CateogryID will be the value of the ID property of Category
        //In other words, CategoryID is a foreign key property
    }
}
