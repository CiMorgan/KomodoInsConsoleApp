using C4_OutingsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4_OutingsConsole
{
    class ProgramUI
    {
        private OutingsRepository _outingsRepo = new OutingsRepository();
        public void Run()
        {
            EstablishedOutingsList();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("\nSelect a menu option:\n" +
                                  "1. Display all outings\n" +
                                  "2. Add an outing\n" +
                                  "3. Cost of outings\n" +
                                  "4. Exit\n" +
                                  "Please enter 1, 2, 3, or 4");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //Display all outings
                        DisplayOutings();
                        break;
                    case "2":
                        //Add an outing
                        AddNewOuting();
                        break;
                    case "3":
                        //Display cost of outing by specific event or type of event
                        CostOfOutings();
                        break;
                    case "4":
                        //exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        //get valid input number
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
            }
        }
        private void DisplayOutings()
        {
            List<Outings> listOfOutings = _outingsRepo.GetOutingsList();
            listOfOutings.Sort(delegate (Outings x, Outings y)
            {
                return x.DateOfEvent.CompareTo(y.DateOfEvent);
            });
            Console.WriteLine("\n");
            List<string> headings = new List<string> { "Type Of Event", "Attendees", "Date of Event", "Cost per Person", "Cost of Event"};
            Console.Clear();
            Console.WriteLine($"\n{headings[0],-20} {headings[1],-12} {headings[2],-15} {headings[3],-18} {headings[4],-20}");
            foreach (Outings outing in listOfOutings)
            {
                string type = outing.TypeOfOuting.ToString();
                string numAttendees = outing.NumAttendees.ToString();
                string eventDate = outing.DateOfEvent.ToString("M/dd/yy");
                string costPerPerson = outing.CostPerPerson.ToString("n2");
                string costEvent = outing.CostEvent.ToString("n2");
                Console.WriteLine($"{type, -20} {numAttendees,-12} {eventDate,-15} ${costPerPerson,-18} ${costEvent,-20} ");
            }
        }
        private void AddNewOuting()
        {
            OutingType newOutingType= OutingType.Bowling;    //default outing is bowling
            int newOutingAttendeeNumber = 0;    //default number of attendees is 0
            DateTime newOutingDate = DateTime.Now;  //default date is today
            Double newCostPerPerson = 0;    //default cost per person is $0
            Console.Clear();
            bool eventTypeValid = false;
            while (!eventTypeValid)
            {
                Console.WriteLine("What type of event was the outing?\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n" +
                    "Please enter 1, 2, 3, or 4.");
                string typeInput = Console.ReadLine();
                switch (typeInput)
                {
                    case "1":
                        newOutingType = OutingType.Golf;
                        eventTypeValid = true;
                        break;
                    case "2":
                        newOutingType = OutingType.Bowling;
                        eventTypeValid = true;
                        break;
                    case "3":
                        newOutingType = OutingType.Amusement_Park;
                        eventTypeValid = true;
                        break;
                    case "4":
                        newOutingType = OutingType.Concert;
                        eventTypeValid = true;
                        break;
                    default:
                        //get valid input number
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
            }
            Console.WriteLine("\nHow many people attended the event?\n");
            newOutingAttendeeNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("What was the year of the event?");
            int outingYr = int.Parse(Console.ReadLine());
            Console.WriteLine("What was the month of the event? Please enter a number.");
            int outingMonth = ValidMonth();
            Console.WriteLine("What day of the month was the event? Please enter a number.");
            int outingDay = ValidDay(outingMonth, outingYr);
            newOutingDate = new DateTime(outingYr, outingMonth, outingDay);
            Console.WriteLine("\nWhat was the cost of the outing per person?\n");
            newCostPerPerson = double.Parse(Console.ReadLine());
            string strCostPerson = newCostPerPerson.ToString("n2");
            Outings newOuting = new Outings(newOutingType, newOutingAttendeeNumber, newOutingDate, newCostPerPerson);
            _outingsRepo.AddOutingToList(newOuting);
            Console.WriteLine($"\nThe {newOutingType} outing on {outingMonth}-{outingDay}-{outingYr} was added.\n" +
                              $"A total of {newOutingAttendeeNumber} people attended this event at a cost of ${strCostPerson} per person.\n" +
                              $"The total cost for this event was ${newOuting.CostEvent}.");
        }
        private void CostOfOutings()
        {
            Console.Clear();
            List<Outings> listOfOutings = _outingsRepo.GetOutingsList();
            Console.WriteLine("What type of cost would you like to see?\n" +
                "1. Cost per outing type\n" +
                "2. Cost for all outings\n" +
                "Please enter 1 or 2.");
            string costInput = Console.ReadLine();
            switch (costInput)
            {
                case "1":
                    OutingType costByOuting = OutingType.Bowling;
                    Console.WriteLine("For what type of outing would you like to see total cost?\n" +
                                      "1. Golf\n" +
                                      "2. Bowling\n" +
                                      "3. Amusement Park\n" +
                                      "4. Concert\n" +
                                      "Please enter 1, 2, 3, or 4.");
                    string costTypeInput = Console.ReadLine();
                    bool costTypeValid = false;
                    while (!costTypeValid)
                    {
                        switch (costTypeInput)
                        {
                            case "1":
                                costByOuting = OutingType.Golf;
                                costTypeValid = true;
                                break;
                            case "2":
                                costByOuting = OutingType.Bowling;
                                costTypeValid = true;
                                break;
                            case "3":
                                costByOuting = OutingType.Amusement_Park;
                                costTypeValid = true;
                                break;
                            case "4":
                                costByOuting = OutingType.Concert;
                                costTypeValid = true;
                                break;
                            default:
                                //get valid input number
                                Console.WriteLine("Please enter 1, 2, 3, or 4.");
                                break;
                        }
                    }
                    double TotalCostByType = 0;
                    foreach (Outings outing in listOfOutings)
                    {
                        if (outing.TypeOfOuting == costByOuting)
                        {
                            TotalCostByType = TotalCostByType + outing.CostEvent;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine($"\n\nThe total cost for {costByOuting} outings was ${TotalCostByType}.\n");
                    break;
                case "2":
                    double AllCost = 0;
                    foreach (Outings outing in listOfOutings)
                    {
                        AllCost = AllCost + outing.CostEvent;
                    }
                    Console.Clear();
                    Console.WriteLine($"\n\nThe total cost for all outings was ${AllCost}.\n");
                    break;
                default:
                    //get valid input number
                    Console.WriteLine("Not a valid number. Returning to main menu.");
                    break;
            }
        }
        private void EstablishedOutingsList()
        {
            DateTime date1 = new DateTime(2018, 5, 18);
            DateTime date2 = new DateTime(2018, 7, 6);
            DateTime date3 = new DateTime(2018, 12, 15);
            DateTime date4 = new DateTime(2019, 5, 19);
            DateTime date5 = new DateTime(2019, 8, 1);
            DateTime date6 = new DateTime(2019, 10, 3);
            DateTime date7 = new DateTime(2019, 12, 17);
            DateTime date8 = new DateTime(2020, 5, 20);
            Outings outings1 = new Outings(OutingType.Golf, 76, date1, 22);
            Outings outings2 = new Outings(OutingType.Bowling, 121, date2, 14.50);
            Outings outings3 = new Outings(OutingType.Concert, 175, date3, 8);
            Outings outings4 = new Outings(OutingType.Bowling, 101, date4, 14.25);
            Outings outings5 = new Outings(OutingType.Amusement_Park, 126, date5, 35.75);
            Outings outings6 = new Outings(OutingType.Bowling, 115, date6, 16);
            Outings outings7 = new Outings(OutingType.Concert, 125, date7, 8.75);
            Outings outings8 = new Outings(OutingType.Golf, 27, date8, 18);

            _outingsRepo.AddOutingToList(outings1);
            _outingsRepo.AddOutingToList(outings2);
            _outingsRepo.AddOutingToList(outings3);
            _outingsRepo.AddOutingToList(outings4);
            _outingsRepo.AddOutingToList(outings5);
            _outingsRepo.AddOutingToList(outings6);
            _outingsRepo.AddOutingToList(outings7);
            _outingsRepo.AddOutingToList(outings8);
        }
        private int ValidMonth()
        {
            bool NotValidMonth = true;
            int monthNum = 1;
            while (NotValidMonth)
            {
                monthNum = int.Parse(Console.ReadLine());
                if (monthNum < 1 | monthNum > 12)
                {
                    Console.WriteLine("That is not a valid number. Please enter a number between 1 and 12.");
                    monthNum = int.Parse(Console.ReadLine());
                }
                NotValidMonth = false;
            }
            return monthNum;
        }
        private int ValidDay(int month, int year)
        {
            bool NotValidDay = true;
            int dayNum = 1;
            int validNum = 31;
            if (month == 4 | month == 6 | month == 9 | month == 11)
            {
                validNum = 30;
            }
            if (month == 2)
            {
                if (year % 4 == 0 && year % 100 != 0)
                {
                    validNum = 29;
                }
                else
                {
                    if (year % 4 == 0 && year % 400 == 0)
                    {
                        validNum = 29;
                    }
                    else
                    {
                        validNum = 28;
                    }
                }
            }
            while (NotValidDay)
            {
                dayNum = int.Parse(Console.ReadLine());
                if (dayNum < 1 | dayNum > validNum)
                {
                    Console.WriteLine($"That is not a valid number. Please enter a number between 1 and {validNum}.");
                    dayNum = int.Parse(Console.ReadLine());
                }
                NotValidDay = false;
            }
            return dayNum;
        }

    }
}
