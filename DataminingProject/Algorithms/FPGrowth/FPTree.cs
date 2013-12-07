using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms
{
    public class FPTree
    {
        public List<string> headerList = null;
        public Dictionary<string, FPNode> mapItemNodes = new Dictionary<string, FPNode>();

        public bool hasMoreThanOnePath = false;

        public FPNode root = new FPNode();

        public FPTree()
        {

        }

        public void addTransaction(List<string> transaction)
        {
            FPNode currentNode = root;

            foreach (string item in transaction)
            {
                FPNode child = currentNode.getChildWithID(item);

                if (child == null)
                {
                    FPNode newNode = new FPNode();
                    newNode.itemID = item;
                    newNode.parent = currentNode;

                    currentNode.children.Add(newNode);

                    if (!hasMoreThanOnePath && currentNode.children.Count > 1)
                    {
                        hasMoreThanOnePath = true;
                    }

                    currentNode = newNode;

                    

                    if (!mapItemNodes.ContainsKey(item))
                    {
                        mapItemNodes.Add(item, newNode);
                    }
                    else
                    {
                        FPNode header = mapItemNodes[item];

                        while (header.nodeLink != null)
                        {
                            header = header.nodeLink;
                        }
                        header.nodeLink = newNode;
                    }
                }
                else
                {
                    child.counter++;
                    currentNode = child;
                }
            }
        }

        public void addPrefixPath(List<FPNode> prefixPath, Dictionary<string, int> mapSupportBeta, int relativeMinSupport)
        {
            int pathCount = prefixPath.ElementAt(0).counter;

            FPNode currentNode = root;

            for (int i = prefixPath.Count - 1; i >= 1; i--)
            {
                FPNode pathItem = prefixPath[i];

                if(mapSupportBeta[pathItem.itemID] < relativeMinSupport)
                {
                    continue;
                }

                FPNode child = currentNode.getChildWithID(pathItem.itemID);

                if (child == null)
                {
                    FPNode newNode = new FPNode();

                    newNode.itemID = pathItem.itemID;
                    newNode.parent = currentNode;
                    newNode.counter = pathCount;

                    currentNode.children.Add(newNode);

                    if (!hasMoreThanOnePath && currentNode.children.Count > 1)
                    {
                        hasMoreThanOnePath = true;
                    }

                    currentNode = newNode;

                    FPNode header = null;

                    if (mapItemNodes.ContainsKey(pathItem.itemID))
                    {
                        header = mapItemNodes[pathItem.itemID];
                    }

                    if (header == null)
                    {
                        mapItemNodes.Add(pathItem.itemID, newNode);
                    }
                    else
                    {
                        while (header.nodeLink != null)
                        {
                            header = header.nodeLink;
                        }

                        header.nodeLink = newNode;
                    }
                }
                else
                {
                    child.counter += pathCount;
                    currentNode = child;
                }

            }

        }

        public void createHeaderList(Dictionary<string, int> dictionarySupport)
        {
            headerList = dictionarySupport.Keys.ToList();

            headerList.Sort(new FPStringComparer(dictionarySupport));
        }
    }
    
}
