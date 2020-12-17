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
            int newBadgeNum = 0;
            bool validBadgeNum = false;
            Console.WriteLine("What is the number on the new badge?");
            newBadgeNum = int.Parse(Console.ReadLine());
            while (!validBadgeNum)
            {
                bool currentNum = badgeDictionary.ContainsKey(newBadgeNum);
                if (currentNum)
                {
                    Console.WriteLine("That badge is already in use. Please verify badge number of the new card.");
                    Console.WriteLine("What is the number on the new badge?");
                    newBadgeNum = int.Parse(Console.ReadLine());
                    validBadgeNum = false;
                }
                else
                {
                    validBadgeNum = true;
                }
            }
            List<string> newRoomList = new List<string>();
            bool addDoor = true;
            while (addDoor)
            {
                Console.WriteLine($"List a door needing access with badge number {newBadgeNum}:");
                string door = Console.ReadLine();
                newRoomList.Add(door);
                Console.WriteLine("Would you like to add another door (y/n)");
                string doorOption = Console.ReadLine().ToLower();
                if (doorOption != "y")
                {
                    if (doorOption == "n")
                    {
                        addDoor = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter y or n.");
                        doorOption = Console.ReadLine().ToLower();
                    }
                }
            }
            newBadge.BadgeID = newBadgeNum;
            newRoomList.Sort();
            newBadge.DoorNames = newRoomList;
            _badgeRepo.AddBadgeToList(newBadge);
            Console.WriteLine($"Badge number {newBadge.BadgeID} has been added.");
        }
        //Case 2: update a badge
        private void EditBadge()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.GetBadgeDictionary();
            int updateBadgeNum = 0; 
            bool notValidBadge = true;
            while (notValidBadge)
            {
                DisplayAllBadges();
                Console.WriteLine("\n\nWhat is the badge number to update?");
                updateBadgeNum = int.Parse(Console.ReadLine());
                if (badgeDictionary.ContainsKey(updateBadgeNum))
                {
                    Console.Clear();
                    Console.WriteLine("That is a valid badge number.");
                    notValidBadge = false;
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid badge number. Please enter a valid number.\n");
                }
            }
            Badge updateBadge = _badgeRepo.GetBadgeByID(updateBadgeNum);
            List<string> updateDoorList = updateBadge.DoorNames;
            bool notDoneAdd = true;
            bool notDoneSub = true;
            while (notDoneAdd || notDoneSub)
            {
                Console.WriteLine("\nWhat would you like to do?\n" +
                                  "1. Remove a door\n" +
                                  "2. Add a door\n" +
                                  "3. Exit update\n" +
                                  "\nPlease enter 1, 2, or 3.");
                string updateInput = Console.ReadLine();
                switch (updateInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"\nWe are updating badge: {updateBadgeNum}\n");
                        DisplayDoorNames(updateBadge);
                        Console.WriteLine("\nWhich door(s) would you like to remove.\n" +
                                          "Press return / enter between each door you would like to remove.\n" +
                                          "Enter 'Done' when complete.\n");
                        string delDoor = Console.ReadLine();
                        string delDoorStr = "";
                        while (delDoor != "done" && delDoor != "Done")
                        {
                            bool delBool = updateDoorList.Remove(delDoor);
                            if (!delBool)
                            {
                                Console.WriteLine($"Door {delDoor} could not be deleted.");
                            }
                            else
                            {
                                delDoorStr = delDoorStr + " " + delDoor;

                            }
                            delDoor = Console.ReadLine();
                        }
                        Console.WriteLine($"\nThe following doors were removed from badge {updateBadgeNum}: {delDoorStr}");
                        notDoneSub = false;
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine($"\nWe are updating badge: {updateBadgeNum}\n");
                        DisplayDoorNames(updateBadge);
                        Console.WriteLine("\nWhich door(s) would you like to add.\n" +
                                          "Press return / enter between each door you would like to add.\n" +
                                          "Enter 'Done' when complete.\n");
                        string addDoor = Console.ReadLine();
                        string addDoorStr = "";
                        while (addDoor != "done" && addDoor != "Done")
                        {
                            bool newDoor = updateDoorList.Contains(addDoor);
                            if (!newDoor)
                            {
                                updateDoorList.Add(addDoor);
                                addDoorStr = addDoorStr + " " + addDoor;
                            }
                            addDoor = Console.ReadLine();
                        }
                        Console.WriteLine($"\nThe following doors were added to badge {updateBadgeNum}: {addDoorStr}");
                        notDoneAdd = false;
                        break;
                    case "3":
                        notDoneAdd = false;
                        notDoneSub = false;
                        break;
                    default:
                        Console.WriteLine("Please enter 1, 2, or 3.");
                        break;
                }
                updateDoorList.Sort();
                Badge updatedBadge = new Badge(updateBadgeNum, updateDoorList);
                bool badgeSuccessUpdate = _badgeRepo.UpdateExistingBadge(updateBadgeNum, updatedBadge);
                if (badgeSuccessUpdate)
                {
                    Console.WriteLine($"Badge number {updateBadgeNum} was successfully updated.");
                }
                else
                {
                    Console.WriteLine("No badge was updated at this time.");
                }
            }
        }
        //Case 3: list all badges and their door access on console
        private void DisplayAllBadges()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.GetBadgeDictionary();
            Console.WriteLine("Badge #      Door Access");
            foreach(KeyValuePair<int, List<string>> entry in badgeDictionary)
            {
                string roomString = "";
                if (entry.Value.Count != 0)
                {
                    for (int i = 1; i < entry.Value.Count; i++)
                    {
                        roomString = roomString + entry.Value[i - 1] + ", ";
                    }
                    roomString = roomString + entry.Value[entry.Value.Count - 1];
                }
                Console.WriteLine($"{entry.Key}        {roomString}");
            }
        }
        //Helper method: display all doors to which a particular badge has access
        private void DisplayDoorNames(Badge badge)
        {
            string doorString = "";

            if (badge.DoorNames.Count != 0)
            {
                for (int k = 0; k < badge.DoorNames.Count - 1; k++)
                {
                    doorString = doorString + badge.DoorNames[k] + ", ";
                }
                doorString = doorString + badge.DoorNames[badge.DoorNames.Count - 1];
                Console.WriteLine($"{badge.BadgeID} has access to: {doorString}");
            }
            if (badge.DoorNames.Count == 0)
            {
                Console.WriteLine("\nThis badge currently has no door access.");
            }
        }
        //Established badge list to intially populate badge dictionary and list.
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
