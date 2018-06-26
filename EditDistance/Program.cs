using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistance
{
    class Program
    {
        static int minimum(int a, int b, int c)
        {
            if (a <= b && a <= c) return a;
            if (b <= a && b <= c) return b;
            else return c;
        }

        static int editDistDP(String s1, String s2, int x, int y)
        {
            // Create a table to store
            // results of subproblems
            int[,] dp = new int[x + 1, y + 1];

            // Fill d[][] in bottom up manner
            for (int i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++)
                {
                    // If first string is empty, only option is to
                    // isnert all characters of second string
                    if (i == 0)
                    {
                        // Min. operations = j
                        dp[i, j] = j;
                    }

                    // If second string is empty, only option is to
                    // remove all characters of second string
                    else if (j == 0)
                    {
                        // Min. operations = i
                        dp[i, j] = i;
                    }
                    // If last characters are same, ignore last char
                    // and recur for remaining string
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    // If last character are different, consider all
                    // possibilities and find minimum
                    else
                    {
                        dp[i, j] = 1 + minimum(dp[i, j - 1],   // Insert
                                        dp[i - 1, j],      // Remove
                                        dp[i - 1, j - 1]); // Replace
                    }
                }
            }

            return dp[x, y];
        }
        static void Main(string[] args)
        {
            Console.Write("Enter String 1: ");
            String str1 = Console.ReadLine();
            Console.Write("Enter String 2: ");
            String str2 = Console.ReadLine();
            Console.WriteLine("Numbers of operations performed to convert String 1 to String 2 = " + editDistDP(str1, str2, str1.Length, str2.Length));
        }
    }
}
