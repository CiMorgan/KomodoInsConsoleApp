using C1_CafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_CafeRepo
{
    public class MealRepo
    {
        private List<Meal> _listOfMeals = new List<Meal>();

        //Create
        public void AddMealToList(Meal menu)
        {
            _listOfMeals.Add(menu);
        }
        //Read
        public List<Meal> ReadMealList()
        {
            return _listOfMeals;
        }
        //Update
        public bool UpdateExistingMeal(int originalMealNumber, Meal newMeal)
        {
            Meal oldMeal = GetMealByNumber(originalMealNumber);
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
            Meal meal = GetMealByNumber(delMealNumber);
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
        public Meal GetMealByName(string itemName)
        {
            foreach(Meal meal in _listOfMeals)
            {
                if (meal.ItemName == itemName) 
                {
                    return meal;
                }
            }
            return null;
        }
        public Meal GetMealByNumber(int itemNumber)
        {
            foreach (Meal meal in _listOfMeals)
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
