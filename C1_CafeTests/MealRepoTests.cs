using C1_CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace C1_CafeTests
{
    [TestClass]
    public class MealRepoTests
    {
        private MealRepo _repo;
        private Meal _meal;

        [TestInitialize]
        public void TestMethod1()
        {
            _repo = new MealRepo();
        }
    }
}
