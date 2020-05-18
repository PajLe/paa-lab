using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV6
{
    class Program
    {
        private static readonly string baseSourceRoute = "../../../../testfiles/";

        static void Main(string[] args)
        {
            
            RBTree r = new RBTree();
            r.Insert('S');
            r.Insert('E');
            r.Insert('A');
            r.Insert('R');
            r.Insert('C');
            r.Insert('H');
            r.Insert('X');
            r.Insert('M');
            r.Insert('P');
            r.Insert('L');
            r.Delete('L');
            Console.WriteLine("Testing 10:");
            Test(10);
            Console.WriteLine("_________________________\n");
            Console.WriteLine("Testing 100:");
            Test(100);
            Console.WriteLine("_________________________\n");
            Console.WriteLine("Testing 1000:");
            Test(1000);
            Console.WriteLine("_________________________\n");
            Console.WriteLine("Testing 10000:");
            Test(10000);
            Console.WriteLine("_________________________\n");
            Console.WriteLine("Testing 100000:");
            Test(100000);
            Console.WriteLine("_________________________\n");
        }

        public static void Test(int numOfElements)
        {
            int numOfTests = numOfElements / 10;
            Stopwatch s = new Stopwatch();
            TimeSpan t;
            RBTree tree = new RBTree();

            int[] nums = FileRepo.ReadNumberFile(baseSourceRoute + numOfElements + ".txt");
            List<int> toRemove = new List<int>();
            List<int> toGet = new List<int>();
            List<int> toAdd = new List<int>();
            for (int i = 0; i < numOfElements; i++)
            {
                tree.Insert(nums[i]);
                if (i < numOfTests)
                    toRemove.Add(nums[i]);
                else if (i < 2 * numOfTests)
                    toGet.Add(nums[i]);
                else if (i < 3 * numOfTests)
                    toAdd.Add(nums[i]);
            }

            Console.WriteLine("Remove 10% of " + numOfElements);
            t = new TimeSpan();
            foreach (int rem in toRemove)
            {
                s.Start();
                tree.Delete(rem);
                s.Stop();
                t = t.Add(s.Elapsed);
                s.Reset();
            }
            Console.WriteLine("Total remove time: " + t);
            

            Console.WriteLine("Get 10% of " + numOfElements);
            t = new TimeSpan();
            foreach (int get in toGet)
            {
                s.Start();
                tree.Delete(get);
                s.Stop();
                t = t.Add(s.Elapsed);
                s.Reset();
            }
            Console.WriteLine("Total get time: " + t);

            Console.WriteLine("Add 10% of " + numOfElements);
            t = new TimeSpan();
            foreach (int add in toAdd)
            {
                s.Start();
                tree.Delete(add);
                s.Stop();
                t = t.Add(s.Elapsed);
                s.Reset();
            }
            Console.WriteLine("Total add time: " + t);
        }
    }

}
