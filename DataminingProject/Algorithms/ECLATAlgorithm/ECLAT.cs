using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class ECLAT : baseAlgorithm
    {
        public string InputDataFile { get; set; }

        double _minSupport;
        int _relativeSupport;

        private TransactionDatabase database = null;
        public ItemSets frequentItemSets = null;
        private int itemsetCount;


        public ECLAT(double minSupport)
        {
            _minSupport = minSupport;
            database = new TransactionDatabase();
            itemsetCount = 0;
        }

        public void Process()
        {
            database.LoadFile(this.InputDataFile);

            //will need to modify this before turning in

            frequentItemSets = new ItemSets("FREQUENT ITEMSETS");

            _relativeSupport = (int)Math.Ceiling(_minSupport * database.Count);

            HashSet<int> everyTransactionID = new HashSet<int>();

            int maxItemID = 0;

            Dictionary<int, HashSet<int>> mapItemCount = new Dictionary<int, HashSet<int>>();

            for(int i= 0; i < database.Count; i++)
            {
                everyTransactionID.Add(i);

                foreach (int currentItem in database.transactions.ElementAt(i))
                {
                    HashSet<int> currentSet = null;

                    if (!mapItemCount.ContainsKey(currentItem))
                    {
                        currentSet = new HashSet<int>();
                        mapItemCount.Add(currentItem, currentSet);

                        if (currentItem > maxItemID)
                        {
                            maxItemID = currentItem;
                        }
                    }
                    else
                    {
                        currentSet = mapItemCount[currentItem];
                    }

                    currentSet.Add(i);

                    ITSearchTree tree = new ITSearchTree();
                    ITNode root = new ITNode(new ItemSet());

                    root.transactionIDset = everyTransactionID;
                    tree.root = root;

                    foreach (var keypair in mapItemCount)
                    {
                        if (keypair.Value.Count >= _relativeSupport)
                        {
                            ItemSet localItemSet = new ItemSet();
                            localItemSet.itemSet.Add(keypair.Key);
                            ITNode localNode = new ITNode(localItemSet);

                            localNode.transactionIDset = keypair.Value;
                            localNode.parent = root;

                            root.childNodes.Add(localNode);
                        }
                    }

                    //Save(root);
                    //SortChildren(root);

                }
            }



        }

    }
}
