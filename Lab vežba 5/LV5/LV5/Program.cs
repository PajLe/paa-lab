using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV5
{
    class Program
    {
        private static readonly string baseSourceRoute = "../../../../testfiles/";
        // private static readonly string baseWriteRoute = "../../../../results/";

        static void Main(string[] args)
        {
            /**BTree t = new BTree(5);
            
            t.Insert('A');
            t.Insert('C');t.Insert('X');
            t.Insert('X');
            t.Insert('D');
            t.Insert('E'); t.Insert('X');
            t.Insert('G');
            t.Insert('X');
            t.Insert('J');
            t.Insert('K');
            t.Insert('X');
            t.Insert('M');
            t.Insert('X');
            t.Insert('N');
            t.Insert('X');
            t.Insert('O');
            t.Insert('P');
            t.Insert('R');
            t.Insert('X');
            t.Insert('S');
            t.Insert('T');
            t.Insert('U');
            t.Insert('V');
            t.Insert('X');
            t.Insert('Y');
            t.Insert('Z');
            t.Insert('B');
            t.Insert('Q');
            t.Insert('X');
            t.Insert('X');
            t.Insert('L');
            t.Insert('F');
            t.Insert('X');

            Console.WriteLine(t);
            Console.WriteLine(t.Search('X'));
            Console.WriteLine(t.IntervalSearch('X', 'Z'));
            Console.WriteLine(t.IntervalSearch('S', 'V'));
            Console.WriteLine(t.IntervalSearch('R', 'X'));
            Console.WriteLine(t.IntervalSearch('O', 'Q'));
            Console.WriteLine(t.IntervalSearch('X', 'X'));*/

            Test(100);
            Test(1000);
            Test(10000);
            Test(100000);
            Test(1000000);
        }

        public static void Test(int elementsToInsert)
        {
            Stopwatch s = new Stopwatch();
            TimeSpan t;
            int[] elements = FileRepo.ReadNumberFile(baseSourceRoute + elementsToInsert + ".txt");
            int testCount = elementsToInsert / 10; // 10% tests for each op.
            BTree tree_3 = new BTree(3);
            BTree tree_5 = new BTree(5);
            BTree tree_11 = new BTree(11);
            BTree tree_33 = new BTree(33);
            BTree tree_101 = new BTree(101);
            BTree tree_333 = new BTree(333);
            BTree tree_1001 = new BTree(1001);

            foreach (int el in elements)
            {
                tree_3.Insert(el);
                tree_5.Insert(el);
                tree_11.Insert(el);
                tree_33.Insert(el);
                tree_101.Insert(el);
                tree_333.Insert(el);
                tree_1001.Insert(el);
            }
            // tree_3
            Console.WriteLine("Testing max = 3");
            TestTree(tree_3, testCount);
            // tree_5
            Console.WriteLine("Testing max = 5");
            TestTree(tree_5, testCount);
            // tree_11
            Console.WriteLine("Testing max = 11");
            TestTree(tree_11, testCount);
            // tree_33
            Console.WriteLine("Testing max = 33");
            TestTree(tree_33, testCount);
            // tree_101
            Console.WriteLine("Testing max = 101");
            TestTree(tree_101, testCount);
            // tree_333
            Console.WriteLine("Testing max = 333");
            TestTree(tree_333, testCount);
            // tree_1001
            Console.WriteLine("Testing max = 1001");
            TestTree(tree_1001, testCount);
        }

        public static void TestTree(BTree tree, int testCount)
        {
            Stopwatch s = new Stopwatch();
            TimeSpan t;

            t = new TimeSpan();
            // insert
            for (int i = 0; i < testCount; i++)
            {
                Random r = new Random();
                int toInsert = r.Next(10001);
                s.Start();
                tree.Insert(toInsert);
                s.Stop();
                t = t.Add(s.Elapsed);
                s.Reset();
            }
            Console.WriteLine("Total insert: " + t);

            t = new TimeSpan();
            // delete
            for (int i = 0; i < testCount; i++)
            {
                Random r = new Random();
                int toDelete = r.Next(10001);
                s.Start();
                tree.Delete(toDelete);
                s.Stop();
                t = t.Add(s.Elapsed);
                s.Reset();
            }
            Console.WriteLine("Total delete: " + t);

            t = new TimeSpan();
            // search
            for (int i = 0; i < testCount; i++)
            {
                Random r = new Random();
                int toSearch = r.Next(10001);
                s.Start();
                tree.Delete(toSearch);
                s.Stop();
                t = t.Add(s.Elapsed);
                s.Reset();
            }
            Console.WriteLine("Total search: " + t);

            t = new TimeSpan();
            // interval search
            for (int i = 0; i < testCount; i++)
            {
                Random r = new Random();
                int keyFrom = r.Next(5001);
                int keyTo = r.Next(5001) + 5000;
                s.Start();
                tree.IntervalSearch(keyFrom, keyTo);
                s.Stop();
                t = t.Add(s.Elapsed);
                s.Reset();
            }
            Console.WriteLine("Total interval search: " + t);
            Console.WriteLine("_________________________________");
        }
    }
}
