using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV4
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseSourceRoute = "../../../../testfiles/";
            
            // Fibonacci heap with 10 items
            MinFibonacciHeap fbh_10 = new MinFibonacciHeap();
            int[] items = FileRepo.ReadNumberFile(baseSourceRoute + "10.txt");
            Test(fbh_10, items);
            Console.WriteLine(fbh_10);

            /*// Fibonacci heap with 100 items
            MinFibonacciHeap fbh_100 = new MinFibonacciHeap();
            items = FileRepo.ReadNumberFile(baseSourceRoute + "100.txt");
            Test(fbh_100, items);

            // Fibonacci heap with 1k items
            MinFibonacciHeap fbh_1k = new MinFibonacciHeap();
            items = FileRepo.ReadNumberFile(baseSourceRoute + "1k.txt");
            Test(fbh_1k, items);

            // Fibonacci heap with 10k items
            MinFibonacciHeap fbh_10k = new MinFibonacciHeap();
            items = FileRepo.ReadNumberFile(baseSourceRoute + "10k.txt");
            Test(fbh_10k, items);

            // Fibonacci heap with 100k items
            MinFibonacciHeap fbh_100k = new MinFibonacciHeap();
            items = FileRepo.ReadNumberFile(baseSourceRoute + "100k.txt");
            Test(fbh_100k, items);*/
        }

        public static void Test(MinFibonacciHeap heap, int[] items)
        {
            Console.WriteLine("Fibonacci heap with " + items.Length + " items:");
            List<FNode> addedNodes = new List<FNode>();
            Stopwatch s = new Stopwatch();
            Random r = new Random();
            TimeSpan extract = new TimeSpan();
            TimeSpan decrease = new TimeSpan();
            TimeSpan delete = new TimeSpan();
            TimeSpan add = new TimeSpan();

            // Fill the Fibonacci heap
            for (int i = 0; i < items.Length; i++)
            {
                FNode toAdd = new FNode();
                toAdd.Key = items[i];
                heap.InsertNode(toAdd);
                addedNodes.Add(toAdd);
            }

            Console.WriteLine(heap);

            Console.WriteLine("ExtractMin() 10%:");
            // Extract min 10%
            for (int i = 0; i < items.Length / 10; i++)
            {
                s.Start();
                FNode toRemove = heap.ExtractMin();
                s.Stop();
                //Console.WriteLine(s.Elapsed);
                extract = extract.Add(s.Elapsed);
                s.Reset();

                addedNodes.Remove(toRemove);
            }
            Console.WriteLine(heap);
            Console.Write("________________________");
            Console.Write("Total: " + extract + "\n\n");

            Console.WriteLine("DecreaseKey() 10%:");
            // Decrease key 10%
            for (int i = 0; i < items.Length / 10; i++)
            {
                int indexToDecrease = r.Next(addedNodes.Count);
                int decreaseValue = r.Next(10001);
                FNode toDecrease = addedNodes[indexToDecrease];

                s.Start();
                try
                {
                    // heap.DecreaseKey(toDecrease, -1);
                    heap.DecreaseKey(toDecrease, decreaseValue);
                }
                catch (ArgumentException e)
                {
                    //Console.WriteLine(e.Message + "\nCurrent key: " + toDecrease.Key + "; New key: " + decreaseValue);
                    //Console.WriteLine(e.Message + "\nCurrent key: " + toDecrease.Key + "; New key: " + "-1");
                }
                s.Stop();
                //Console.WriteLine(s.Elapsed);
                decrease = decrease.Add(s.Elapsed);
                s.Reset();
            }
            Console.WriteLine(heap);
            Console.Write("________________________");
            Console.Write("Total: " + decrease + "\n\n");

            Console.WriteLine("Delete() 10%:");
            // Delete node 10%
            for (int i = 0; i < items.Length / 10; i++)
            {
                int indexToDelete = r.Next(addedNodes.Count);
                FNode toDelete = addedNodes[indexToDelete];

                s.Start();
                heap.Delete(toDelete);
                s.Stop();
                //Console.WriteLine(s.Elapsed);
                delete = delete.Add(s.Elapsed);
                s.Reset();

                addedNodes.Remove(toDelete);
            }
            Console.WriteLine(heap);
            Console.Write("________________________");
            Console.Write("Total: " + delete + "\n\n");

            Console.WriteLine("Insert() 10%:");
            // Add new 10%
            for (int i = 0; i < items.Length / 10; i++)
            {
                FNode toAdd = new FNode();
                toAdd.Key = r.Next(10001); 

                s.Start();
                heap.InsertNode(toAdd);
                s.Stop();
                //Console.WriteLine(s.Elapsed);
                add = add.Add(s.Elapsed);
                s.Reset();

                addedNodes.Add(toAdd);
            }
            Console.Write("________________________");
            Console.Write("Total: " + add + "\n\n");

            Console.WriteLine("________________________________________________");
            Console.WriteLine("________________________________________________\n\n");
        }
    }
}
