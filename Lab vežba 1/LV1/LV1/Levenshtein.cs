using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1
{
    class Levenshtein
    {
        private readonly string _pattern;

        public Levenshtein(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentNullException();

            this._pattern = pattern;
        }

        public static int LevenshteinDistance(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
                throw new ArgumentNullException();
            // word1 = word1.ToLower();
            // word2 = word2.ToLower();

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

        public void FindAllWithLD3(string[] words, string writeToFile)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(writeToFile, FileMode.Create)))
            {
                Stopwatch t = new Stopwatch();
                t.Start();
                Console.WriteLine("Start Levenshtein - " + t.Elapsed);
                foreach (string word in words)
                {
                    int d;
                    if ((d = LevenshteinDistance(_pattern, word)) <= 3)
                    {
                        sw.Write(t.Elapsed + " : ");
                        sw.WriteLine(_pattern + " - " + word + ",  " + d);
                    }
                }
                Console.WriteLine("Stop Levenshtein - " + t.Elapsed);
                t.Stop();
            }
        }
    }
}
