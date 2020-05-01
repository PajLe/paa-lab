using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV4
{
    class Program
    {
        static void Main(string[] args)
        {
            MinFibonacciHeap fbh = new MinFibonacciHeap();

            fbh.Insert(20);
            fbh.Insert(100);
            fbh.Insert(-210);
            fbh.Insert(10);
            Console.WriteLine(fbh);

            MinFibonacciHeap fbh2 = new MinFibonacciHeap();

            fbh2.Insert(133);
            fbh2.Insert(-1);
            fbh2.Insert(-333);

            fbh.Union(fbh2);
            Console.WriteLine(fbh);
            Console.WriteLine(fbh.PeekMin());

        }
    }
}
