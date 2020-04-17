using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV2
{
    static class MaxHeapSort
    {
        public static int[] Sort(int[] numbers)
        {
            Stopwatch s = new Stopwatch();
            Console.WriteLine("Heapsort stopwatch started");
            s.Start();
            int[] heap = BuildHeap(numbers);
            int heapSize = heap.Length;
            for (int i = heapSize - 1; i > 0; i--)
            {
                Swap(heap, 0, i);
                heapSize--;
                Heapify(heap, heapSize, 0);
            }
            Console.WriteLine("Heapsort stopwatch ended: " + s.Elapsed);
            s.Stop();
            Console.WriteLine("__________________________________");
            return heap;
        }

        private static int[] BuildHeap(int[] numbers)
        {
            int heapSize = numbers.Length;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(numbers, heapSize, i);
            }
            return numbers;
        }

        private static void Heapify(int[] heap, int heapSize, int node)
        {
            int l = Left(node);
            int r = Right(node);
            int largest;
            if (l < heapSize && heap[l] > heap[node])
                largest = l;
            else
                largest = node;
            if (r < heapSize && heap[r] > heap[largest])
                largest = r;
            if(largest != node)
            {
                Swap(heap, node, largest);
                Heapify(heap, heapSize, largest);
            }
        }

        private static void Swap(int[] heap, int node1, int node2)
        {
            heap[node1] += heap[node2];
            heap[node2] = heap[node1] - heap[node2];
            heap[node1] -= heap[node2];
        }

        private static int Left(int node)
        {
            return 2 * node;
        }

        private static int Right(int node)
        {
            return 2 * node + 1;
        }

        private static int Parent(int node)
        {
            return node / 2;
        }
    }
}
