using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_ClaimsRepository
{
    public class ClaimRepository
    {
        private List<Claim> _listOfClaim = new List<Claim>();
        //Create
        public void AddClaimToList(Claim claim)
        {
            _listOfClaim.Add(claim);
        }
        //Read
        public List<Claim> GetClaimList()
        {
            return _listOfClaim;
        }
        //Update
        public bool UpdateExistingClaim(int claimID, Claim claim)
        {
            Claim origClaim = GetClaimByIDnumber(claimID);
            if (origClaim != null)
            {
                origClaim.ClaimID = claim.ClaimID;
                origClaim.TypeOfClaim = claim.TypeOfClaim;
                origClaim.Description = claim.Description;
                origClaim.ClaimAmount = claim.ClaimAmount;
                origClaim.DateOfIncident = claim.DateOfIncident;
                origClaim.DateOfClaim = claim.DateOfClaim;
                origClaim.IsValid = claim.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveClaimFromList(int claimID)
        {
            Claim delClaim = GetClaimByIDnumber(claimID);
            if (delClaim == null)
            {
                return false;
            }
            int initialCount = _listOfClaim.Count;
            _listOfClaim.Remove(delClaim);
            if (initialCount > _listOfClaim.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper method - find claim by ClaimID number
        public Claim GetClaimByIDnumber(int claimID)
        {
            foreach (Claim claim in _listOfClaim)
            {
                if (claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
