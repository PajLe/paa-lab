using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1
{
    class RabinKarp
    {
        private static readonly long q = 1000004119; // a large prime
        private readonly string _pattern;
        private readonly long p;                     // pattern hash value
        private readonly int R;                      // R - radix - alphabet size
        private readonly int m;                      // pattern length
        private readonly long h;                     // R^(M-1) % Q

        public RabinKarp(string pattern, int R)
        {
            if (String.IsNullOrEmpty(pattern) || R < 1)
                throw new ArgumentException(/**/);
            this._pattern = pattern; 
            this.m = pattern.Length;
            this.R = R;

            this.h = 1;
            for (int i = 1; i <= m - 1; i++) // calculate R^(M-1) % Q
                h = (R * h) % q;

            this.p = hash(pattern, m);
        }

        private long hash(string key, int m)
        {
            long hash = 0;
            for (int j = 0; j < m; j++)
                hash = (R * hash + key[j]) % q;
            return hash;
        }

        public int Search(string text)
        {
            int n = text.Length;
            if (n < m) return n;

            long t = hash(text, m);
            if (t == p && text.Substring(0, m).Equals(_pattern)) return 0;

            for (int i = m; i < n; i++)
            {
                /*
             ts+1 = 31415 -   3  * 10000 =   1415 * 10 + text[i] = 14156 
                 */
                t = ((t - ((text[i - m] * h) % q)) * R + text[i]) % q;
                if (t == p && text.Substring(i - m + 1, m).Equals(_pattern))
                    return i - m + 1;
            }

            return n;
        }
    }
}
