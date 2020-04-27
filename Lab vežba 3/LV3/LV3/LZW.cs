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
        private static readonly uint R = 256;         // ascii size
        private static readonly int L = 65536;        // number of codewords = 2^W
        private static readonly uint W = 16;          // codeword width
        private string _fileToDecode;                 // encoded file's name (file is to be decoded)

        public LZW(string inputFileName, string outputFileName)
        {
            _fileToDecode = outputFileName;

            using (StreamReader sr = new StreamReader(File.Open(inputFileName, FileMode.Open)))
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(outputFileName, FileMode.Create)))
                {
                    TST<uint> st = new TST<uint>();
                    string input = sr.ReadToEnd();
                    for (uint i = 0; i < R; i++)
                        st.put("" + (char)i, i);
                    uint code = R + 1;  // R is codeword for EOF

                    int inputStartIndex = 0;
                    while(input.Length > inputStartIndex)
                    {
                        string s = st.longestPrefixOf(input, inputStartIndex); // Find max prefix match s.
                        bw.WriteIntBits(st.get(s), W); // Print s's code.
                        int t = s.Length;
                        if (t < input.Length && code < L) 
                            st.put(input.Substring(inputStartIndex, t + 1), code++); // Add s to symbol table.

                        inputStartIndex += t; // instead of the slow substring operation
                    }

                    bw.WriteIntBits(R, W);
                }
            }
        }

        public void Decode()
        {
            using (BinaryReader br = new BinaryReader(File.Open(_fileToDecode, FileMode.Open)))
            {
                using (StreamWriter sw = new StreamWriter(File.Open(_fileToDecode.Substring(0, _fileToDecode.Length - 4) + "-decoded.txt", FileMode.Create)))
                {
                    string[] st = new string[L];
                    uint i; // next available codeword value

                    // initialize symbol table with all 1-character strings
                    for (i = 0; i < R; i++)
                        st[i] = "" + (char)i;
                    st[i++] = ""; // st[R] - (unused) - lookahead for EOF

                    uint codeword = br.ReadUintBits(W);
                    if (codeword == R) return;
                    string val = st[codeword];

                    while (true)
                    {
                        sw.Write(val);
                        codeword = br.ReadUintBits(W);
                        if (codeword == R) break;
                        string s = st[codeword];
                        if (i == codeword) s = val + val[0];   // special case hack
                        if (i < L) st[i++] = val + s[0];
                        val = s;
                    }
                }
            }
        }

    }
}
