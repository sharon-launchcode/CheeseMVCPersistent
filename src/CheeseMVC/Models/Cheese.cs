namespace CheeseMVC.Models
{
    public class Cheese
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        //CategoryID a one-to-many relationship
        //The way to do this in a database is through a foreign key
        //a foreign key column as a way to store the identifier of the object
        //in a different table in a particlar row it is related to
        public CheeseCategory Category { get; set; }
        //Category is a navigation property within an entifty framework
        //Below from instructions
        //Allows entity framework to recognize CategoryID as the property
        //corresponding to the id of the Category when mapping classes
        //When we retrieve a Cheese object from the database
        //both the Category and CategoryID will be properly initialized
        //the value of the CateogryID will be the value of the ID property of Category
        //In other words, CategoryID is a foreign key property
    }
}
