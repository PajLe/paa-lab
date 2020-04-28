using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            Stopwatch s = new Stopwatch();

            FileRepo.GenerateAsciiFile("random-100.txt", 100);
            FileRepo.GenerateAsciiFile("random-1k.txt", 1000);
            FileRepo.GenerateAsciiFile("random-10k.txt", 10000);
            FileRepo.GenerateAsciiFile("random-100k.txt", 100000);
            FileRepo.GenerateAsciiFile("random-1m.txt", 1000000);*/

            /*Console.WriteLine("sf mladic-100.txt");
            Console.WriteLine("mladic-100.txt code table:");
            s.Start();
            ShannonFano sf_mladic100 = new ShannonFano(baseSourceRoute + "mladic-100.txt", baseWriteRoute + "sf/" + "mladic-100-sf.txt");
            sf_mladic100.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf mladic-1k.txt");
            s.Start();
            ShannonFano sf_mladic1k = new ShannonFano(baseSourceRoute + "mladic-1k.txt", baseWriteRoute + "sf/" + "mladic-1k-sf.txt");
            sf_mladic1k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf mladic-10k.txt");
            s.Start();
            ShannonFano sf_mladic10k = new ShannonFano(baseSourceRoute + "mladic-10k.txt", baseWriteRoute + "sf/" + "mladic-10k-sf.txt");
            sf_mladic10k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf mladic-100k.txt");
            s.Start();
            ShannonFano sf_mladic100k = new ShannonFano(baseSourceRoute + "mladic-100k.txt", baseWriteRoute + "sf/" + "mladic-100k-sf.txt");
            sf_mladic100k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf mladic-1m.txt");
            s.Start();
            ShannonFano sf_mladic1m = new ShannonFano(baseSourceRoute + "mladic-1m.txt", baseWriteRoute + "sf/" + "mladic-1m-sf.txt");
            sf_mladic1m.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();
            Console.WriteLine("______________________________________\n");
            Console.WriteLine("______________________________________\n");

            Console.WriteLine("sf moby-100.txt");
            Console.WriteLine("moby-100.txt code table:");
            s.Start();
            ShannonFano sf_moby100 = new ShannonFano(baseSourceRoute + "moby-100.txt", baseWriteRoute + "sf/" + "moby-100-sf.txt");
            sf_moby100.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf moby-1k.txt");
            s.Start();
            ShannonFano sf_moby1k = new ShannonFano(baseSourceRoute + "moby-1k.txt", baseWriteRoute + "sf/" + "moby-1k-sf.txt");
            sf_moby1k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf moby-10k.txt");
            s.Start();
            ShannonFano sf_moby10k = new ShannonFano(baseSourceRoute + "moby-10k.txt", baseWriteRoute + "sf/" + "moby-10k-sf.txt");
            sf_moby10k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf moby-100k.txt");
            s.Start();
            ShannonFano sf_moby100k = new ShannonFano(baseSourceRoute + "moby-100k.txt", baseWriteRoute + "sf/" + "moby-100k-sf.txt");
            sf_moby100k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf moby-1m.txt");
            s.Start();
            ShannonFano sf_moby1m = new ShannonFano(baseSourceRoute + "moby-1m.txt", baseWriteRoute + "sf/" + "moby-1m-sf.txt");
            sf_moby1m.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();
            Console.WriteLine("______________________________________\n");
            Console.WriteLine("______________________________________\n");

            Console.WriteLine("sf random-100.txt");
            Console.WriteLine("random-100.txt code table:");
            s.Start();
            ShannonFano sf_random100 = new ShannonFano(baseSourceRoute + "random-100.txt", baseWriteRoute + "sf/" + "random-100-sf.txt");
            sf_random100.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf random-1k.txt");
            s.Start();
            ShannonFano sf_random1k = new ShannonFano(baseSourceRoute + "random-1k.txt", baseWriteRoute + "sf/" + "random-1k-sf.txt");
            sf_random1k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf random-10k.txt");
            s.Start();
            ShannonFano sf_random10k = new ShannonFano(baseSourceRoute + "random-10k.txt", baseWriteRoute + "sf/" + "random-10k-sf.txt");
            sf_random10k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf random-100k.txt");
            s.Start();
            ShannonFano sf_random100k = new ShannonFano(baseSourceRoute + "random-100k.txt", baseWriteRoute + "sf/" + "random-100k-sf.txt");
            sf_random100k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("sf random-1m.txt");
            s.Start();
            ShannonFano sf_random1m = new ShannonFano(baseSourceRoute + "random-1m.txt", baseWriteRoute + "sf/" + "random-1m-sf.txt");
            sf_random1m.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("\n\n\n______________________________________");
            Console.Write("______________________________________\n\n\n");

            Console.WriteLine("lzw mladic-100.txt");
            Console.WriteLine("mladic-100.txt code table:");
            s.Start();
            LZW lzw_mladic100 = new LZW(baseSourceRoute + "mladic-100.txt", baseWriteRoute + "lzw/" + "mladic-100-lzw.txt");
            lzw_mladic100.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw mladic-1k.txt");
            s.Start();
            LZW lzw_mladic1k = new LZW(baseSourceRoute + "mladic-1k.txt", baseWriteRoute + "lzw/" + "mladic-1k-lzw.txt");
            lzw_mladic1k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw mladic-10k.txt");
            s.Start();
            LZW lzw_mladic10k = new LZW(baseSourceRoute + "mladic-10k.txt", baseWriteRoute + "lzw/" + "mladic-10k-lzw.txt");
            lzw_mladic10k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw mladic-100k.txt");
            s.Start();
            LZW lzw_mladic100k = new LZW(baseSourceRoute + "mladic-100k.txt", baseWriteRoute + "lzw/" + "mladic-100k-lzw.txt");
            lzw_mladic100k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw mladic-1m.txt");
            s.Start();
            LZW lzw_mladic1m = new LZW(baseSourceRoute + "mladic-1m.txt", baseWriteRoute + "lzw/" + "mladic-1m-lzw.txt");
            lzw_mladic1m.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();
            Console.WriteLine("______________________________________\n");
            Console.WriteLine("______________________________________\n");

            Console.WriteLine("lzw moby-100.txt");
            Console.WriteLine("moby-100.txt code table:");
            s.Start();
            LZW lzw_moby100 = new LZW(baseSourceRoute + "moby-100.txt", baseWriteRoute + "lzw/" + "moby-100-lzw.txt");
            lzw_moby100.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw moby-1k.txt");
            s.Start();
            LZW lzw_moby1k = new LZW(baseSourceRoute + "moby-1k.txt", baseWriteRoute + "lzw/" + "moby-1k-lzw.txt");
            lzw_moby1k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw moby-10k.txt");
            s.Start();
            LZW lzw_moby10k = new LZW(baseSourceRoute + "moby-10k.txt", baseWriteRoute + "lzw/" + "moby-10k-lzw.txt");
            lzw_moby10k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw moby-100k.txt");
            s.Start();
            LZW lzw_moby100k = new LZW(baseSourceRoute + "moby-100k.txt", baseWriteRoute + "lzw/" + "moby-100k-lzw.txt");
            lzw_moby100k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw moby-1m.txt");
            s.Start();
            LZW lzw_moby1m = new LZW(baseSourceRoute + "moby-1m.txt", baseWriteRoute + "lzw/" + "moby-1m-lzw.txt");
            lzw_moby1m.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();
            Console.WriteLine("______________________________________\n");
            Console.WriteLine("______________________________________\n");

            Console.WriteLine("lzw random-100.txt");
            Console.WriteLine("random-100.txt code table:");
            s.Start();
            LZW lzw_random100 = new LZW(baseSourceRoute + "random-100.txt", baseWriteRoute + "lzw/" + "random-100-lzw.txt");
            lzw_random100.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw random-1k.txt");
            s.Start();
            LZW lzw_random1k = new LZW(baseSourceRoute + "random-1k.txt", baseWriteRoute + "lzw/" + "random-1k-lzw.txt");
            lzw_random1k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw random-10k.txt");
            s.Start();
            LZW lzw_random10k = new LZW(baseSourceRoute + "random-10k.txt", baseWriteRoute + "lzw/" + "random-10k-lzw.txt");
            lzw_random10k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw random-100k.txt");
            s.Start();
            LZW lzw_random100k = new LZW(baseSourceRoute + "random-100k.txt", baseWriteRoute + "lzw/" + "random-100k-lzw.txt");
            lzw_random100k.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();

            Console.WriteLine("lzw random-1m.txt");
            s.Start();
            LZW lzw_random1m = new LZW(baseSourceRoute + "random-1m.txt", baseWriteRoute + "lzw/" + "random-1m-lzw.txt");
            lzw_random1m.Decode();
            Console.WriteLine(s.Elapsed + "\n");
            s.Reset();
            Console.WriteLine("______________________________________\n");
            Console.WriteLine("______________________________________\n");
        }
    }
}
