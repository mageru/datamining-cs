using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class AprioriItemsetComparer : IComparer<List<string>>
    {
        
        public int Compare(List<string> x, List<string> y)
        {
            
            return(string.Join(",", x).CompareTo(string.Join(",","y")));
        }
    }
}
