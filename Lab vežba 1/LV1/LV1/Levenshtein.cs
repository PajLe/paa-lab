using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1
{
    class Levenshtein
    {
        public Levenshtein()
        {

        }

        public static int LevenshteinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            int[,] distances = new int[m + 1, n + 1];

            for (int i = 0; i < m + 1; i++)
                distances[i, 0] = i;
            for (int j = 0; j < n + 1; j++)
                distances[0, j] = j;

            for (int j = 1; j < n + 1; j++)
            {
                for (int i = 1; i < m + 1; i++)
                {
                    int cost;
                    if (word1[i - 1] == word2[j - 1]) cost = 0;
                    else cost = 1;
                    distances[i, j] = Min3(distances[i - 1, j] + 1              // insertion
                                            , distances[i, j - 1] + 1           // deletion
                                            , distances[i - 1, j - 1] + cost);  // substitution
                }
            }
            return distances[m, n];
        }

        private static void PrintMatrix(int[,] mat, int rows, int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(mat[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static int Min3(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
