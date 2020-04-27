using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV3
{
    class LZW
    {
        private static readonly uint R = 256;        // number of input chars
        private static readonly int L = 65536;        // number of codewords = 2^W
        private static readonly uint W = 16;         // codeword width
        private string _fileToDecode;

        public LZW(string inputFileName, string outputFileName)
        {
            _fileToDecode = outputFileName;
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch shortestPrefix = new Stopwatch();
            Stopwatch writeIntBits = new Stopwatch();
            Stopwatch addToST = new Stopwatch();
            Stopwatch scanPastInput = new Stopwatch();
            TimeSpan totalShortestPrefix = new TimeSpan();
            TimeSpan totalWriteIntBits = new TimeSpan();
            TimeSpan totalAddToST = new TimeSpan();
            TimeSpan totalScanPastInput = new TimeSpan();

            stopwatch.Start();
            Console.WriteLine("LZW started");
            int charsGone = 0;

            using (StreamReader sr = new StreamReader(File.Open(inputFileName, FileMode.Open)))
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(outputFileName, FileMode.Create)))
                {
                    TST<uint> st = new TST<uint>();
                    String input = sr.ReadToEnd();
                    for (uint i = 0; i < R; i++)
                        st.put("" + (char)i, i);
                    uint code = R + 1;  // R is codeword for EOF

                    while(input.Length > 0)
                    {
                        if (charsGone > 50000)
                        {
                            charsGone = 0;
                            Console.WriteLine("50k more elements: " + stopwatch.Elapsed);
                        }
                        shortestPrefix.Start();
                        String s = st.longestPrefixOf(input); // Find max prefix match s.
                        shortestPrefix.Stop();
                        totalShortestPrefix = totalShortestPrefix.Add(shortestPrefix.Elapsed);
                        shortestPrefix.Reset();

                        charsGone += s.Length;

                        writeIntBits.Start();
                        bw.WriteIntBits(st.get(s), W);        // Print s's encoding.
                        writeIntBits.Stop();
                        totalWriteIntBits = totalWriteIntBits.Add(writeIntBits.Elapsed);
                        writeIntBits.Reset();

                        int t = s.Length;

                        if (t < input.Length && code < L) {
                            addToST.Start();
                            st.put(input.Substring(0, t + 1), code++);
                            addToST.Stop();
                            totalAddToST = totalAddToST.Add(addToST.Elapsed);
                            addToST.Reset();
                        }    // Add s to symbol table.

                        scanPastInput.Start();
                        input = input.Substring(t);           // Scan past s in input.
                        scanPastInput.Stop();
                        totalScanPastInput = totalScanPastInput.Add(scanPastInput.Elapsed);
                        scanPastInput.Reset();
                    }

                    bw.WriteIntBits(R, W);
                }
            }
            Console.WriteLine("Total shortest prefix time: " + totalShortestPrefix);
            Console.WriteLine("Total write int bits time:  " + totalWriteIntBits);
            Console.WriteLine("Total add to ST time:       " + totalAddToST);
            Console.WriteLine("Total scan past input time: " + totalScanPastInput);

        }

        public void Decode()
        {
            using (BinaryReader br = new BinaryReader(File.Open(_fileToDecode, FileMode.Open)))
            {
                using (StreamWriter sw = new StreamWriter(File.Open("decoded.txt", FileMode.Create)))
                {
                    String[] st = new String[L];
                    uint i; // next available codeword value

                    // initialize symbol table with all 1-character strings
                    for (i = 0; i < R; i++)
                        st[i] = "" + (char)i;
                    st[i++] = ""; // (unused) lookahead for EOF

                    uint codeword = br.ReadUintBits(W);
                    if (codeword == R) return;
                    String val = st[codeword];

                    while (true)
                    {
                        sw.Write(val);
                        codeword = br.ReadUintBits(W);
                        if (codeword == R) break;
                        String s = st[codeword];
                        if (i == codeword) s = val + val[0];   // special case hack
                        if (i < L) st[i++] = val + s[0];
                        val = s;
                    }
                }
            }
        }

        public static void Decode(string fileName)
        {
            using (BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open("decoded.txt", FileMode.Create)))
                {
                    String[] st = new String[L];
                    uint i; // next available codeword value

                    // initialize symbol table with all 1-character strings
                    for (i = 0; i < R; i++)
                        st[i] = "" + (char)i;
                    st[i++] = ""; // (unused) lookahead for EOF

                    uint codeword = br.ReadUintBits(W);
                    if (codeword == R) return;
                    String val = st[codeword];

                    while (true)
                    {
                        //if (!string.IsNullOrEmpty(val))
                            bw.Write(val);
                        codeword = br.ReadUintBits(W);
                        if (codeword == R) break;
                        String s = st[codeword];
                        if (i == codeword)
                            s = val + val[0];   // special case hack
                        /*if (i == L)
                            i = R + 1;*/
                        if (i < L)
                            st[i++] = val + s[0];
                        val = s;
                    }
                }
            }
        }
    }
}
