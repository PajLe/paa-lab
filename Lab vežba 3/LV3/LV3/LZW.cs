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
        private static readonly uint R = 256;         // ascii + latin
        private static readonly int L = 65536;        // number of codewords = 2^W
        private static readonly uint W = 16;          // codeword width
        private string _fileToDecode;                 // encoded file's name (file is to be decoded)
        private int _inputLength;

        public LZW(string inputFileName, string outputFileName)
        {
            _fileToDecode = outputFileName;

            using (BinaryReader br = new BinaryReader(File.Open(inputFileName, FileMode.Open)))
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(outputFileName, FileMode.Create)))
                {
                    TST<uint> st = new TST<uint>();
                    StringBuilder inputChars = new StringBuilder();
                    //br.BaseStream.Position = 0;
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        inputChars.Append(Convert.ToChar(br.ReadByte()));
                    }
                    string input = inputChars.ToString(); 
                    _inputLength = input.Length;

                    for (uint i = 0; i < R; i++)
                        st.put("" + (char)i, i);
                    uint code = R + 1;  // R is codeword for EOF

                    int inputStartIndex = 0;
                    while(_inputLength > inputStartIndex)
                    {
                        string s = st.longestPrefixOf(input, inputStartIndex); // Find max prefix match s.

                        bw.WriteIntBits(st.get(s), W); // Print s's code.
                        int t = s.Length;
                        if (t < _inputLength - inputStartIndex && code < L) 
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
                using (BinaryWriter bw = new BinaryWriter(File.Open(_fileToDecode.Substring(0, _fileToDecode.Length - 4) + "-decoded.txt", FileMode.Create), Encoding.UTF8))
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
                        foreach (char c in val)
                        {
                            bw.Write(Convert.ToByte(c));
                        }
                        codeword = br.ReadUintBits(W);
                        if (codeword == R) break;
                        string s = st[codeword];
                        if (i == codeword) s = val + val[0];   // special case hack
                        if (i < L) st[i++] = val + s[0];
                        val = s;
                    }

                    if (_inputLength < 1000)
                    {
                        for (int ind = 0; ind < st.Length; ind++)
                        {
                            if (ind > R && string.IsNullOrEmpty(st[ind]))
                                break;

                            Console.WriteLine($"[{st[ind]}, {ind}]");
                        }
                    }
                }
            }
        }

    }
}
