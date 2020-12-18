using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C5_GreetingsRepository
{
    public class GreetingsRepo
    {
        private List<Greetings> _listOfGreetings = new List<Greetings>();

        //Create
        public void AddCustomerGreeting(Greetings greeting)
        {
            _listOfGreetings.Add(greeting);
        }
        //Read
        public List<Greetings> GetCustomerGreetingsList()
        {
            return _listOfGreetings;
        }
        //Update
        public bool UpdateExistingCustomerGreeting(string originalLastName, string originalFirstName, Greetings newGreeting)
        {
            Greetings oldGreeting = GetCustomerByFullName(originalLastName, originalFirstName);
            if (oldGreeting != null)
            {
                oldGreeting.FirstName = newGreeting.FirstName;
                oldGreeting.LastName = newGreeting.LastName;
                oldGreeting.TypeOfCustomer = newGreeting.TypeOfCustomer;
                oldGreeting.EmailGreeting = newGreeting.EmailGreeting;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveCustomerGreetingFromList(string originalLastName, string originalFirstName)
        {
            Greetings delGreeting = GetCustomerByFullName(originalLastName, originalFirstName);
            if (delGreeting == null)
            {
                return false;
            }
            int initialCount = _listOfGreetings.Count;
            _listOfGreetings.Remove(delGreeting);
            if (initialCount > _listOfGreetings.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Helper
        public Greetings GetCustomerByFullName(string originalLastName, string originalFirstName)
        {
            foreach(Greetings greeting in _listOfGreetings)
            {
                if (greeting.FirstName == originalFirstName && greeting.LastName == originalLastName)
                {
                    return greeting;
                }
            }
            return null;
        }
    }
}
