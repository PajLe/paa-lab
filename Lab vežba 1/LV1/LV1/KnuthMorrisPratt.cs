using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this._pattern = pattern;
            this.m = pattern.Length;
            this.pi = new int[m];

            // compute prefix function
            pi[0] = 0;
            int k = 0;
            for (int q = 1; q < m; q++)
            {
                while (k > 0 && pattern[k + 1] != pattern[q])
                    k = pi[k];
                if (pattern[k + 1] == pattern[q])
                    k++;
                pi[q] = k;
            }
        }

        public int Search(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException(/**/);

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
    }
}
