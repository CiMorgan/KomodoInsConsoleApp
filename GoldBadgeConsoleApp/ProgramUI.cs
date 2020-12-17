using C1_CafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1_CafeConsole
{
    class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();    
        public void Run()
        {
            EstablishedMealList();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options to cafe manager
                Console.WriteLine("Select a menu option:\n" +
                    "1. Display a list of all meals\n" +
                    "2. Display details of a meal\n" +
                    "3. Create a new meal\n" +
                    "4. Update an existing meal\n" +
                    "5. Delete a meal\n" +
                    "6. Exit\n");
                //Get user input
                string input = Console.ReadLine();
                //Evaluate user input and respond
                switch (input)
                {
                    case "1":
                        //Display list of meals including number, name, price
                        DisplayAllMeals();
                        break;
                    case "2":
                        //Display detail of a meal (number, name, description, ingredients, price)
                        DisplayMealInDetail();
                        break;
                    case "3":
                        //Create a new meal
                        AddMeal();
                        break;
                    case "4":
                        //Update an existing meal
                        UpdateMeal();
                        break;
                    case "5":
                        //Delete a meal
                        DeleteMeal();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
        //Display list of meals including number, name, price
        private void DisplayAllMeals()
        {
            List<Menu> listOfMeals = _menuRepo.ReadMealList();
            Console.WriteLine("\n");
            for (int j = 0; j <= listOfMeals.Count; j++)
            {
                Menu printMeal = _menuRepo.GetMealByNumber(j + 1);
                if (printMeal != null)
                {
                    Console.WriteLine($"#{printMeal.ItemNumber} - {printMeal.ItemName}    Price:  ${printMeal.Price}");
                }
            }
        }
        //Display detail of a meal (number, name, description, ingredients, price)
        private void DisplayMealInDetail()
        {
            List<Menu> listOfMeals = _menuRepo.ReadMealList();
            Console.Clear();
            Console.WriteLine("\n");
            for (int j = 0; j <= listOfMeals.Count; j++)
            {
                Menu printMeal = _menuRepo.GetMealByNumber(j + 1);
                if (printMeal != null)
                {
                    Console.WriteLine($"#{printMeal.ItemNumber} - {printMeal.ItemName}");
                }
            }
            Console.WriteLine("Enter the number of the meal that you would like to see in detail:");
            int mealDetail = int.Parse(Console.ReadLine());
            Menu getMeal = _menuRepo.GetMealByNumber(mealDetail);
            Console.WriteLine($"#{getMeal.ItemNumber} - {getMeal.ItemName}  Price ${getMeal.Price}\n" +
                $"{getMeal.Description}\n" +
                $"The {getMeal.ItemName} meal contains the following ingredients:\n");
            for (int i = 0; i < getMeal.Ingredients.Count; i++)
            {
                Console.WriteLine($"    {getMeal.Ingredients[i]}");
            }
        }
        //Create a new meal
        private void AddMeal()
        {
            List<Menu> listOfMeals = _menuRepo.ReadMealList();
            List<string> ingredList = new List<string>();
            int newNum = listOfMeals.Count + 1;
            for (int j = 0; j < listOfMeals.Count; j++)
            {
                Menu numCheck = _menuRepo.GetMealByNumber(j + 1);
                if (numCheck == null)
                {
                    newNum = j + 1;
                }
            }
            Console.WriteLine("Enter the name of the new meal.");
            string newName = Console.ReadLine();
            Console.WriteLine("Please enter a description for the new meal.");
            string newDescription = Console.ReadLine();
            Console.WriteLine("Please enter the price of the new meal.");
            double newPrice = double.Parse(Console.ReadLine());
            bool added = false;
            while (!added)
            {
                Console.WriteLine("\nEnter the ingredients for this meal.\n" +
                                  "Press return / enter between each ingredient\n" +
                                  "Enter 'Done' when complete\n");
                string addIngred = Console.ReadLine().ToLower();
                while (addIngred != "done")
                {
                    ingredList.Add(addIngred);
                    addIngred = Console.ReadLine().ToLower();
                }
                added = true;
            }
            Menu newMeal = new Menu(newNum, newName, newDescription, ingredList, newPrice);
            _menuRepo.AddMealToList(newMeal);
        }
        //Update an existing meal
        private void UpdateMeal()
        {
            Console.Clear();
            List<Menu> listOfMeals = _menuRepo.ReadMealList();
            DisplayAllMeals();
            Console.WriteLine("\nPlease enter the number of the meal you would like to update.\n");
            int updateNum = int.Parse(Console.ReadLine());
            Menu getMeal = _menuRepo.GetMealByNumber(updateNum);
            string updateName = getMeal.ItemName;
            string updateDescription = getMeal.Description;
            double updatePrice = getMeal.Price;
            List<string> updateIngred = new List<string>();
            updateIngred = getMeal.Ingredients;

            Console.WriteLine("Would you like to change the name?\n" +
                              "Enter yes or no\n");
            string nameUpdate = Console.ReadLine();
            bool newName = false;
            while (!newName)
            {
                if (nameUpdate == "yes")
                {
                    Console.WriteLine("What is the new name?");
                    updateName = Console.ReadLine();
                    newName = true;
                }
                else if (nameUpdate == "no")
                {
                    updateName = getMeal.ItemName;
                    newName = true;
                }
                else
                {
                    Console.WriteLine("Please enter either yes or no.\n");
                    nameUpdate = Console.ReadLine();
                    newName = false;
                }
            }
            Console.WriteLine("Would you like to change the description?\n" +
                              "Enter yes or no\n");
            string descUpdate = Console.ReadLine();
            bool newDesc = false;
            while (!newDesc)
            {
                if (descUpdate == "yes")
                {
                    Console.WriteLine("What is the new description");
                    updateDescription = Console.ReadLine();
                    newDesc = true;
                }
                else if (descUpdate == "no")
                {
                    updateDescription = getMeal.Description;
                    newDesc = true;
                }
                else
                {
                    Console.WriteLine("Please enter either yes or no.\n");
                    descUpdate = Console.ReadLine();
                    newDesc = false;
                }
            }
            Console.WriteLine("Would you like to change the price?\n" +
                              "Enter yes or no\n");
            string priceUpdate = Console.ReadLine();
            bool newPrice = false;
            while (!newPrice)
            {
                if (priceUpdate == "yes")
                {
                    Console.WriteLine("What is the new price?");
                    updatePrice = double.Parse(Console.ReadLine());
                    newPrice = true;
                }
                else if (priceUpdate == "no")
                {
                    updatePrice = getMeal.Price;
                    newPrice = true;
                }
                else
                {
                    Console.WriteLine("Please enter either yes or no.\n");
                    priceUpdate = Console.ReadLine();
                    newPrice = false;
                }
            }
            Console.WriteLine("Would you like to change the ingredients?\n" +
                  "Enter yes or no\n");
            string ingredUpdate = Console.ReadLine();
            bool newIngred = false;
            while (!newIngred)
            {
                if (ingredUpdate == "yes")
                {
                    updateIngred.Clear();
                    bool added = false;
                    while (!added)
                    {
                        Console.WriteLine("\nEnter the ingredients for this meal.\n" +
                                          "Press return / enter between each ingredient\n" +
                                          "Enter 'Done' when complete\n");
                        string addIngred = Console.ReadLine().ToLower();
                        while (addIngred != "done")
                        {
                            
                            updateIngred.Add(addIngred);
                            addIngred = Console.ReadLine().ToLower();
                        }
                        added = true;
                    }
                    newIngred = true;
                }
                else if (ingredUpdate == "no")
                {
                    updateIngred = getMeal.Ingredients;
                    newIngred = true;
                }
                else
                {
                    Console.WriteLine("Please enter either yes or no.\n");
                    ingredUpdate = Console.ReadLine();
                    newIngred = false;
                }
            }
            Menu updateMeal = new Menu(updateNum, updateName, updateDescription, updateIngred, updatePrice);
            _menuRepo.UpdateExistingMeal(updateNum, updateMeal);
        }
        //Delete a meal
        private void DeleteMeal()
        {
            Console.Clear();
            List<Menu> listOfMeals = _menuRepo.ReadMealList();
            DisplayAllMeals();
            Console.WriteLine("\nPlease enter the number of the meal you would like to delete.\n");
            int delNum = int.Parse(Console.ReadLine());
            bool delMeal = _menuRepo.DeleteExistingMeal(delNum);
            if (delMeal)
            {
                Console.WriteLine($"Meal #{delNum} was successfully deleted.\n");
            }
            else
            {
                Console.WriteLine($"Meal #{delNum} could not be deleted.\n");
            }
        }

        //Generate a starter menu using items and description from Metro Diner; ingredients are made up
        private void EstablishedMealList()
        {
            List<string> ingredList1 = new List<string>
            {
                "chicken",
                "hot sauce"
            };
            List<string> ingredList2 = new List<string>
            {
                "potatoes",
                "cheese",
                "bacon",
                "jalapenos"
            };
            List<string> ingredList3 = new List<string>
            {
                "onions",
                "bacon fat",
                "breading",
                "salt"
            };
            List<string> ingredList4 = new List<string>
            {
                "Angus beef",
                "bread",
                "lettuce",
                "tomatoe",
                "cheese",
                "pickle"
            };
            List<string> ingredList5 = new List<string>
            {
                "Roast beef",
                "bread",
                "Au jus",
                "cheese"
            };
            Menu meal1 = new Menu(1, "Wings", "Traditional hand-breaded wings tossed in your choice of Buffalo or Spicy Buffalo sauce with celery sticks and ranch or blue cheese for dipping", ingredList1, 10.99);
            Menu meal2 = new Menu(2, "Cheese Fries", "Crispy seasoned French fries topped with mixed cheeses, bacon, and fried jalapeños with ranch", ingredList2, 6.99);
            Menu meal3 = new Menu(3, "Onion Rings", "Thick cut, panko-breaded onion rings with ranch.", ingredList3, 6.49);
            Menu meal4 = new Menu(4, "All American Burger", "100% Angus burger, American cheese, tomato and lettuce slaw (shredded lettuce, chopped pickle and mayo).", ingredList4, 9.99);
            Menu meal5 = new Menu(5, "Philly Cheese Steak", "Roasted and seasoned beef topped with grilled onions and peppers, melted provel cheese on a toasted hoagie roll.", ingredList5, 11.49);

            _menuRepo.AddMealToList(meal1);
            _menuRepo.AddMealToList(meal2);
            _menuRepo.AddMealToList(meal3);
            _menuRepo.AddMealToList(meal4);
            _menuRepo.AddMealToList(meal5);
        }
    }
}
