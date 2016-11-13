using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] test ={
                           {2,3}
                          
                                    };

            Solution soln = new Solution();
            IList<int> spiral = soln.SpiralOrder(test);
            Console.Read();

        }
    }

    public class Solution
    {
        public IList<int> SpiralOrder(int[,] matrix)
        {
            int maxHeight = matrix.GetLength(0);        //number of rows
            int maxWidth = matrix.GetLength(1);       //number of columns
            int minHeight = 0;
            int minWidth = 0;
            List<int> spiralMatrix = new List<int>();
            int i = -1;                              //row runner
            int j = 0;                              //column runner
           
            while (spiralMatrix.Count < (matrix.GetLength(0) * matrix.GetLength(1)))
            {
               
                while (++i < maxWidth && spiralMatrix.Count < (matrix.GetLength(0) * matrix.GetLength(1)))
                    spiralMatrix.Add(matrix[j, i]);
                --i;                

                while (++j < maxHeight && spiralMatrix.Count < (matrix.GetLength(0) * matrix.GetLength(1)))
                    spiralMatrix.Add(matrix[j, i]);

                --j;
                --maxWidth;
                --maxHeight;
                while (--i >= minWidth && spiralMatrix.Count < (matrix.GetLength(0) * matrix.GetLength(1)))
                    spiralMatrix.Add(matrix[j, i]);


                ++i;
                ++minHeight;
                while (--j >= minHeight && spiralMatrix.Count < (matrix.GetLength(0) * matrix.GetLength(1)))
                    spiralMatrix.Add(matrix[j, i]);
                ++j;

               
                ++minWidth;
            }

            return spiralMatrix;
        }
    }
}
