using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_CafeRepo
{
    public class Meal
    {
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }
        public Meal() { }
        public Meal(int itemNumber, string itemName, string description, List<string> ingredients, decimal price)
        {
            ItemNumber = itemNumber;
            ItemName = itemName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
