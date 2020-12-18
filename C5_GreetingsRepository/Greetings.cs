using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C5_GreetingsRepository
{
    public enum CustomerType
    {
        Current = 1,
        Past,
        Potential
    }
    public class Greetings
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType TypeOfCustomer { get; set; }
        public string EmailGreeting { get; set; }
        public Greetings() { }
        public Greetings(string firstName, string lastName, CustomerType typeOfCustomer)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = typeOfCustomer;
            switch (typeOfCustomer)
            {
                case CustomerType.Current:
                    EmailGreeting = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case CustomerType.Past:
                    EmailGreeting = "It's been a long time since we've heard from you, we want you back.";
                    break;
                case CustomerType.Potential:
                    EmailGreeting = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
            }
        }
    }
}
