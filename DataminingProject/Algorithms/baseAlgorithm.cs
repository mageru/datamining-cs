using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public abstract class baseAlgorithm
    {
        public delegate void MileStoneEventHandler(string output);
        public event MileStoneEventHandler MileStoneEvent; 
    }
}
