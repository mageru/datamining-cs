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
        private double _minSupport;
        private int _relativeMinSupport;

        public delegate void MileStoneEventHandler(string output);
        public event MileStoneEventHandler MileStoneEvent;

        public CLOSETPlusAlgo(double minSupport)
        {
            _minSupport = minSupport;
        }

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
                            }

                            transactionCount++;
                        }
                    }
                }
            }
        }

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
                            }

                            transactionCount++;
                        }
                    }
                }
            }
        }


    }
}
