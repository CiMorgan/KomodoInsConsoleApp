using C1_CafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_CafeRepo
{
    public class MenuRepo
    {
        private List<Menu> _listOfMeals = new List<Menu>();

        //Create
        public void AddMealToList(Menu menu)
        {
            _listOfMeals.Add(menu);
        }
        //Read
        public List<Menu> ReadMealList()
        {
            return _listOfMeals;
        }
        //Update
        public bool UpdateExistingMeal(int originalMealNumber, Menu newMeal)
        {
            Menu oldMeal = GetMealByNumber(originalMealNumber);
            if (oldMeal != null)
            {
                oldMeal.ItemNumber = newMeal.ItemNumber;
                oldMeal.ItemName = newMeal.ItemName;
                oldMeal.Description = newMeal.Description;
                oldMeal.Ingredients = newMeal.Ingredients;
                oldMeal.Price = newMeal.Price;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool DeleteExistingMeal(int delMealNumber)
        {
            Menu meal = GetMealByNumber(delMealNumber);
            if (meal == null)
            {
                return false;
            }
            int initialCount = _listOfMeals.Count;
            _listOfMeals.Remove(meal);
            if (initialCount > _listOfMeals.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper
        public Menu GetMealByName(string itemName)
        {
            foreach(Menu meal in _listOfMeals)
            {
                if (meal.ItemName == itemName) 
                {
                    return meal;
                }
            }
            return null;
        }
        public Menu GetMealByNumber(int itemNumber)
        {
            foreach (Menu meal in _listOfMeals)
            {
                if (meal.ItemNumber == itemNumber)
                {
                    return meal;
                }
            }
            return null;
        }
    }
}
