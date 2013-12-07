using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataminingProject.Algorithms.ECLATAlgorithm
{
    public class TriangularMatrix
    {
        private int[][] matrix;
        private int elementCount;

        public TriangularMatrix(int elmCount)
        {
            elementCount = elmCount;

            matrix = new int[elementCount - 1][];

            for (int i = 0; i < elementCount - 1; i++)
            {
                matrix[i] = new int[elementCount - i - 1];
            }
            
        }

        public int get(int i, int j)
        {
            return matrix[i][j];
        }

        public override string ToString()
        {
            Console.WriteLine("Element count = {0}", elementCount);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.Length; i++)
            {
                sb.Append(i).Append(": ");

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    sb.Append(matrix[i][j]);
                    sb.Append(" ");
                }
                sb.AppendLine("");
            }

            return sb.ToString();
        }

        public void incrementCount(int i, int j)
        {
            if (j < i)
            {
                incrementCount(j, i);
            }
            else
            {
                int indx = elementCount - j - 1;

                matrix[indx][i]++;
            }
        }

        public int GetItemSupport(int i, int j)
        {
            if (j < i)
            {
                return GetItemSupport(j, i);
            }
            else
            {
                int indx = elementCount - j - 1;
                return matrix[indx][i];
            }


        }
        
    }
}
