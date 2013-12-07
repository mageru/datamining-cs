using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class ITNode
    {
        public ItemSet itemset { get; set; }
        public HashSet<int> transactionIDset { get; set; }
        public ITNode parent { get; set; }
        public List<ITNode> childNodes { get; set; }

        public ITNode(ItemSet initialItemSet)
        {
            parent = null;
            itemset = initialItemSet;
        }

        public void ReplaceInChildren(ItemSet replacementItemSet)
        {
            foreach (ITNode node in childNodes)
            {
                ItemSet currentItemSet = node.itemset;

                foreach (int currentItem in replacementItemSet.itemSet)
                {
                    if (!currentItemSet.Contains(currentItem))
                    {
                        currentItemSet.itemSet.Add(currentItem);
                    }
                }

                node.ReplaceInChildren(replacementItemSet);
            }
        }
    }
}
