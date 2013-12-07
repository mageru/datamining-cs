using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataminingProject.Algorithms
{
    class CLOSETPlusAlgo
    {
        public string InputDataFile { get; set; }

        private int transactionCount = 0; // transaction count in the database
        private int itemsetCount; // number of freq. itemsets found
        private double _minSupport {get; set;}
        private int _relativeMinSupport;

        public delegate void MileStoneEventHandler(string output);
        public event MileStoneEventHandler MileStoneEvent;

        public CLOSETPlusAlgo(double minSupport)
        {
            _minSupport = minSupport;
        }

        public void Process()
        {
            itemsetCount = 0;
            Dictionary<string, int> mapSupport = new Dictionary<string, int>();
            scanDatabaseToDetermineFrequencyOfSingleItems(mapSupport);
            _relativeMinSupport = (int)Math.Ceiling(_minSupport * transactionCount);
            FPTree globaltree = new FPTree();

            if (File.Exists(this.InputDataFile))
            {
                using (FileStream fs = new FileStream(this.InputDataFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line = string.Empty;
                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                            if (line == string.Empty || line.Substring(0, 1) == "#" || line.Substring(0, 1) == "%" || line.Substring(0, 1) == "@")
                            {
                                continue;
                            }
                            //#### Need to add a delimiter variable
                            string[] lineSplited = line.Split(new char[] { ' ' });
                            List<string> transaction = new List<string>();
                            foreach (string item in lineSplited)
                            {
                                if (mapSupport[item] >= _relativeMinSupport)
                                {
                                    transaction.Add(item);
                                }
                            }
                            transaction.Sort(new FPStringComparer(mapSupport));
                            globaltree.addTransaction(transaction);
                        }
                    }
                }

                globaltree.createHeaderList(mapSupport);
                string[] prefixAlpha = new string[0];
                fpgrowth(globaltree, prefixAlpha, transactionCount, mapSupport);
                print(globaltree.root, " ");
            }
            else
            {
                //throw error that file does not exists
            }
        }//end Process

        private void fpgrowthMoreThanOnePath(FPTree tree, string[] prefixAlpha, int prefixSupport, Dictionary<string, int> mapSupport)
        {
            //process the frequent items in reverse
            for (int i = tree.headerList.Count - 1; i >= 0; i--)
            {
                string item = tree.headerList.ElementAt(i);

                int support = mapSupport[item];
                // if the item is not frequent, we skip it
                if (support < _relativeMinSupport)
                {
                    continue;
                }

                //Create the BETA by using concatentation of the Alpha with the current item
                string[] beta = new string[prefixAlpha.Length + 1];
                prefixAlpha.CopyTo(beta, 0);
                beta[prefixAlpha.Length] = item;

                int betaSupport = (prefixSupport < support) ? prefixSupport : support;

                //Write out to file
                writeItemsetToOutput(beta, betaSupport);

                List<List<FPNode>> prefixPaths = new List<List<FPNode>>();
                FPNode path = null;

                if (tree.mapItemNodes.ContainsKey(item))
                {
                    path = tree.mapItemNodes[item];
                }

                while (path != null)
                {
                    // if the path is not just the root node
                    if (path.parent.itemID != null)
                    {
                        //build prefixpath
                        List<FPNode> prefixPath = new List<FPNode>();

                        // add this node.
                        prefixPath.Add(path);

                        //Recursively add all the parents of this node.
                        FPNode parent = path.parent;
                        while (parent.itemID != null)
                        {
                            prefixPath.Add(parent);
                            parent = parent.parent;
                        }
                        // add the path to the list of prefixpaths
                        prefixPaths.Add(prefixPath);
                    }
                    // We will look for the next prefixpath
                    path = path.nodeLink;
                }

                // (A) Calculate the frequency of each item in the prefixpath
                Dictionary<string, int> mapSupportBeta = new Dictionary<string, int>();
                // for each prefixpath
                foreach (List<FPNode> prefixPath in prefixPaths)
                {
                    // the support of the prefixpath is the support of its first node.
                    int pathCount = prefixPath.ElementAt(0).counter;
                    // for each node in the prefixpath,
                    // except the first one, we count the frequency
                    for (int j = 1; j < prefixPath.Count; j++)
                    {
                        FPNode node = prefixPath.ElementAt(j);
                        // if the first time we see that node id
                        if (!mapSupportBeta.ContainsKey(node.itemID))
                        {
                            // just add the path count
                            mapSupportBeta.Add(node.itemID, pathCount);
                        }
                        else
                        {
                            // otherwise, make the sum with the value already stored
                            mapSupportBeta[node.itemID] += pathCount;
                        }
                    }
                }
                // (B) Construct beta's conditional FP-Tree
                FPTree treeBeta = new FPTree();
                // add each prefixpath in the FP-tree
                foreach (List<FPNode> prefixPath in prefixPaths)
                {
                    treeBeta.addPrefixPath(prefixPath, mapSupportBeta, _relativeMinSupport);
                }
                // Create the header list.
                treeBeta.createHeaderList(mapSupportBeta);
                // Mine recursively the Beta tree if the root as child(s)
                if (treeBeta.root.children.Count > 0)
                {
                    // recursive call
                    fpgrowth(treeBeta, beta, betaSupport, mapSupportBeta);
                }
            }


        }//end fpgrowthMoreThanOnePath
        private void writeItemsetToOutput(string[] itemset, int support)
        {
            itemsetCount++;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < itemset.Length; i++)
            {
                sb.Append(itemset[i]);

                if (i != itemset.Length - 1)
                {
                    sb.Append(" ");
                }
            }

            sb.Append(":").Append(support).AppendLine();
            MileStoneEvent(sb.ToString());
        }//end writeItemsetToOutput

        private void scanDatabaseToDetermineFrequencyOfSingleItems(Dictionary<string, int> mapSupport)
        {
            if (File.Exists(this.InputDataFile))
            {
                using (FileStream fs = new FileStream(this.InputDataFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line = string.Empty;

                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();

                            if (line == string.Empty || line.Substring(0, 1) == "#" || line.Substring(0, 1) == "%" || line.Substring(0, 1) == "@")
                            {
                                continue;
                            }

                            //#### Need to add a delimiter variable
                            string[] lineSplited = line.Split(new char[] { ' ' });
                            foreach (string itemString in lineSplited)
                            {
                                if (mapSupport.ContainsKey(itemString))
                                {
                                    mapSupport[itemString]++;
                                }
                                else
                                {
                                    mapSupport.Add(itemString, 1);
                                }
                            }//end foreach
                            transactionCount++;
                        }//end while
                    }
                }
            }
        }//end scanDatabaseToDetermineFrequencyOfSingleItems

        private void print(FPNode node, string indention)
        {
            Console.WriteLine("{0}NODE : {1} COUNTER {2}", indention, node.itemID, node.counter);

            foreach (FPNode child in node.children)
            {

                print(child, string.Concat(indention, '\t'));
            }
        }//end print

        private void fpgrowth(FPTree tree, string[] prefixAlpha, int prefixSupport, Dictionary<string, int> mapSupport)
        {
            if (tree.hasMoreThanOnePath)
            {
                fpgrowthMoreThanOnePath(tree, prefixAlpha, prefixSupport, mapSupport);
            }
            else
            {
                addAllCombinationsForPathAndPrefix(tree.root.children.ElementAt(0), prefixAlpha);
            }
        }//end fpgrowth

        private void addAllCombinationsForPathAndPrefix(FPNode node, string[] prefix)
        {
            string[] itemset = new string[prefix.Length + 1];
            prefix.CopyTo(itemset, 0);
            itemset[prefix.Length] = node.itemID;

            //write output to screen
            writeItemsetToOutput(itemset, node.counter);

            if (node.children.Count != 0)
            {
                addAllCombinationsForPathAndPrefix(node.children.ElementAt(0), itemset);
                addAllCombinationsForPathAndPrefix(node.children.ElementAt(0), prefix);
            }

        }//end addAllCombinationsForPathAndPrefix
    }    
}
