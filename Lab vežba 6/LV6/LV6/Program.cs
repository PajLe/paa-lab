using System;
using System.Collections.Generic;
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
        }
    }
}
