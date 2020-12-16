using C2_ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Claims_Console
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();
        public void Run()
        {
            EstablishedClaimList();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options to user, get user input, evaluate user input, and respond appropriately
                Console.WriteLine("\nChoose a menu item:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit\n" +
                    "Please enter a number:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //See all claims
                        SeeAllClaims();
                        break;
                    case "2":
                        //Take care of next claim
                        TakeNextClaim();
                        break;
                    case "3":
                        //Enter a new claim
                        EnterNewClaim();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Have an awesome day at Komodo Insurance.");
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
        //Case 1: See all claims
        private void SeeAllClaims()
        {
            List<Claim> listOfClaims = _claimRepo.GetClaimList();
            Console.WriteLine("\n");
            List<string> headings = new List<string> { "ClaimID", "Type", "Description", "Amount", "Date Of Incident", "Date Of Claim", "IsValid" };
            Console.Clear();
            Console.WriteLine($"\n{headings[0], -8} {headings[1], -10} {headings[2], -30} {headings[3], -15} {headings[4], -18} {headings[5], -15} {headings[6], -10}");
            foreach (Claim claim in listOfClaims)
            {
                string IncDate = claim.DateOfIncident.ToString("M/dd/yy");
                string ClmDate = claim.DateOfClaim.ToString("M/dd/yy");
                string amount = claim.ClaimAmount.ToString("n2");
                Console.WriteLine($"{claim.ClaimID, -8} {claim.TypeOfClaim, -10} {claim.Description, -30} ${amount, -15} {IncDate, -18} {ClmDate, -15} {claim.IsValid, -10}");
            }
        }
        //Case 2: Take care of next claim
        private void TakeNextClaim()
        {
            List<Claim> listOfClaims = _claimRepo.GetClaimList();
            if (listOfClaims.Count == 0)
            {
                Console.WriteLine("We are fantastic claims agents. There are no more claims.");
            }
            else
            {
                Claim nextClaim = listOfClaims[0];
                Console.WriteLine("\n\nHere are the details for the next claim to be handled.");
                Console.WriteLine($"\n" +
                    $"         ClaimID: {nextClaim.ClaimID}\n" +
                    $"            Type: {nextClaim.TypeOfClaim}\n" +
                    $"     Description: {nextClaim.Description}\n" +
                    $"          Amount: {nextClaim.ClaimAmount}\n" +
                    $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                    $"   Date of Claim: {nextClaim.DateOfClaim}\n" +
                    $"         IsValid: {nextClaim.IsValid}\n");
                Console.WriteLine("Do you want to deal with this claim now?\n" +
                                  "    1. Yes\n" +
                                  "    2. No\n" +
                                  "Please enter 1 or 2.");
                string nextClaimInput = Console.ReadLine();
                bool nextClaimNotValid = true;
                bool wasHandled = false;
                while (nextClaimNotValid)
                {
                    switch (nextClaimInput)
                    {
                        case "1":
                            int claimID = nextClaim.ClaimID;
                            wasHandled = _claimRepo.RemoveClaimFromList(claimID);
                            nextClaimNotValid = false;
                            break;
                        case "2":
                            nextClaimNotValid = false;
                            break;
                        default:
                            Console.WriteLine("Please enter 1 or 2.");
                            nextClaimInput = Console.ReadLine();
                            break;
                    }
                }
                if (wasHandled)
                {
                    Console.WriteLine($"ClaimID #{nextClaim.ClaimID} was handled and has been removed from the queue.");
                }
            }
        }

        //Case 3: Enter a new claim
        private void EnterNewClaim()
        {
            List<Claim> listOfClaims = _claimRepo.GetClaimList();
            Console.Clear();
            int lastID = listOfClaims.Count;
            Claim claimID = listOfClaims[lastID - 1];
            int newID = claimID.ClaimID + 1;
            Console.WriteLine("\nWhat is the type of Claim?\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n" +
                "Please enter 1, 2, or 3");
            string TypeID = Console.ReadLine();
            ClaimType newType = ClaimType.Car;
            bool NotValidType = true;
            while (NotValidType)
            {
                switch (TypeID)
                {
                    case "1":
                        newType = ClaimType.Car;
                        NotValidType = false;
                        break;
                    case "2":
                        newType = ClaimType.Home;
                        NotValidType = false;
                        break;
                    case "3":
                        newType = ClaimType.Theft;
                        NotValidType = false;
                        break;
                    default:
                        Console.WriteLine("Please enter 1, 2, or 3.");
                        TypeID = Console.ReadLine();
                        break;
                }
            }
            Console.WriteLine("Please describe the incident in less than 25 characters.");
            string newDesc = Console.ReadLine();
            Console.WriteLine("What is the amount of the claim?");
            double newAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("What was the year of the incident?");
            int incYr = int.Parse(Console.ReadLine());
            Console.WriteLine("What was the month of the incident? Please enter a number.");
            int incMonth = ValidMonth();
            Console.WriteLine("What day of the month was the incident? Please enter a number.");
            int incDay = ValidDay(incMonth, incYr);
            DateTime incDate = new DateTime(incYr, incMonth, incDay);
            Console.WriteLine("What is the date of the claim?\n" +
                              "Would you like to use today's date?\n" +
                              "    1. Yes\n" +
                              "    2. No\n" +
                              "Please enter 1 or 2.");
            string claimDateInput = Console.ReadLine();
            DateTime claimDate = DateTime.Now;
            bool NotValidClaimDate = true;
            while (NotValidClaimDate)
            {
                switch (claimDateInput)
                {
                    case "1":
                        claimDate = DateTime.Now;
                        NotValidClaimDate = false;
                        break;
                    case "2":
                        Console.WriteLine("What was the year of the claim?");
                        int claimYr = int.Parse(Console.ReadLine());
                        Console.WriteLine("What was the month of the claim? Please enter a number.");
                        int claimMonth = ValidMonth();
                        Console.WriteLine("What day of the month was the claim? Please enter a number.");
                        int claimDay = ValidDay(claimMonth, claimYr);
                        claimDate = new DateTime(claimYr, claimMonth, claimDay);
                        NotValidClaimDate = false;
                        break;
                    default:
                        Console.WriteLine("Please enter 1 or 2.");
                        TypeID = Console.ReadLine();
                        break;
                }
            }
            DateTime LastDayForClaim = incDate.AddDays(30);
            bool validClaim = true;
            if (LastDayForClaim.Date < claimDate.Date)
            {
                validClaim = false;
            }
            Claim newClaim = new Claim(newID, newType, newDesc, newAmount, incDate, claimDate, validClaim);
            _claimRepo.AddClaimToList(newClaim);
            Console.WriteLine("\nThe claim has been added.");
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
        private void EstablishedClaimList()
        {
            DateTime AccDate1 = new DateTime(2018, 4, 25);
            DateTime ClmDate1 = new DateTime(2018, 4, 27);
            Claim claim1 = new Claim(1, ClaimType.Car, "Car accident on 465", 400.00, AccDate1, ClmDate1, true);

            DateTime AccDate2 = new DateTime(2018, 4, 11);
            DateTime ClmDate2 = new DateTime(2018, 4, 12);
            Claim claim2 = new Claim(2, ClaimType.Home, "House fire in kitchen", 4000.00, AccDate2, ClmDate2, true);

            DateTime AccDate3 = new DateTime(2018, 4, 27);
            DateTime ClmDate3 = new DateTime(2018, 6, 1);
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes", 4.00, AccDate3, ClmDate3, false);

            DateTime AccDate4 = new DateTime(2018, 5, 01);
            DateTime ClmDate4 = new DateTime(2018, 5, 17);
            Claim claim4 = new Claim(4, ClaimType.Car, "Ran into cow", 444.40, AccDate4, ClmDate4, true);

            DateTime AccDate5 = new DateTime(2018, 7, 01);
            DateTime ClmDate5 = new DateTime(2018, 8, 17);
            Claim claim5 = new Claim(5, ClaimType.Theft, "Laptop stolen from Starbucks", 1400.40, AccDate5, ClmDate5, false);

            DateTime AccDate6 = new DateTime(2018, 12, 25);
            DateTime ClmDate6 = new DateTime(2018, 12, 26);
            Claim claim6 = new Claim(6, ClaimType.Home, "Santa fell off the roof", 44000.00, AccDate6, ClmDate6, true);

            _claimRepo.AddClaimToList(claim1);
            _claimRepo.AddClaimToList(claim2);
            _claimRepo.AddClaimToList(claim3);
            _claimRepo.AddClaimToList(claim4);
            _claimRepo.AddClaimToList(claim5);
            _claimRepo.AddClaimToList(claim6);

        }
    }
}
