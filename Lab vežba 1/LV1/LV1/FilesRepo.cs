using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1
{
    class FilesRepo
    {

        public static void GenerateHexFile(string fileName, int wordCount)
        {
            char[] alphabet = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            Random r = new Random();
            int wordLength;
            using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create)))
            {
                for (int i = 0; i < wordCount; i++)
                {
                    wordLength = r.Next(2, 16);
                    for (int j = 0; j < wordLength; j++)
                        sw.Write(alphabet[r.Next(0, 15)]);
                    sw.WriteLine();
                }
            }
        }
    }
}
