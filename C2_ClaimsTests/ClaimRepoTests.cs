using C2_ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace C2_ClaimsTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepository _repo;
        private Claim _claim;
        DateTime AccDate1 = new DateTime(2018, 4, 25);
        DateTime ClmDate1 = new DateTime(2018, 4, 27);

        [TestInitialize]
        public void Arrange()
        {
            _repo = new ClaimRepository();
            _claim = new Claim(1, ClaimType.Car, "Car accident on 465", 400.00, AccDate1, ClmDate1, true);
            _repo.AddClaimToList(_claim);
        }
        //Test add to list
        [TestMethod]
        public void AddToList_Should_GetNotNull()
        {
            DateTime AccDate2 = new DateTime(2018, 4, 11);
            DateTime ClmDate2 = new DateTime(2018, 4, 12);
            Claim claim = new Claim(2, ClaimType.Home, "House fire in kitchen", 4000.00, AccDate2, ClmDate2, true);
            ClaimRepository repository = new ClaimRepository();
            repository.AddClaimToList(claim);
            Claim getNewClaim = repository.GetClaimByIDnumber(2);
            Assert.IsNotNull(getNewClaim); 
        }
        //Test Update Method with bool and datatest
        [TestMethod]
        public void UpdateExistingClaim_ShouldReturnTrue()
        {
            Claim updateClaim = new Claim(1, ClaimType.Theft, "Car stolen on 465", 40000.00, AccDate1, ClmDate1, true);
            bool updateResult = _repo.UpdateExistingClaim(1, updateClaim);
            Assert.IsTrue(updateResult);
        }
        [DataTestMethod]
        [DataRow(2, false)]
        [DataRow(1, true)]
        public void UpdateExistingClaim_ShouldMatchGivenBool(int IDnum, bool shouldUpdate)
        {
            Claim updateClaim = new Claim(1, ClaimType.Theft, "Car stolen on 465", 40000.00, AccDate1, ClmDate1, true);
            bool updateResult = _repo.UpdateExistingClaim(IDnum, updateClaim);
            Assert.AreEqual(updateResult, shouldUpdate);
        }
        [TestMethod]
        public void DeleteClaim_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveClaimFromList(1);
            Assert.IsTrue(deleteResult);
        }
        [DataTestMethod]
        [DataRow(2, false)]
        [DataRow(1, true)]
        public void DeleteClaim_ShouldMatchGivenBool(int IDnum, bool shouldUpdate)
        {
            bool deleteResult = _repo.RemoveClaimFromList(IDnum);
            Assert.AreEqual(deleteResult, shouldUpdate);
        }

    }
}
