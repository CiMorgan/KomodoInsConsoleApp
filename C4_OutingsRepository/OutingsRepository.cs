using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_OutingsRepository
{
    public class OutingsRepository
    {
        private List<Outings> _listOfOutings = new List<Outings>();
        //Create
        public void AddOutingToList(Outings outing)
        {
            _listOfOutings.Add(outing);
        }
        //Read
        public List<Outings> GetOutingsList()
        {
            return _listOfOutings;
        }
        //Update
        public bool UpdateExistingOuting(OutingType typeOfOuting, DateTime dateOfOuting, Outings newOuting)
        {
            Outings oldOuting = GetOutingByTypeDate(typeOfOuting, dateOfOuting);
            if (oldOuting != null)
            {
                oldOuting.TypeOfOuting = newOuting.TypeOfOuting;
                oldOuting.NumAttendees = newOuting.NumAttendees;
                oldOuting.DateOfEvent = newOuting.DateOfEvent;
                oldOuting.CostPerPerson = newOuting.CostPerPerson;
                oldOuting.CostEvent = newOuting.CostEvent;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveOutingFromList(OutingType typeOfOuting, DateTime dateOfOuting)
        {
            Outings delOuting = GetOutingByTypeDate(typeOfOuting, dateOfOuting);

            if (delOuting == null)
            {
                return false;
            }
            int initialCount = _listOfOutings.Count;
            _listOfOutings.Remove(delOuting);
            if (initialCount > _listOfOutings.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper
        public Outings GetOutingByType(OutingType typeOfOuting)
        {
            foreach (Outings outings in _listOfOutings)
            {
                if (outings.TypeOfOuting == typeOfOuting)
                {
                    return outings;
                }
            }
            return null;
        }
        public Outings GetOutingByTypeDate(OutingType typeOfOuting, DateTime dateOfOuting)
        {
            foreach (Outings outings in _listOfOutings)
            {
                if (outings.TypeOfOuting == typeOfOuting && outings.DateOfEvent == dateOfOuting)
                {
                    return outings;
                }
            }
            return null;
        }
    }
}
