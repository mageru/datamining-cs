using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class ListStringKeyComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> candidate, List<string> source)
        {
            bool status = false;

            if (ReferenceEquals(candidate, source))
            {
                return true;
            }

            if (candidate == null || source == null)
            {
                return false;
            }

            status = candidate.SequenceEqual(source);

            return status;
        }

        public int GetHashCode(List<string> obj)
        {
            return obj.Aggregate(17, (res, item) => unchecked(res * 23 + item.GetHashCode()));
        }
    }
}
