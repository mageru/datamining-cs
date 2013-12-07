using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DataminingProject.Algorithms
{
    public class Apriori
    {
        //The file that contains the dataset
        public string InputDataFile { get; set; }       

        double _minSupport;
        int _relativeSupport;

        Dictionary<string, int> candidateCounts = new Dictionary<string, int>();
        
        Dictionary<List<string>, int> candidateSupportCounts = new Dictionary<List<string>, int>(new ListStringKeyComparer());

        public delegate void MileStoneEventHandler(string output);
        public event MileStoneEventHandler MileStoneEvent;

        //long k;

        public Apriori(double minSupport)
        {
            _minSupport = minSupport;
        }

        private bool LoadItemSet()
        {
            int transactionCount = 0;

            bool status = false;

            if (File.Exists(this.InputDataFile))
            {
                using (FileStream fs = new FileStream(this.InputDataFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string[] transactionArray = null;
                        List<string> itemTracker = new List<string>();

                        while (!sr.EndOfStream)
                        {
                            //Load the data
                            transactionArray = sr.ReadLine().Split(new char[] { ',' });
                            transactionCount++;

                            //make sure the array contains elements other than the transaction id 
                            if (transactionArray.GetUpperBound(0) > 0)
                            {
                                string currentItem = string.Empty;                                

                                for (int i = 1; i <= transactionArray.GetUpperBound(0); i++)
                                {
                                    currentItem = transactionArray[i];

                                    if (!itemTracker.Contains(currentItem))
                                    {
                                        itemTracker.Add(currentItem);
                                        List<String> currentItemAsArray = new List<string>() { currentItem };
                                        

                                        if (candidateSupportCounts.Any(pair => pair.Key == currentItemAsArray))
                                        {
                                            candidateSupportCounts[currentItemAsArray] += 1;
                                        }
                                        else
                                        {
                                            candidateSupportCounts.Add(currentItemAsArray, 1);
                                        }
                                    }
                                    else
                                    {
                                        candidateSupportCounts[new List<string>{currentItem}] += 1;
                                    }
                                }
                            }
                        }//end while

                        _relativeSupport = (int)Math.Ceiling(_minSupport * transactionCount);

                        //Prune, remove the items that do meet the minimum support count
                        var candidatesToRemove = candidateSupportCounts.Where(pair => pair.Value < _relativeSupport).Select(pair => pair.Key).ToList();                        

                        foreach (var key in candidatesToRemove)
                        {
                            candidateSupportCounts.Remove(key);
                        }


                        MileStoneEvent(Common.FormatOutputWithNewLine("Frequent 1-Itemsets"));
                        MileStoneEvent(Common.FormatOutputWithNewLine("-------------------------"));
                        foreach (List<string> key in candidateSupportCounts.Keys)
                        {
                            MileStoneEvent(Common.FormatOutputWithNewLine(string.Format("{0}: {1}", string.Join(",", key), candidateSupportCounts[key])));             
                        }

                    }
                }
            }
            else
            {
                //send error message.
                //throw exception
            }

            return status;
        }


        private List<List<string>> GenerateItemSet(int index)
        {
            List<List<string>> KItemSet = new List<List<string>>();
            List<string> currentItemSet = null;

            if (index == 2)
            {
                
               for (int i = 0; i < candidateSupportCounts.Keys.Count; i++)
               {
                   for (int j = i + 1; j < candidateSupportCounts.Keys.Count; j++)
                   {
                       currentItemSet = new List<string>();

                       currentItemSet.AddRange(candidateSupportCounts.Keys.ElementAt(i));
                       currentItemSet.AddRange(candidateSupportCounts.Keys.ElementAt(j));
                       //Console.WriteLine("** Comparing i= {0} j= {1} [{2}] [{3}]", i,j,string.Join(",", candidateSupportCounts.Keys.ElementAt(i)),string.Join(",", candidateSupportCounts.Keys.ElementAt(j)));

                       currentItemSet = candidateSupportCounts.Keys.ElementAt(i).Union(candidateSupportCounts.Keys.ElementAt(j)).ToList();

                       currentItemSet.Sort();

                       var distinctCurrentItemSet = currentItemSet.Distinct().ToList<string>();

                       if (!KItemSet.Contains(currentItemSet))
                       {
                           KItemSet.Add(currentItemSet);
                       }

                   }
               }
            }
            else
            {
                for (int i = 0; i < candidateSupportCounts.Keys.Count; i++)
                {
                    for (int j = i + 1; j < candidateSupportCounts.Keys.Count; j++)
                    {
                        currentItemSet = new List<string>();

                        int myIndex = 0;

                        List<string> tempItemSet1 = new List<string>();
                        List<string> tempItemSet2 = new List<string>();

                        for (int k = 0; k < index - 2; k++)
                        {
                            myIndex = k;
                            tempItemSet1.Add(candidateSupportCounts.Keys.ElementAt(i).ElementAt(myIndex));
                            tempItemSet2.Add(candidateSupportCounts.Keys.ElementAt(j).ElementAt(myIndex));
                        }
                                                
                        if (tempItemSet2.Except(tempItemSet1).ToList().Count == 0)
                        {
                            tempItemSet1.Add(candidateSupportCounts.Keys.ElementAt(i).ElementAt(myIndex + 1));
                            tempItemSet1.Add(candidateSupportCounts.Keys.ElementAt(j).ElementAt(myIndex + 1));
                            currentItemSet.AddRange(tempItemSet1);

                            currentItemSet.Sort();
                            
                            if (!KItemSet.Contains(currentItemSet))
                            {
                                KItemSet.Add(currentItemSet);
                            }
                        }
                    }
                }
            }
            //reset support counts
            candidateSupportCounts = new Dictionary<List<string>, int>(new ListStringKeyComparer());

            /*
            try
            {
                //KItemSet.Sort(new AprioriItemsetComparer());
            }
            catch (Exception ex)
            {

            }
            */

            //MileStoneEvent("\n");
            //MileStoneEvent(Common.FormatOutputWithNewLine(string.Format("Itemset {0}", index)));
            //MileStoneEvent(Common.FormatOutputWithNewLine("-------------------------"));

            foreach (List<string> itemSetKey in KItemSet)
            {
                //string temp = string.Join(",", itemSetKey);
                //MileStoneEvent(Common.FormatOutputWithNewLine(temp));

                //Console.WriteLine(temp);

                if (!candidateSupportCounts.Keys.Contains(itemSetKey))
                {
                    candidateSupportCounts.Add(itemSetKey, 0);
                }
                
            }
           
            //need to make sure item is sorted in database

            return KItemSet;
        }

        private bool PopulateKItemSetCounts(List<List<string>> kItemSet, int currentLevel)
        {
            bool status = false;            

            if (File.Exists(this.InputDataFile))
            {
                using (FileStream fs = new FileStream(this.InputDataFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string[] transactionArray = null;
                        List<string> itemTracker = new List<string>();

                        while (!sr.EndOfStream)
                        {
                            //Load the data
                            transactionArray = sr.ReadLine().Split(new char[] { ',' });

                            foreach (List<string> kItemSetKey in kItemSet)
                            {
                                //fancy linq to determine if the kItemSetKey is a subset of transactionArray
                               if (!kItemSetKey.ToArray().Except(transactionArray).Any())
                               {
                                   candidateSupportCounts[kItemSetKey] += 1; 
                               }
                              
                            }
                        }//end while

                        //Prune, remove the items that do meet the minimum support count
                        var candidatesToRemove = candidateSupportCounts.Where(pair => pair.Value < _relativeSupport).Select(pair => pair.Key).ToList();

                        foreach (var key in candidatesToRemove)
                        {
                            candidateSupportCounts.Remove(key);
                        }

                    }
                }
            }
            else
            {
                //send error message.
                //throw exception
            }

            //Console.WriteLine("");

            if (candidateSupportCounts.Keys.Count > 0)
            {
                MileStoneEvent("\n");
                MileStoneEvent(Common.FormatOutputWithNewLine(string.Format("Frequent {0}-Itemsets", currentLevel)));
                MileStoneEvent(Common.FormatOutputWithNewLine("-------------------------"));
                foreach (List<string> key in candidateSupportCounts.Keys)
                {
                    MileStoneEvent(Common.FormatOutputWithNewLine(string.Format("{0}: {1}",string.Join(",", key),candidateSupportCounts[key])));             
                }
            }
            
            return status;
        }

        public void Process()
        {
            
            //Load initial Itemset with support counts from Database
            LoadItemSet();

            int k = 2;
 
            List<List<string>> KItemSet = GenerateItemSet(k);

            do
            {
                PopulateKItemSetCounts(KItemSet,k);

                //empty-set condition has been reached
                if (candidateSupportCounts.Count == 0)
                {
                    break;
                }

                k++;
                KItemSet = GenerateItemSet(k);
            }
            while (candidateSupportCounts.Count > 0);
            Console.WriteLine("Finished");   
        }
    }
}
