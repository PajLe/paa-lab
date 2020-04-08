using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1
{
    class Program
    {
        static void Main(string[] args)
        {
            RabinKarp r = new RabinKarp("1415", 256);

            Console.WriteLine(r.Search("31415926")); 
            Console.WriteLine(r.Search("533339"));

            RabinKarp r1 = new RabinKarp("1415", 10);

            Console.WriteLine(r1.Search("31415926"));
            Console.WriteLine(r1.Search("5333141539"));
        }
    }
}
