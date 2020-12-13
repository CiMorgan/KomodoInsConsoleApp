using C1_CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace C1_CafeTests
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuRepo _repo;
        private Menu _menu;
        List<string> ingredList1 = new List<string>
            {
                "chicken",
                "hot sauce"
            };

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _menu = new Menu(1, "Wings", "Traditional hand-breaded wings tossed in your choice of Buffalo or Spicy Buffalo sauce with celery sticks and ranch or blue cheese for dipping", ingredList1, 10.99);
            _repo.AddMealToList(_menu);
        }

        //Test Add meal to list method
        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            List<string> ingredList2 = new List<string>
            {
                "potatoes",
                "cheese",
                "bacon",
                "jalapenos"
            };
            Menu meal = new Menu(2, "Cheese Fries", "Crispy seasoned French fries topped with mixed cheeses, bacon, and fried jalapeños with ranch", ingredList2, 6.99);
            MenuRepo repository = new MenuRepo();
            repository.AddMealToList(meal);
            Menu mealAddToList = repository.GetMealByName("Cheese Fries");
            Assert.IsNotNull(mealAddToList);
        }

        //Test read by number
        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(1, false)]

        public void GetMealByNumber_ShouldMatchBool(int origNum, bool ShouldUpdate)
        {
            Menu getMeal = _repo.GetMealByNumber(origNum);
            string getMealName = getMeal.ItemName;
            string realName = "Wings";
            Assert.AreEqual(getMealName, realName);
        }

        //Test read by name
        [TestMethod]
        public void GetMealByName_ShouldMatchBool()
        {
            Menu getMeal = _repo.GetMealByName("Wings");
            string getMealName = getMeal.ItemName;
            string realName = "Wings";
            Assert.AreEqual(getMealName, realName);
        }

        //Test update method with bool and data tests
        [TestMethod]
        public void UpdateMealList_ShouldReturnTrue()
        {
            Menu newMeal = new Menu(1, "Buffalo Wings", "Traditional hand-breaded wings tossed in your choice of Buffalo or Spicy Buffalo sauce with celery sticks and ranch or blue cheese for dipping", ingredList1, 10.99);
            bool updateListResults = _repo.UpdateExistingMeal(1, newMeal);
            Assert.IsTrue(updateListResults);
        }

        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]

        public void UpdateMealList_ShouldGiveBoolMatch(int mealNum, bool shouldUpdate)
        {
            Menu newMeal = new Menu(1, "Buffalo Wings", "Traditional hand-breaded wings tossed in your choice of Buffalo or Spicy Buffalo sauce with celery sticks and ranch or blue cheese for dipping", ingredList1, 10.99);
            bool updatedMealStatus = _repo.UpdateExistingMeal(mealNum, newMeal);

            Assert.AreEqual(updatedMealStatus, shouldUpdate);
        }

        //Test delete method with bool and data sets
        [TestMethod]
        public void DeleteMeal_ShouldReturnTrue()
        {
            bool deleteResult = _repo.DeleteExistingMeal(1);
            Assert.IsTrue(deleteResult);
        }

        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]

        public void DeleteMeal_ShouldGiveBoolMatch(int delNum, bool shouldDel)
        {
            bool deleteResult = _repo.DeleteExistingMeal(delNum);
            Assert.AreEqual(deleteResult, shouldDel);
        }
    }
}
