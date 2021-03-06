﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV2
{
    class FileRepo
    {
        public static void GenerateNumberFile(string outputFile, int numOfElements)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(outputFile, FileMode.Create)))
            {
                Random r = new Random();
                for (int i = 0; i < numOfElements; i++)
                    sw.WriteLine(r.Next(10001));
            }
        }

        public static int[] ReadNumberFile(string fileName)
        {
            int[] numbers;
            using (StreamReader sr = new StreamReader(new FileStream(fileName, FileMode.Open)))
            {
                char[] delims = { ' ', '\n', '\r' };
                string[] numbersAsStrings = sr.ReadToEnd().Split(delims, StringSplitOptions.RemoveEmptyEntries);
                numbers = new int[numbersAsStrings.Length];
                for (int i = 0; i < numbers.Length; i++)
                    numbers[i] = int.Parse(numbersAsStrings[i]);
            }
            return numbers;
        }

        public static void WriteNumbersToFile(int[] numbers, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create)))
            {
                foreach (int num in numbers)
                    sw.WriteLine(num);
            }
        }
    }
}
