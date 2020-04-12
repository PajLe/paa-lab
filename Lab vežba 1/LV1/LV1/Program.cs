using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV1
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseSourceRoute = "../../../../testfiles/";
            string baseWriteRoute = "../../../../results/";

            /* Patterns */
            string a5 = "about";
            string h5 = "D2E7A";
            string a10 = " whenever ";
            string h10 = "D7FF3A4021";
            string a20 = " I thought I would ";
            string h20 = "D7FF3A4021D7FF3A4021";
            string a50 = "involuntarily pausing before coffin warehouses, and";
            string h50 = "D7FF3A4021D7FF3A4021D7FF3A4021D7FF3A4021D7FF3A4021";


            #region Knuth - Morris - Pratt tests
            string baseKmpWrite = baseWriteRoute + "kmp/";
            Console.WriteLine("Knuth-Morris-Pratt");
            Console.WriteLine("_________________________________\n");
            #region Pattern 5
            KnuthMorrisPratt kmp_a5 = new KnuthMorrisPratt(a5);
            KnuthMorrisPratt kmp_h5 = new KnuthMorrisPratt(h5);

            Console.WriteLine("KMP Ascii, Pattern 5, 100 words");
            kmp_a5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-moby.txt"), baseKmpWrite + "kmp_a5_100.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 5, 1k words");
            kmp_a5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-princeton.txt"), baseKmpWrite + "kmp_a5_1k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 5, 10k words");
            kmp_a5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "11k-manifesto.txt"), baseKmpWrite + "kmp_a5_10k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 5, 100k words");
            kmp_a5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "115k-mobydick.txt"), baseKmpWrite + "kmp_a5_100k.txt");
            Console.WriteLine();

            Console.WriteLine("KMP hex, Pattern 5, 100 words");
            kmp_h5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-hex.txt"), baseKmpWrite + "kmp_h5_100.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 5, 1k words");
            kmp_h5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-hex.txt"), baseKmpWrite + "kmp_h5_1k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 5, 10k words");
            kmp_h5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "10k-hex.txt"), baseKmpWrite + "kmp_h5_10k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 5, 100k words");
            kmp_h5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100k-hex.txt"), baseKmpWrite + "kmp_h5_100k.txt");
            Console.WriteLine();
            #endregion Pattern 5
            #region Pattern 10
            KnuthMorrisPratt kmp_a10 = new KnuthMorrisPratt(a10);
            KnuthMorrisPratt kmp_h10 = new KnuthMorrisPratt(h10);

            Console.WriteLine("KMP Ascii, Pattern 10, 100 words");
            kmp_a10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-moby.txt"), baseKmpWrite + "kmp_a10_100.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 10, 1k words");
            kmp_a10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-princeton.txt"), baseKmpWrite + "kmp_a10_1k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 10, 10k words");
            kmp_a10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "11k-manifesto.txt"), baseKmpWrite + "kmp_a10_10k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 10, 100k words");
            kmp_a10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "115k-mobydick.txt"), baseKmpWrite + "kmp_a10_100k.txt");
            Console.WriteLine();

            Console.WriteLine("KMP hex, Pattern 10, 100 words");
            kmp_h10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-hex.txt"), baseKmpWrite + "kmp_h10_100.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 10, 1k words");
            kmp_h10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-hex.txt"), baseKmpWrite + "kmp_h10_1k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 10, 10k words");
            kmp_h10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "10k-hex.txt"), baseKmpWrite + "kmp_h10_10k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 10, 100k words");
            kmp_h10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100k-hex.txt"), baseKmpWrite + "kmp_h10_100k.txt");
            Console.WriteLine();
            #endregion Pattern 10
            #region Pattern 20
            KnuthMorrisPratt kmp_a20 = new KnuthMorrisPratt(a20);
            KnuthMorrisPratt kmp_h20 = new KnuthMorrisPratt(h20);

            Console.WriteLine("KMP Ascii, Pattern 20, 100 words");
            kmp_a20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-moby.txt"), baseKmpWrite + "kmp_a20_100.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 20, 1k words");
            kmp_a20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-princeton.txt"), baseKmpWrite + "kmp_a20_1k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 20, 10k words");
            kmp_a20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "11k-manifesto.txt"), baseKmpWrite + "kmp_a20_10k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 20, 100k words");
            kmp_a20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "115k-mobydick.txt"), baseKmpWrite + "kmp_a20_100k.txt");
            Console.WriteLine();

            Console.WriteLine("KMP hex, Pattern 20, 100 words");
            kmp_h20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-hex.txt"), baseKmpWrite + "kmp_h20_100.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 20, 1k words");
            kmp_h20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-hex.txt"), baseKmpWrite + "kmp_h20_1k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 20, 10k words");
            kmp_h20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "10k-hex.txt"), baseKmpWrite + "kmp_h20_10k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 20, 100k words");
            kmp_h20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100k-hex.txt"), baseKmpWrite + "kmp_h20_100k.txt");
            Console.WriteLine();
            #endregion Pattern 20
            #region Pattern 50
            KnuthMorrisPratt kmp_a50 = new KnuthMorrisPratt(a50);
            KnuthMorrisPratt kmp_h50 = new KnuthMorrisPratt(h50);

            Console.WriteLine("KMP Ascii, Pattern 50, 100 words");
            kmp_a50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-moby.txt"), baseKmpWrite + "kmp_a50_100.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 50, 1k words");
            kmp_a50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-princeton.txt"), baseKmpWrite + "kmp_a50_1k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 50, 10k words");
            kmp_a50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "11k-manifesto.txt"), baseKmpWrite + "kmp_a50_10k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP Ascii, Pattern 50, 100k words");
            kmp_a50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "115k-mobydick.txt"), baseKmpWrite + "kmp_a50_100k.txt");
            Console.WriteLine();

            Console.WriteLine("KMP hex, Pattern 50, 100 words");
            kmp_h50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-hex.txt"), baseKmpWrite + "kmp_h50_100.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 50, 1k words");
            kmp_h50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-hex.txt"), baseKmpWrite + "kmp_h50_1k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 50, 10k words");
            kmp_h50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "10k-hex.txt"), baseKmpWrite + "kmp_h50_10k.txt");
            Console.WriteLine();
            Console.WriteLine("KMP hex, Pattern 50, 100k words");
            kmp_h50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100k-hex.txt"), baseKmpWrite + "kmp_h50_100k.txt");
            Console.WriteLine();
            #endregion Pattern 50
            Console.WriteLine("_________________________________\n");
            #endregion Knuth - Morris - Pratt tests

            #region RabinKarp
            string baseRkWrite = baseWriteRoute + "rk/";
            Console.WriteLine("Rabin-Karp");
            Console.WriteLine("_________________________________\n");
            #region Pattern 5
            RabinKarp rk_a5 = new RabinKarp(a5, 256);
            RabinKarp rk_h5 = new RabinKarp(h5, 16);

            Console.WriteLine("RK Ascii, Pattern 5, 100 words");
            rk_a5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-moby.txt"), baseRkWrite + "rk_a5_100.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 5, 1k words");
            rk_a5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-princeton.txt"), baseRkWrite + "rk_a5_1k.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 5, 10k words");
            rk_a5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "11k-manifesto.txt"), baseRkWrite + "rk_a5_10k.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 5, 100k words");
            rk_a5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "115k-mobydick.txt"), baseRkWrite + "rk_a5_100k.txt");
            Console.WriteLine();

            Console.WriteLine("RK hex, Pattern 5, 100 words");
            rk_h5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-hex.txt"), baseRkWrite + "rk_h5_100.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 5, 1k words");
            rk_h5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-hex.txt"), baseRkWrite + "rk_h5_1k.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 5, 10k words");
            rk_h5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "10k-hex.txt"), baseRkWrite + "rk_h5_10k.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 5, 100k words");
            rk_h5.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100k-hex.txt"), baseRkWrite + "rk_h5_100k.txt");
            Console.WriteLine();
            #endregion Pattern 5
            #region Pattern 10
            RabinKarp rk_a10 = new RabinKarp(a10, 256);
            RabinKarp rk_h10 = new RabinKarp(h10, 16);

            Console.WriteLine("RK Ascii, Pattern 10, 100 words");
            rk_a10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-moby.txt"), baseRkWrite + "rk_a10_100.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 10, 1k words");
            rk_a10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-princeton.txt"), baseRkWrite + "rk_a10_1k.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 10, 10k words");
            rk_a10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "11k-manifesto.txt"), baseRkWrite + "rk_a10_10k.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 10, 100k words");
            rk_a10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "115k-mobydick.txt"), baseRkWrite + "rk_a10_100k.txt");
            Console.WriteLine();

            Console.WriteLine("RK hex, Pattern 10, 100 words");
            rk_h10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-hex.txt"), baseRkWrite + "rk_h10_100.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 10, 1k words");
            rk_h10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-hex.txt"), baseRkWrite + "rk_h10_1k.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 10, 10k words");
            rk_h10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "10k-hex.txt"), baseRkWrite + "rk_h10_10k.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 10, 100k words");
            rk_h10.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100k-hex.txt"), baseRkWrite + "rk_h10_100k.txt");
            Console.WriteLine();
            #endregion Pattern 10
            #region Pattern 20
            RabinKarp rk_a20 = new RabinKarp(a20, 256);
            RabinKarp rk_h20 = new RabinKarp(h20, 16);

            Console.WriteLine("RK Ascii, Pattern 20, 100 words");
            rk_a20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-moby.txt"), baseRkWrite + "rk_a20_100.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 20, 1k words");
            rk_a20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-princeton.txt"), baseRkWrite + "rk_a20_1k.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 20, 10k words");
            rk_a20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "11k-manifesto.txt"), baseRkWrite + "rk_a20_10k.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 20, 100k words");
            rk_a20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "115k-mobydick.txt"), baseRkWrite + "rk_a20_100k.txt");
            Console.WriteLine();

            Console.WriteLine("RK hex, Pattern 20, 100 words");
            rk_h20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-hex.txt"), baseRkWrite + "rk_h20_100.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 20, 1k words");
            rk_h20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-hex.txt"), baseRkWrite + "rk_h20_1k.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 20, 10k words");
            rk_h20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "10k-hex.txt"), baseRkWrite + "rk_h20_10k.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 20, 100k words");
            rk_h20.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100k-hex.txt"), baseRkWrite + "rk_h20_100k.txt");
            Console.WriteLine();
            #endregion Pattern 20
            #region Pattern 50
            RabinKarp rk_a50 = new RabinKarp(a50, 256);
            RabinKarp rk_h50 = new RabinKarp(h50, 16);

            Console.WriteLine("RK Ascii, Pattern 50, 100 words");
            rk_a50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-moby.txt"), baseRkWrite + "rk_a50_100.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 50, 1k words");
            rk_a50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-princeton.txt"), baseRkWrite + "rk_a50_1k.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 50, 10k words");
            rk_a50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "11k-manifesto.txt"), baseRkWrite + "rk_a50_10k.txt");
            Console.WriteLine();
            Console.WriteLine("RK Ascii, Pattern 50, 100k words");
            rk_a50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "115k-mobydick.txt"), baseRkWrite + "rk_a50_100k.txt");
            Console.WriteLine();

            Console.WriteLine("RK hex, Pattern 50, 100 words");
            rk_h50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100-hex.txt"), baseRkWrite + "rk_h50_100.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 50, 1k words");
            rk_h50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "1k-hex.txt"), baseRkWrite + "rk_h50_1k.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 50, 10k words");
            rk_h50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "10k-hex.txt"), baseRkWrite + "rk_h50_10k.txt");
            Console.WriteLine();
            Console.WriteLine("RK hex, Pattern 50, 100k words");
            rk_h50.SearchAll(FilesRepo.ReadAsString(baseSourceRoute + "100k-hex.txt"), baseRkWrite + "rk_h50_100k.txt");
            Console.WriteLine();
            #endregion Pattern 50
            Console.WriteLine("_________________________________\n");
            #endregion RabinKarp

            #region Levenshtein
            string baseLevenWrite = baseWriteRoute + "leven/";
            Console.WriteLine("Levenshtein");
            Console.WriteLine("_________________________________\n");
            #region Pattern 5
            Levenshtein lev_a5 = new Levenshtein(a5);
            Levenshtein lev_h5 = new Levenshtein(h5);

            Console.WriteLine("Leven Ascii, Pattern 5, 100 words");
            lev_a5.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-moby.txt"), baseLevenWrite + "lev_a5_100.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 5, 1k words");
            lev_a5.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-princeton.txt"), baseLevenWrite + "lev_a5_1k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 5, 10k words");
            lev_a5.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "11k-manifesto.txt"), baseLevenWrite + "lev_a5_10k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 5, 100k words");
            lev_a5.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "115k-mobydick.txt"), baseLevenWrite + "lev_a5_100k.txt");
            Console.WriteLine();

            Console.WriteLine("Leven hex, Pattern 5, 100 words");
            lev_h5.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-hex.txt"), baseLevenWrite + "lev_h5_100.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 5, 1k words");
            lev_h5.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-hex.txt"), baseLevenWrite + "lev_h5_1k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 5, 10k words");
            lev_h5.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "10k-hex.txt"), baseLevenWrite + "lev_h5_10k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 5, 100k words");
            lev_h5.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100k-hex.txt"), baseLevenWrite + "lev_h5_100k.txt");
            Console.WriteLine();
            #endregion Pattern 5
            #region Pattern 10
            Levenshtein lev_a10 = new Levenshtein(a10);
            Levenshtein lev_h10 = new Levenshtein(h10);

            Console.WriteLine("Leven Ascii, Pattern 10, 100 words");
            lev_a10.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-moby.txt"), baseLevenWrite + "lev_a10_100.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 10, 1k words");
            lev_a10.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-princeton.txt"), baseLevenWrite + "lev_a10_1k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 10, 10k words");
            lev_a10.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "11k-manifesto.txt"), baseLevenWrite + "lev_a10_10k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 10, 100k words");
            lev_a10.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "115k-mobydick.txt"), baseLevenWrite + "lev_a10_100k.txt");
            Console.WriteLine();

            Console.WriteLine("Leven hex, Pattern 10, 100 words");
            lev_h10.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-hex.txt"), baseLevenWrite + "lev_h10_100.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 10, 1k words");
            lev_h10.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-hex.txt"), baseLevenWrite + "lev_h10_1k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 10, 10k words");
            lev_h10.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "10k-hex.txt"), baseLevenWrite + "lev_h10_10k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 10, 100k words");
            lev_h10.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100k-hex.txt"), baseLevenWrite + "lev_h10_100k.txt");
            Console.WriteLine();
            #endregion Pattern 10
            #region Pattern 20
            Levenshtein lev_a20 = new Levenshtein("akfmeidjfuwnvlxcopwq");
            Levenshtein lev_h20 = new Levenshtein(h20);

            Console.WriteLine("Leven Ascii, Pattern 20, 100 words");
            lev_a20.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-moby.txt"), baseLevenWrite + "lev_a20_100.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 20, 1k words");
            lev_a20.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-princeton.txt"), baseLevenWrite + "lev_a20_1k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 20, 10k words");
            lev_a20.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "11k-manifesto.txt"), baseLevenWrite + "lev_a20_10k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 20, 100k words");
            lev_a20.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "115k-mobydick.txt"), baseLevenWrite + "lev_a20_100k.txt");
            Console.WriteLine();

            Console.WriteLine("Leven hex, Pattern 20, 100 words");
            lev_h20.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-hex.txt"), baseLevenWrite + "lev_h20_100.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 20, 1k words");
            lev_h20.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-hex.txt"), baseLevenWrite + "lev_h20_1k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 20, 10k words");
            lev_h20.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "10k-hex.txt"), baseLevenWrite + "lev_h20_10k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 20, 100k words");
            lev_h20.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100k-hex.txt"), baseLevenWrite + "lev_h20_100k.txt");
            Console.WriteLine();
            #endregion Pattern 20
            #region Pattern 50
            Levenshtein lev_a50 = new Levenshtein("akfmeidjfuwnvlxcopwqakfmeidjfuwnvlxcopwqxcopwqakfm");
            Levenshtein lev_h50 = new Levenshtein(h50);

            Console.WriteLine("Leven Ascii, Pattern 50, 100 words");
            lev_a50.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-moby.txt"), baseLevenWrite + "lev_a50_100.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 50, 1k words");
            lev_a50.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-princeton.txt"), baseLevenWrite + "lev_a50_1k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 50, 10k words");
            lev_a50.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "11k-manifesto.txt"), baseLevenWrite + "lev_a50_10k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven Ascii, Pattern 50, 100k words");
            lev_a50.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "115k-mobydick.txt"), baseLevenWrite + "lev_a50_100k.txt");
            Console.WriteLine();

            Console.WriteLine("Leven hex, Pattern 50, 100 words");
            lev_h50.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-hex.txt"), baseLevenWrite + "lev_h50_100.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 50, 1k words");
            lev_h50.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-hex.txt"), baseLevenWrite + "lev_h50_1k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 50, 10k words");
            lev_h50.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "10k-hex.txt"), baseLevenWrite + "lev_h50_10k.txt");
            Console.WriteLine();
            Console.WriteLine("Leven hex, Pattern 50, 100k words");
            lev_h50.FindAllWithLD3(FilesRepo.ReadAsStringArray(baseSourceRoute + "100k-hex.txt"), baseLevenWrite + "lev_h50_100k.txt");
            Console.WriteLine();
            #endregion Pattern 50
            Console.WriteLine("_________________________________\n");
            #endregion Levenshtein

            #region SoundEx
            string baseSoundExWrite = baseWriteRoute + "sndx/";
            Console.WriteLine("SoundEx");
            Console.WriteLine("_________________________________\n");
            #region Pattern 5
            SoundEx sndx_a5 = new SoundEx(a5);

            Console.WriteLine("SoundEx, Pattern 5, 100 words");
            sndx_a5.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-moby.txt"), baseSoundExWrite + "sndx_a5_100.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 5, 1k words");
            sndx_a5.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-princeton.txt"), baseSoundExWrite + "sndx_a5_1k.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 5, 10k words");
            sndx_a5.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "11k-manifesto.txt"), baseSoundExWrite + "sndx_a5_10k.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 5, 100k words");
            sndx_a5.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "115k-mobydick.txt"), baseSoundExWrite + "sndx_a5_100k.txt");
            Console.WriteLine();

            #endregion Pattern 5
            #region Pattern 10
            SoundEx sndx_a10 = new SoundEx("xcopwqakfm");

            Console.WriteLine("SoundEx, Pattern 10, 100 words");
            sndx_a10.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-moby.txt"), baseSoundExWrite + "sndx_a10_100.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 10, 1k words");
            sndx_a10.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-princeton.txt"), baseSoundExWrite + "sndx_a10_1k.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 10, 10k words");
            sndx_a10.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "11k-manifesto.txt"), baseSoundExWrite + "sndx_a10_10k.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 10, 100k words");
            sndx_a10.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "115k-mobydick.txt"), baseSoundExWrite + "sndx_a10_100k.txt");
            Console.WriteLine();

            #endregion Pattern 10
            #region Pattern 20
            SoundEx sndx_a20 = new SoundEx("akfmeidjfuwnvlxcopwq");

            Console.WriteLine("SoundEx, Pattern 20, 100 words");
            sndx_a20.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-moby.txt"), baseSoundExWrite + "sndx_a20_100.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 20, 1k words");
            sndx_a20.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-princeton.txt"), baseSoundExWrite + "sndx_a20_1k.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 20, 10k words");
            sndx_a20.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "11k-manifesto.txt"), baseSoundExWrite + "sndx_a20_10k.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 20, 100k words");
            sndx_a20.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "115k-mobydick.txt"), baseSoundExWrite + "sndx_a20_100k.txt");
            Console.WriteLine();
            #endregion Pattern 20
            #region Pattern 50
            SoundEx sndx_a50 = new SoundEx("akfmeidjfuwnvlxcopwqakfmeidjfuwnvlxcopwqxcopwqakfm");

            Console.WriteLine("SoundEx, Pattern 50, 100 words");
            sndx_a50.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "100-moby.txt"), baseSoundExWrite + "sndx_a50_100.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 50, 1k words");
            sndx_a50.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "1k-princeton.txt"), baseSoundExWrite + "sndx_a50_1k.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 50, 10k words");
            sndx_a50.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "11k-manifesto.txt"), baseSoundExWrite + "sndx_a50_10k.txt");
            Console.WriteLine();
            Console.WriteLine("SoundEx, Pattern 50, 100k words");
            sndx_a50.SearchAllEqualCodes(FilesRepo.ReadAsStringArray(baseSourceRoute + "115k-mobydick.txt"), baseSoundExWrite + "sndx_a50_100k.txt");

            Console.WriteLine();
            #endregion Pattern 50
            Console.WriteLine("_________________________________\n");
            #endregion SoundEx
        }
    }
}
