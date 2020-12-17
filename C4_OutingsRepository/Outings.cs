using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_OutingsRepository
{
    public enum OutingType
    {
        Golf = 1,
        Bowling,
        Amusement_Park,
        Concert
    }
    public class Outings
    {
        public OutingType TypeOfOuting { get; set; }
        public int NumAttendees { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostPerPerson { get; set; }
        public double CostEvent { get; set; }

        public Outings() { }
        public Outings(OutingType typeOfOuting, int numAttendees, DateTime dateOfEvent, double costPerPerson)
        {
            TypeOfOuting = typeOfOuting;
            NumAttendees = numAttendees;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
            CostEvent = costPerPerson * numAttendees;
        }
    }
}
