using System.Collections.Generic;
using ByteBank.Models.Models;

namespace ByteBank.AgencySystem.Interfaces
{
    public class CurrentAcoountCompareByNumber : IComparer<CurrentAcoount>
    {
        public int Compare(CurrentAcoount x, CurrentAcoount y)
        {
            if (x == y)
                return 0; // they are equivalents
            if (x == null)
                return 1; // y stay in front of x
            if (y == null)
                return -1; //x stay in front of y

            return x.Number.CompareTo(y.Number);
        }
    }
}
