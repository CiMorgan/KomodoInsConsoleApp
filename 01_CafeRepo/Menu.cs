using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_CafeRepo
{
    public class Menu
    {
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public double Price { get; set; }
        public Menu() { }
        public Menu(int itemNumber, string itemName, string description, List<string> ingredients, double price)
        {
            ItemNumber = itemNumber;
            ItemName = itemName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
