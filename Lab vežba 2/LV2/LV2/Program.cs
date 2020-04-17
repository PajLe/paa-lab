using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV2
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseSourceRoute = "../../../../testfiles/";
            string baseWriteRoute = "../../../../results/"; // radix, heap, bubble


            /*
            FileRepo.GenerateNumberFile(baseSourceRoute + "100.txt", 100);
            FileRepo.GenerateNumberFile(baseSourceRoute + "1k.txt", 1000);
            FileRepo.GenerateNumberFile(baseSourceRoute + "10k.txt", 10000);
            FileRepo.GenerateNumberFile(baseSourceRoute + "100k.txt", 100000);
            FileRepo.GenerateNumberFile(baseSourceRoute + "1m.txt", 1000000);
            FileRepo.GenerateNumberFile(baseSourceRoute + "10m.txt", 10000000);
            FileRepo.GenerateNumberFile(baseSourceRoute + "100m.txt", 100000000);*/

            FileRepo.WriteNumbersToFile(BubbleSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "100.txt")), "out.txt");
        }
    }
}
