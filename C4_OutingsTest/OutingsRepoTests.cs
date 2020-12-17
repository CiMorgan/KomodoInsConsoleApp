using C4_OutingsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace C4_OutingsTest
{
    [TestClass]
    public class OutingsRepoTests
    {
        private Outings _outings;
        private OutingsRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new OutingsRepository();
            DateTime date1 = new DateTime(2020, 5, 17);
            _outings = new Outings(OutingType.Golf, 76, date1 , 22);
            _repo.AddOutingToList(_outings);
        }
        //Test Add Method
        [TestMethod]
        public void AddOutingToList_ShouldGetNotNull()
        {
            DateTime date2 = new DateTime(2020, 6, 04);
            Outings newOuting = new Outings(OutingType.Bowling, 123, date2, 17.25);
            OutingsRepository repository = new OutingsRepository();
            
            repository.AddOutingToList(newOuting);
            Outings contentFromList = repository.GetOutingByTypeDate(OutingType.Bowling, date2);

            Assert.IsNotNull(contentFromList);
        }
        //Test Update Method
        [TestMethod]
        public void UpdateExistingOuting_ShouldReturnTrue()
        {
            DateTime date1 = new DateTime(2020, 5, 17);
            Outings updateOuting = new Outings(OutingType.Golf, 72, date1, 22);
            bool updateResult = _repo.UpdateExistingOuting(OutingType.Golf, date1, updateOuting);
            Assert.IsTrue(updateResult);
        }
        [DataTestMethod]
        [DataRow(72, true)]
        [DataRow(76, false)]
        public void UpdateExistingOuting_ShouldMatchGivenBool(int attendees, bool shouldUpdate)
        {
            DateTime date1 = new DateTime(2020, 5, 17);
            Outings updateOuting = new Outings(OutingType.Golf, 72, date1, 22);
            _repo.UpdateExistingOuting(OutingType.Golf, date1, updateOuting);
            Outings updatedOutings = _repo.GetOutingByTypeDate(OutingType.Golf, date1);
            int actual = updatedOutings.NumAttendees;
            int possible = attendees;
            bool updated = false;
            if (actual == possible)
            {
                updated = true;
            }
            Assert.AreEqual(updated, shouldUpdate);
        }
        //Test Delete Method
        [TestMethod]
        public void DeleteOuting_ShouldReturnTrue()
        {
            bool delOuting = _repo.RemoveOutingFromList(_outings.TypeOfOuting, _outings.DateOfEvent);
            Assert.IsTrue(delOuting);
        }
        [DataTestMethod]
        [DataRow(OutingType.Golf, true)]
        [DataRow(OutingType.Bowling, false)]
        public void DeleteOuting_ShouldMatchGivenBool(OutingType outingType, bool shouldDelete)
        {
            DateTime date1 = new DateTime(2020, 5, 17);
            bool delOuting = _repo.RemoveOutingFromList(outingType, date1);
            Assert.AreEqual(delOuting, shouldDelete);
        }
    }
}
