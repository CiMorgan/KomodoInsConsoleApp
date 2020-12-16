using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3_BadgesRepository
{
    public class BadgeRepo
    {
        private List<Badge> _listOfBadges = new List<Badge>();
        public Dictionary<int, List<string>> badgeDictionary = new Dictionary<int, List<string>>();
        //Create
        public void AddBadgeToList(Badge badge)
        {
            _listOfBadges.Add(badge);
            badgeDictionary.Add(badge.BadgeID, badge.DoorNames);
        }
        //Read
        public Dictionary<int, List<string>> GetBadgeDictionary()
        {
            return badgeDictionary;
        }
        //Update
        public bool UpdateExistingBadge(int badgeID, Badge updatedBadge)
        {
            Badge originalBadge = GetBadgeByID(badgeID);
            if (originalBadge != null)
            {
                badgeDictionary.Remove(badgeID);
                originalBadge.BadgeID = updatedBadge.BadgeID;
                originalBadge.DoorNames = updatedBadge.DoorNames;
                badgeDictionary.Add(updatedBadge.BadgeID, updatedBadge.DoorNames);
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveExistingBadge(int badgeID)
        {
            Badge deleteBadge = GetBadgeByID(badgeID);
            if (deleteBadge == null)
            {
                return false;
            }
            int initialCount = badgeDictionary.Count;
            _listOfBadges.Remove(deleteBadge);
            badgeDictionary.Remove(deleteBadge.BadgeID);
            if (initialCount > badgeDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper method - badge information by badgeID
        public Badge GetBadgeByID(int number)
        {
            foreach (Badge badge in _listOfBadges)
            {
                if (badge.BadgeID == number)
                {
                    return badge;
                }
            }
            return null; 
        }
    }
}
