using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataminingProject.Algorithms
{
    public class TransactionDatabase
    {
        public HashSet<int> items { get; set; }
        public List<List<int>> transactions { get; set; }

        public int Count
        {
            get
            {
                return transactions.Count;
            }
        }

        public TransactionDatabase()
        {
            
        }

        public void LoadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string[] transactionArray = null;
                        
                        while (!sr.EndOfStream)
                        {
                            //Load the data
                            transactionArray = sr.ReadLine().Split(new char[] { ',' });
                            
                            AddTransaction(Array.ConvertAll<string, int>(transactionArray, int.Parse).ToList());
                            
                        }//end while                    

                    }
                }
            }
        }

        public void AddTransaction(List<int> transactionToAdd)
        {
            transactions.Add(transactionToAdd);

            foreach (int itemToAdd in transactionToAdd)
            {
                items.Add(itemToAdd);
            }
        }
    }
}
