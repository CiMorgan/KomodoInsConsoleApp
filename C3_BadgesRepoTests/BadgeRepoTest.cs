using C3_BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace C3_BadgesTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        private Badge _badge;
        private BadgeRepo _badgeRepo;

        [TestInitialize]
        public void Arrange()
        {
            List<string> list1 = new List<string>();
            list1.Add("A10");
            list1.Add("B2");
            list1.Add("C17");
            _badgeRepo = new BadgeRepo();
            _badge = new Badge(8675, list1);
            _badgeRepo.AddBadgeToList(_badge);
        }
        //Test add method
        [TestMethod]
        public void AddBadge_ShouldGetNotNull()
        {
            List<string> list2 = new List<string>();
            list2.Add("A12");
            list2.Add("B1");
            list2.Add("C30");

            Badge newBadge = new Badge(4567, list2);
            _badgeRepo.AddBadgeToList(newBadge);

            Badge content =_badgeRepo.GetBadgeByID(4567);
            List<string> contentList = new List<string>();
            Assert.IsNotNull(contentList);
        }
        //Test update method
        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue()
        {
            List<string> list2 = new List<string>();
            list2.Add("A12");
            list2.Add("B1");
            list2.Add("C30");

            Badge newBadge = new Badge(8675, list2);
            bool updateResult = _badgeRepo.UpdateExistingBadge(8675, newBadge);
            Assert.IsTrue(updateResult);
        }
        //Test delete method
        [DataTestMethod]
        [DataRow(8675, true)]
        [DataRow(1234, false)]
        public void DeleteBadge_ShouldReturnTrue(int testID, bool shouldDelete)
        {
            bool deleteResult = _badgeRepo.RemoveExistingBadge(testID);
            Assert.AreEqual(shouldDelete, deleteResult);
        }
    }
}
