using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class FPNode
    {
        
        public int counter { get; set; }
        public string itemID { get; set; }
        public FPNode parent {get;set;}
        public List<FPNode> children {get;set;}
        public FPNode nodeLink {get;set;}
        
        public FPNode()
        {
            counter = 1;
            parent = null;
            nodeLink = null;
            children = new List<FPNode>();
        }

        public FPNode getChildWithID(string id)
        {
            foreach (FPNode child in children)
            {
                if (child.itemID == id)
                {
                    return child;
                }
            }
            return null;
        }

    }
}
