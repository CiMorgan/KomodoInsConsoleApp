using C3_BadgesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_Badges
{
    class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo(); 
        public void Run()
        {
            EstablishedBadgeList();
            Menu();
        }
        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Diplay user options
                Console.Clear();
                Console.WriteLine("\nHello Security Admin! What would you like to do today?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit\n" +
                    "Please select a number.");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        //Add a badge
                        AddNewBadge();
                        break;
                    case "2":
                        //Edit a badge
                        EditBadge();
                        break;
                    case "3":
                        //List all badges
                        DisplayAllBadges();
                        break;
                    case "4":
                        //Exit
                        Console.WriteLine("Have a pleasant day. Goodbye.");
                        keepRunning = false;
                        break;
                    default:
                        //Exit
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Case 1: add a badge
        private void AddNewBadge()
        {
            Badge newBadge = new Badge();
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.GetBadgeDictionary();
            Console.Clear();
            Console.WriteLine("What is the number on the badge?");
            int newBadgeNum = int.Parse(Console.ReadLine());
            List<string> newRoomList = new List<string>();
            bool addDoor = true;
            while (addDoor)
            {
                Console.WriteLine($"List a door needing access with badge number {newBadgeNum}:");
                string door = Console.ReadLine();
                newRoomList.Add(door);
                Console.WriteLine("Would you like to add another door (y/n)");
                string doorOption = Console.ReadLine().ToLower();
                if (doorOption == "n")
                {
                    addDoor = false;
                }
            }
            newBadge.BadgeID = newBadgeNum;
            newBadge.DoorNames = newRoomList;
            _badgeRepo.AddBadgeToList(newBadge);
            Console.WriteLine($"Badge number {newBadge.BadgeID} has been added.");
        }
        //Case 2: update a badge
        private void EditBadge()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.GetBadgeDictionary();
            Console.Clear();
            DisplayAllBadges();
            Console.WriteLine("What is the badge number to update?");
            int updateBadgeNum = int.Parse(Console.ReadLine());
            Badge updateBadge = _badgeRepo.GetBadgeByID(updateBadgeNum);
            if (updateBadge != null)
            {
                List<string> updateDoorList = updateBadge.DoorNames;
                string currentRoomString = "";
                for (int i = 1; i < updateDoorList.Count; i++)
                {
                    currentRoomString = currentRoomString + updateDoorList[i - 1] + ", ";
                }
                currentRoomString = currentRoomString + updateDoorList[updateDoorList.Count - 1];
                Console.WriteLine($"{updateBadgeNum} has access to doors: {currentRoomString}");
                Console.WriteLine("\nWhat would you like to do?\n" +
                    "1. Remove a door\n" +
                    "2. Add a door\n" +
                    "Please enter 1 or 2.");
            }
            else
            {
                Console.WriteLine("That is not a valid badge number.");
            }

        }
        //Case 3: list all badges
        private void DisplayAllBadges()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.GetBadgeDictionary();
            Console.WriteLine("Badge #      Door Access");
            foreach(KeyValuePair<int, List<string>> entry in badgeDictionary)
            {
                string roomString = "";
                for (int i = 1; i < entry.Value.Count; i++)
                {
                    roomString = roomString + entry.Value[i-1] + ", ";
                }
                roomString = roomString + entry.Value[entry.Value.Count-1];
                Console.WriteLine($"{entry.Key}        {roomString}");

            }

        }



        private void EstablishedBadgeList()
        {
            List<string> list1 = new List<string>();
            list1.Add("A10");
            list1.Add("B2");
            list1.Add("C17");
            Badge badge1 = new Badge(13478, list1);
            List<string> list2 = new List<string>();
            list2.Add("A12");
            list2.Add("B1");
            Badge badge2 = new Badge(21256, list2);
            List<string> list3 = new List<string>();
            list3.Add("A3");
            list3.Add("A4");
            list3.Add("A9");
            list3.Add("A11");
            list3.Add("C12");
            list3.Add("C17");
            Badge badge3 = new Badge(24376, list3);
            List<string> list4 = new List<string>();
            list4.Add("A10");
            Badge badge4 = new Badge(12479, list4);
            List<string> list5 = new List<string>();
            list5.Add("A12");
            list5.Add("C11");
            list5.Add("C12"); 
            list5.Add("C17");
            Badge badge5 = new Badge(13209, list5);
            _badgeRepo.AddBadgeToList(badge1);
            _badgeRepo.AddBadgeToList(badge2);
            _badgeRepo.AddBadgeToList(badge3);
            _badgeRepo.AddBadgeToList(badge4);
            _badgeRepo.AddBadgeToList(badge5);
        }
    }
}
