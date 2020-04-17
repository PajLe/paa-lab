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

            Console.WriteLine("100 numbers:");
            //bubble test
            BubbleSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "100.txt"));

            //heap test
            MaxHeapSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "100.txt"));

            //radix test
            LSDRadixSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "100.txt"));
            Console.WriteLine("__________________________________");

            Console.WriteLine("1k numbers:");
            //bubble test
            BubbleSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "1k.txt"));

            //heap test
            MaxHeapSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "1k.txt"));

            //radix test
            LSDRadixSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "1k.txt"));
            Console.WriteLine("__________________________________");

            Console.WriteLine("10k numbers:");
            //bubble test
            FileRepo.WriteNumbersToFile(BubbleSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "10k.txt")), baseWriteRoute + "bubble-10k.txt");

            //heap test
            FileRepo.WriteNumbersToFile(MaxHeapSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "10k.txt")), baseWriteRoute + "heap-10k.txt");

            //radix test
            FileRepo.WriteNumbersToFile(LSDRadixSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "10k.txt")), baseWriteRoute + "radix-10k.txt");
            Console.WriteLine("__________________________________");

            Console.WriteLine("100k numbers:");
            //bubble test
            BubbleSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "100k.txt"));

            //heap test
            MaxHeapSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "100k.txt"));

            //radix test
            LSDRadixSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "100k.txt"));
            Console.WriteLine("__________________________________");

            Console.WriteLine("1m numbers:");
            //bubble test
            //BubbleSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "1m.txt"));

            //heap test
            MaxHeapSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "1m.txt"));

            //radix test
            LSDRadixSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "1m.txt"));
            Console.WriteLine("__________________________________");

            Console.WriteLine("10m numbers:");
            //bubble test
            //BubbleSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "10m.txt"));

            //heap test
            MaxHeapSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "10m.txt"));

            //radix test
            LSDRadixSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "10m.txt"));
            Console.WriteLine("__________________________________");

            Console.WriteLine("100m numbers:");
            //bubble test
            //BubbleSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "100m.txt"));

            //heap test
            MaxHeapSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "100m.txt"));

            //radix test
            LSDRadixSort.Sort(FileRepo.ReadNumberFile(baseSourceRoute + "100m.txt"));
            Console.WriteLine("__________________________________");

        }
    }
}
