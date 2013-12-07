using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class ItemSet
    {
        //holds all the items
        public HashSet<int> itemSet { get; set; }

        //contains the list of transaction sequence ids 
        public HashSet<int> transactionIDSet { get; set; }

        public int Count
        {
            get
            {
                return itemSet.Count();
            }
        }

        public int AbsoluteSupport
        {
            get
            {
                return transactionIDSet.Count();
            }
        }

        public ItemSet()
        {
            itemSet = new HashSet<int>();
            transactionIDSet = new HashSet<int>();
        }

        //overrides the toString method
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (int current in itemSet)
            {
                sb.Append(current.ToString()).Append("");
            }

            return sb.ToString();
        }

        public void print()
        {
            Console.WriteLine(this.ToString());
        }


        //may need to revisit this method.  Need to check extension functions carefully
        public ItemSet Union(ItemSet itemsetToUnion)
        {
            ItemSet tempItemSet = new ItemSet();

            List<int> tempList = this.itemSet.ToList().Union(itemsetToUnion.itemSet.ToList()).ToList();
            
            foreach (int current in tempList)
            {
                tempItemSet.itemSet.Add(current);
            }

            return tempItemSet;
        }

        
        public double getRelativeSupport(int objectCount)
        {
            double val = 0.0;

            val = ((double) transactionIDSet.Count) / ((double) objectCount);
            
            return val;
        }

        public bool Contains(int itemToFind)
        {
            return itemSet.Contains(itemToFind);
        }

        //returns the relative support of current itemset as string
        public string GetRelativeSupportAsString(int objectCount)
        {
            double frequency = getRelativeSupport(objectCount);

            return frequency.ToString("0.00");
        }

    }
}
