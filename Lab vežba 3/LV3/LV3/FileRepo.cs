using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV3
{
    class FileRepo
    {

        public static void GenerateAsciiFile(string fileName, int characterCount)
        {
            Random r = new Random();
            using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create)))
            {
                for (int j = 0; j < characterCount; j++)
                {
                    char c = (char)r.Next(0, 255);
                    sw.Write(c);
                }
            }
        }
    }
}
