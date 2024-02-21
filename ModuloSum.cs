using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class ModuloSum
    {
        #region YOUR CODE IS HERE    

        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// Fill this function to check whether there's a subsequence numbers in the given array that their sum is divisible by M
        /// </summary>
        /// <param name="items">array of integers</param>
        /// <param name="N">array size </param>
        /// <param name="M">value to check against it</param>
        /// <returns>true if there's subsequence with sum divisible by M... false otherwise</returns>
        static public bool SolveValue(int[] items, int N, int M)
        {
            //1-Define extra storage 2D array 
            bool[,] divisability = new bool[N, M];
            //2-equations to  fill the table
            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    //3- solve it bottom up [building table]
                    //a-if it base case>>store it (return true or false)
                    //b-else >>calculate it

                    //Base Case
                    if (j == 0)
                    {
                        return true;
                    }

                    else
                    {
                        // Divide the problem into two subproblems
                        bool divide1 = divisability[i - 1, (j - items[i] % M + M) % M];
                        bool divide2 = divisability[i - 1, j];
                        // Combine the solutions to the subproblems
                        divisability[i, j] = divide1 || divide2;
                    }
                }
            }

            // Return the final value 
            return divisability[N - 1, 0];


        }
        #endregion

        #region FUNCTION#2: Construct the Solution
        //Your Code is Here:
        //==================
        /// <returns>if exists, return the numbers themselves whose sum is divisible by ‘M’ else, return null</returns>
        static public int[] ConstructSolution(int[] items, int N, int M)
        {
            Dictionary<int, int> remainders = new Dictionary<int, int>();
            int sum = 0;
            for (int i = 0; i < items.Length; i++)
            {
                sum = (sum + items[i]) % M;
                if (sum == 0)
                {
                    return items.Take(i + 1).ToArray();
                }
                if (remainders.ContainsKey(sum))
                {
                    int start = remainders[sum] + 1;
                    int[] subseq = new int[i - start + 1];
                    Array.Copy(items, start, subseq, 0, i - start + 1);
                    return subseq;
                }
                remainders[sum] = i;
            }
            return null;
        }
        #endregion
        #endregion
    }
}
    

