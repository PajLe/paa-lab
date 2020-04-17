using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV2
{
    class BubbleSort
    {
        public static int[] Sort(int[] numbers)
        {
            Stopwatch s = new Stopwatch();
            Console.WriteLine("Bubblesort stopwatch started");
            s.Start();

            bool hasChanged = true;
            while (hasChanged)
            {
                hasChanged = false;
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        numbers[i] += numbers[i + 1];
                        numbers[i + 1] = numbers[i] - numbers[i + 1];
                        numbers[i] -= numbers[i + 1];
                        hasChanged = true;
                    }
                }
            }
            Console.WriteLine("Bubblesort stopwatch ended: " + s.Elapsed);
            s.Stop();
            Console.WriteLine("__________________________________");
            return numbers;
        }
    }
}
