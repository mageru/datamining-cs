using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class FPStringComparer : IComparer<String>
    {
        Dictionary<string, int> _supportCounts = new Dictionary<string, int>();

        public FPStringComparer(Dictionary<string, int> supportCounts)
        {
            _supportCounts = supportCounts;
        }

        public int Compare(string x, string y)
        {
            int result;

            result = _supportCounts[y] - _supportCounts[x];

            if (result == 0)
            {
                result = x.CompareTo(y);
                return result;
            }

            return result;
        }
    }
}
