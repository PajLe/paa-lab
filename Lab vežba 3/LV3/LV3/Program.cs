using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV3
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseSourceRoute = "../../../../testfiles/";
            string baseWriteRoute = "../../../../results/";

            /*FileRepo.GenerateAsciiFile("random-100.txt", 100);
            FileRepo.GenerateAsciiFile("random-1k.txt", 1000);
            FileRepo.GenerateAsciiFile("random-10k.txt", 10000);
            FileRepo.GenerateAsciiFile("random-100k.txt", 100000);
            FileRepo.GenerateAsciiFile("random-1m.txt", 1000000);*/

            Console.WriteLine("mladic-100.txt code table:");
            ShannonFano sf_mladic100 = new ShannonFano(baseSourceRoute + "mladic-100.txt", baseWriteRoute + "sf/" + "mladic-100-sf.txt");
            sf_mladic100.Decode();
            Console.WriteLine("______________________________________\n");
            ShannonFano sf_mladic1k = new ShannonFano(baseSourceRoute + "mladic-1k.txt", baseWriteRoute + "sf/" + "mladic-1k-sf.txt");
            sf_mladic1k.Decode();
            ShannonFano sf_mladic10k = new ShannonFano(baseSourceRoute + "mladic-10k.txt", baseWriteRoute + "sf/" + "mladic-10k-sf.txt");
            sf_mladic10k.Decode();
            ShannonFano sf_mladic100k = new ShannonFano(baseSourceRoute + "mladic-100k.txt", baseWriteRoute + "sf/" + "mladic-100k-sf.txt");
            sf_mladic100k.Decode();
            ShannonFano sf_mladic1m = new ShannonFano(baseSourceRoute + "mladic-1m.txt", baseWriteRoute + "sf/" + "mladic-1m-sf.txt");
            sf_mladic1m.Decode();

            Console.WriteLine("moby-100.txt code table:");
            ShannonFano sf_moby100 = new ShannonFano(baseSourceRoute + "moby-100.txt", baseWriteRoute + "sf/" + "moby-100-sf.txt");
            sf_moby100.Decode();
            Console.WriteLine("______________________________________\n");
            ShannonFano sf_moby1k = new ShannonFano(baseSourceRoute + "moby-1k.txt", baseWriteRoute + "sf/" + "moby-1k-sf.txt");
            sf_moby1k.Decode();
            ShannonFano sf_moby10k = new ShannonFano(baseSourceRoute + "moby-10k.txt", baseWriteRoute + "sf/" + "moby-10k-sf.txt");
            sf_moby10k.Decode();
            ShannonFano sf_moby100k = new ShannonFano(baseSourceRoute + "moby-100k.txt", baseWriteRoute + "sf/" + "moby-100k-sf.txt");
            sf_moby100k.Decode();
            ShannonFano sf_moby1m = new ShannonFano(baseSourceRoute + "moby-1m.txt", baseWriteRoute + "sf/" + "moby-1m-sf.txt");
            sf_moby1m.Decode();

            Console.WriteLine("random-100.txt code table:");
            ShannonFano sf_random100 = new ShannonFano(baseSourceRoute + "random-100.txt", baseWriteRoute + "sf/" + "random-100-sf.txt");
            sf_random100.Decode();
            Console.WriteLine("______________________________________\n");
            ShannonFano sf_random1k = new ShannonFano(baseSourceRoute + "random-1k.txt", baseWriteRoute + "sf/" + "random-1k-sf.txt");
            sf_random1k.Decode();
            ShannonFano sf_random10k = new ShannonFano(baseSourceRoute + "random-10k.txt", baseWriteRoute + "sf/" + "random-10k-sf.txt");
            sf_random10k.Decode();
            ShannonFano sf_random100k = new ShannonFano(baseSourceRoute + "random-100k.txt", baseWriteRoute + "sf/" + "random-100k-sf.txt");
            sf_random100k.Decode();
            ShannonFano sf_random1m = new ShannonFano(baseSourceRoute + "random-1m.txt", baseWriteRoute + "sf/" + "random-1m-sf.txt");
            sf_random1m.Decode();

        }
    }
}
