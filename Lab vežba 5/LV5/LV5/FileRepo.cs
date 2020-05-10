using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV5
{
    class FileRepo
    {
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
    }
}
