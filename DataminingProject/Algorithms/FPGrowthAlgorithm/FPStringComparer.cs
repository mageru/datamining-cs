using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class FPStringComparer : IComparer<string>
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

    public class FPParamSupportComparer : IComparer<KeyValuePair<string,int>>
    {
        public List<KeyValuePair<string, int>> _supportCounts = new List<KeyValuePair<string, int>>();

        public FPParamSupportComparer(List<KeyValuePair<string, int>> supportCounts)
        {
            _supportCounts = supportCounts;
        }
        public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
        {
            int result;
            int yValue = y.Value;
            int xValue = x.Value;

            result = yValue - xValue;

            if (result == 0)
            {
                result = xValue.CompareTo(yValue);
                return result;
            }
            return result;
        }
    }
}
