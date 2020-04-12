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
            //FilesRepo.GenerateHexFile("../../../../testfiles/1.txt", 9);
            //FilesRepo.GenerateAsciiFile("100-ascii.txt", 100);

            KnuthMorrisPratt k = new KnuthMorrisPratt("and");
            //k.SearchAll(FilesRepo.ReadAsString("../../../../testfiles/1k-princeton.txt"), "res.txt");
            k.SearchAll("gand fdplopandlopolaffandl", "res.txt");
            k.SearchAll("and", "res1.txt");
            //k.Search(FilesRepo.ReadAsString("../../../../testfiles/1k-princeton.txt"));
            /*KnuthMorrisPratt k = new KnuthMorrisPratt("and");

            Console.WriteLine(k.Search("Everyone ann and and wants"));
            Console.WriteLine(k.Search("533339"));*/

        }
    }
}
