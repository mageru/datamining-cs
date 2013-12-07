using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class ItemSets
    {
        private List<List<ItemSet>> _levels = new List<List<ItemSet>>();

        private int _itemsetsCount = 0;

        private string _name;

        public List<List<ItemSet>> Levels
        {
            get
            {
                return _levels;
            }
        }

        public string Name
        {
            set
            {
                Name = value;
            }
        }


        public ItemSets(string itemSetName)
        {
            _name = itemSetName;
            _levels.Add(new List<ItemSet>());
        }

        public void PrintItemSets(int numberOfObjects)
        {
            Console.WriteLine("-----------{0}---------------", _name);

            int patternCount = 0;
            int levelCount = 0;

            foreach (List<ItemSet> level in _levels)
            {
                Console.WriteLine(" {0} L", levelCount);

                foreach (ItemSet itemset in level)
                {
                    Console.WriteLine(" {0}:", patternCount);
                    itemset.print();

                    Console.Write("support : {0}", itemset.GetRelativeSupportAsString(numberOfObjects));
                    patternCount++;

                    Console.WriteLine("");
                }
                levelCount++;
            }
            Console.WriteLine("------------------------------------");
        }

        public void AddItemset(ItemSet itemSetToAdd, int countOfItemsInSet)
        {
            while (_levels.Count <= countOfItemsInSet)
            {
                _levels.Add(new List<ItemSet>());
            }

            _levels[countOfItemsInSet].Add(itemSetToAdd);
            _itemsetsCount++;
        }
    }
}
