using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LV1
{
    class KnuthMorrisPratt
    {
        private readonly string _pattern;
        private readonly int m;             // pattern size
        private readonly int[] pi;          // prefix function

        public KnuthMorrisPratt(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentNullException(/**/);

            this._pattern = pattern;
            this.m = pattern.Length;
            this.pi = new int[m];

            // compute prefix function
            pi[0] = 0;
            int k = 0;
            for (int q = 1; q < m; q++)
            {
                while (k > 0 && pattern[k] != pattern[q])
                    k = pi[k];
                if (pattern[k] == pattern[q])
                    k++;
                pi[q] = k;
            }
        }

        public int Search(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(/**/);

            int n = text.Length;    // text size
            int q = 0;              // number of characters matched
            for (int i = 0; i < n; i++)
            {
                while (q > 0 && _pattern[q] != text[i])
                    q = pi[q];
                if (_pattern[q] == text[i])
                    q++;
                if (q == m)
                    return i - m + 1;
            }

            return n;
        }

        public void SearchAll(string text, string writeToFile)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(/**/);

            using (StreamWriter sw = new StreamWriter(new FileStream(writeToFile, FileMode.Create)))
            {
                Stopwatch t = new Stopwatch();
                t.Start();
                Console.WriteLine("Start KMP - " + t.Elapsed);
                int n = text.Length;    // text size
                int q = 0;              // number of characters matched
                for (int i = 0; i < n; i++)
                {
                    while (q > 0 && _pattern[q] != text[i])
                        q = pi[q];
                    if (_pattern[q] == text[i])
                        q++;
                    if (q == m)
                    {
                        sw.Write(t.Elapsed + " : ");
                        sw.Write(i - m + 1);
                        int val = 0;
                        int im5 = i - m - 5;
                        if (im5 > -1) val = 5;
                        else { im5 = 0; val = i - m; }
                        sw.WriteLine(" : " + text.Substring(im5, (im5 + m + 10 < n)? m + 10 : m + val + n - i));
                        q = pi[q - 1];
                    }
                }
                Console.WriteLine("Stop KMP - " + t.Elapsed);
                t.Stop();
            }
        }
    }
}
