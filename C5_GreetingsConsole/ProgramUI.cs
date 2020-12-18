using C5_GreetingsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C5_GreetingsConsole
{
    public class ProgramUI
    {
        private GreetingsRepo _greetingsRepo = new GreetingsRepo();
        public void Run()
        {
            EstablishedCustomerGreetingsList();
            Menu();
        }
        //Menu
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options to user
                Console.WriteLine("\nSelect a menu option:\n" +
                    "1. Display all (current, past, and potential) customers\n" +
                    "2. Add new customer\n" +
                    "3. Update customer status (not functional)\n" +
                    "4. Display customers by current, past, and potential status\n" +
                    "5. Exit");
                //Get user input
                string input = Console.ReadLine();
                //Evaluate user input and respond
                switch (input)
                {
                    case "1":
                        DisplayAllCustomers();
                        break;
                    case "2":
                        AddNewCustomer();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        DisplayCustomerGroups();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye");
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
        private void DisplayAllCustomers()
        {
            List<Greetings> listOfGreetings = _greetingsRepo.GetCustomerGreetingsList();
            listOfGreetings.Sort(delegate (Greetings x, Greetings y)
            {
                return x.LastName.CompareTo(y.LastName);
            });
            List<string> headings = new List<string> { "First Name", "Last Name", "Type", "Email" };
            Console.Clear();
            Console.WriteLine($"\n{headings[0],-12} {headings[1],-12} {headings[2],-10} {headings[3],-10}");
            foreach (Greetings greeting in listOfGreetings)
            {
                Console.WriteLine($"{greeting.FirstName,-12} {greeting.LastName,-12} {greeting.TypeOfCustomer,-10} {greeting.EmailGreeting,-10}");
            }
        }
        private void AddNewCustomer()
        {
            Console.WriteLine("What is the customer's first name?");
            string fName = Console.ReadLine();
            Console.WriteLine("What is the customer's last name?");
            string lName = Console.ReadLine();
            Console.WriteLine($"\nWhat type of customer is {fName} {lName}?\n" +
                              "1. Current customer\n" +
                              "2. Past customer\n" +
                              "3. Potential customer\n" +
                              "Please enter 1, 2, or 3");
            string newCustInput = Console.ReadLine();
            CustomerType newType = CustomerType.Potential;
            switch (newCustInput)
            {
                case "1":
                    newType = CustomerType.Current;
                    break;
                case "2":
                    newType = CustomerType.Past;
                    break;
                case "3":
                    newType = CustomerType.Potential;
                    break;
                default:
                    Console.WriteLine("Please enter a valid number");
                    break;
            }
            Greetings newGreetings = new Greetings(fName, lName, newType);
            _greetingsRepo.AddCustomerGreeting(newGreetings);
            Console.WriteLine($"{fName} {lName}, a {newType} customer, has been added to the email list.");
        }
        private void UpdateCustomer()
        {
            Console.WriteLine("Not built yet");
        }
        private void DisplayCustomerGroups()
        {
            Console.Clear();
            Console.WriteLine("\nWhat kind of customers would you like to see?\n" +
                "1. Current customers\n" +
                "2. Past customers\n" +
                "3. Potential customers\n");
            //Get user input
            string custInput = Console.ReadLine();
            //Evaluate user input and respond; default is potential customer
            CustomerType custType = CustomerType.Potential;
            switch (custInput)
            {
                case "1":
                    custType = CustomerType.Current;
                    DisplayByCustType(custType);
                    break;
                case "2":
                    custType = CustomerType.Past;
                    DisplayByCustType(custType);
                    break;
                case "3":
                    custType = CustomerType.Potential;
                    DisplayByCustType(custType);
                    break;
                default:
                    Console.WriteLine("Please enter a valid number");
                    break;
            }
        }
        public void DisplayByCustType(CustomerType customerType)
        {
            List<Greetings> listOfGreetings = _greetingsRepo.GetCustomerGreetingsList();
            listOfGreetings.Sort(delegate (Greetings x, Greetings y)
            {
                return x.LastName.CompareTo(y.LastName);
            });
            List<string> headings = new List<string> { "First Name", "Last Name", "Type" };
            Console.Clear();
            Console.WriteLine($"\n{headings[0],-12} {headings[1],-12} {headings[2],-10}");
            foreach (Greetings greeting in listOfGreetings)
            {
                if (greeting.TypeOfCustomer == customerType)
                {
                    Console.WriteLine($"{greeting.FirstName,-12} {greeting.LastName,-12} {greeting.TypeOfCustomer,-10}");
                }
            }
        }
        public void EstablishedCustomerGreetingsList()
        {
            Greetings greeting1 = new Greetings("John", "Smith", CustomerType.Past);
            Greetings greeting2 = new Greetings("Tom", "Smith", CustomerType.Current);
            Greetings greeting3 = new Greetings("Elon", "Thomas", CustomerType.Current);
            Greetings greeting4 = new Greetings("Jake", "Clark", CustomerType.Current);
            Greetings greeting5 = new Greetings("Martha", "Maddox", CustomerType.Current);
            Greetings greeting6 = new Greetings("Penny", "Parker", CustomerType.Past);
            Greetings greeting7 = new Greetings("Don", "Trump", CustomerType.Past);
            Greetings greeting8 = new Greetings("Ben", "Sharp", CustomerType.Potential);
            Greetings greeting9 = new Greetings("Milly", "Thomas", CustomerType.Potential);
            Greetings greeting10 = new Greetings("Janet", "Aikens", CustomerType.Potential);
            Greetings greeting11 = new Greetings("John", "Nelson", CustomerType.Potential);
            Greetings greeting12 = new Greetings("Clark", "Hurley", CustomerType.Potential);

            _greetingsRepo.AddCustomerGreeting(greeting1);
            _greetingsRepo.AddCustomerGreeting(greeting2);
            _greetingsRepo.AddCustomerGreeting(greeting3);
            _greetingsRepo.AddCustomerGreeting(greeting4);
            _greetingsRepo.AddCustomerGreeting(greeting5);
            _greetingsRepo.AddCustomerGreeting(greeting6);
            _greetingsRepo.AddCustomerGreeting(greeting7);
            _greetingsRepo.AddCustomerGreeting(greeting8);
            _greetingsRepo.AddCustomerGreeting(greeting9);
            _greetingsRepo.AddCustomerGreeting(greeting10);
            _greetingsRepo.AddCustomerGreeting(greeting11);
            _greetingsRepo.AddCustomerGreeting(greeting12);
        }
    }
}
