using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV5
{
    class Program
    {
        private static readonly string baseSourceRoute = "../../../../testfiles/";
        private static readonly string baseWriteRoute = "../../../../results/";

        static void Main(string[] args)
        {
            BTree t = new BTree(5);
            
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
            Console.WriteLine(t.IntervalSearch('X', 'X'));

        }

        public static void Test(int elementsToInsert)
        {
            foreach el in elementsToIns
            BTree tree_3 = new BTree(3);
            BTree tree_5 = new BTree(5);
            BTree tree_11 = new BTree(11);
            BTree tree_33 = new BTree(33);
            BTree tree_101 = new BTree(101);
            BTree tree_333 = new BTree(333);
            BTree tree_1001 = new BTree(1001);
        }
    }
}
