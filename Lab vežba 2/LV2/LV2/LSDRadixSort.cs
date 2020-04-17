using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV2
{
    class LSDRadixSort
    {
        private static readonly int BITS_PER_BYTE = 8;

        private LSDRadixSort() { }

        public static int[] Sort(int[] a)
        {
            Stopwatch s = new Stopwatch();
            Console.WriteLine("Radix stopwatch started");
            s.Start();
            int BITS = 32;                 // each int is 32 bits 
            int R = 1 << BITS_PER_BYTE;    // each bytes is between 0 and 255
            int MASK = R - 1;              // 0xFF
            int w = BITS / BITS_PER_BYTE;  // each int is 4 bytes

            int n = a.Length;
            int[] aux = new int[n];

            for (int d = 0; d < w; d++)
            {

                // compute frequency counts
                int[] count = new int[R + 1];
                for (int i = 0; i < n; i++)
                {
                    int c = (a[i] >> BITS_PER_BYTE * d) & MASK;
                    count[c + 1]++;
                }

                // compute cumulates
                for (int r = 0; r < R; r++)
                    count[r + 1] += count[r];

                // for most significant byte, 0x80-0xFF comes before 0x00-0x7F
                if (d == w - 1)
                {
                    int shift1 = count[R] - count[R / 2];
                    int shift2 = count[R / 2];
                    for (int r = 0; r < R / 2; r++)
                        count[r] += shift1;
                    for (int r = R / 2; r < R; r++)
                        count[r] -= shift2;
                }

                // move data
                for (int i = 0; i < n; i++)
                {
                    int c = (a[i] >> BITS_PER_BYTE * d) & MASK;
                    aux[count[c]++] = a[i];
                }

                // copy back
                for (int i = 0; i < n; i++)
                    a[i] = aux[i];
            }

            Console.WriteLine("Radix stopwatch ended: " + s.Elapsed);
            s.Stop();
            Console.WriteLine("__________________________________");
            return a;
        }
    }
}
