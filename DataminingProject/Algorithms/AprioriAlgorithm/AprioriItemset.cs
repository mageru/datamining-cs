using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class AprioriItemset
    {
        private List<List<string>> _itemSet;


        public AprioriItemset()
        {
            _itemSet = new List<List<string>>();
        }

        public void AddItem(List<string> item)
        {
            if (!_itemSet.Contains(item))
            {
                _itemSet.Add(item);
            }
        }

        public void Sort()
        {
            
        }

    }
}
