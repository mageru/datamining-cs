using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject
{
    public class Common
    {
        public static string FormatOutputWithNewLine(string input)
        {
            return string.Concat(input, '\n');
        }

        public static string GenerateFileName(string algorithmName)
        {
            string fileName = string.Empty;
            string fileDate = DateTime.Now.ToString("mmddyyyy");

            fileName = string.Format("{0}_{1}_{2}.txt", algorithmName, fileDate, DateTime.Now.Ticks.ToString());
            return fileName;
        }
    }
}
