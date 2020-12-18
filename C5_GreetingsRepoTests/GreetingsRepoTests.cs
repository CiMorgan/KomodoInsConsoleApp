using C5_GreetingsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace C5_GreetingsTests
{
    [TestClass]
    public class GreetingsRepoTests
    {
        private Greetings _greeting;
        private GreetingsRepo _greetingsRepo;

        [TestInitialize]
        public void Arrange()
        {
            _greeting = new Greetings("John", "Smith", CustomerType.Past);
            _greetingsRepo = new GreetingsRepo();
            _greetingsRepo.AddCustomerGreeting(_greeting);
        }
        //Add customer to greetings list
        [TestMethod]
        public void AddCustomer_ShouldGetNotNull()
        {
            Greetings newGreetings = new Greetings("Tom", "Smith", CustomerType.Current);
            GreetingsRepo repository = new GreetingsRepo();
            repository.AddCustomerGreeting(newGreetings);
            Greetings fromDirectory = repository.GetCustomerByFullName("Smith", "Tom");
            Assert.IsNotNull(fromDirectory);
        }
        //Update existing customer
        [TestMethod]
        public void UpdateExistingCustomer_ShouldReturnTrue()
        {
            Greetings updateGreeting = new Greetings("John", "Smith", CustomerType.Current);
            bool updateResult = _greetingsRepo.UpdateExistingCustomerGreeting("Smith", "John", updateGreeting);
            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            bool deleteResult = _greetingsRepo.RemoveCustomerGreetingFromList("Smith", "John");
            Assert.IsTrue(deleteResult);
        }
        [DataTestMethod]
        [DataRow("John", true)]
        [DataRow("Tom", false)]
        public void DeleteContent_ShouldMatchGivenBool(string firstName, bool shouldDelete)
        {
            bool deleteResult = _greetingsRepo.RemoveCustomerGreetingFromList("Smith", firstName);
            Assert.AreEqual(shouldDelete, deleteResult);
        }
    }
}
