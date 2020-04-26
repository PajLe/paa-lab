using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV3
{
    class ShannonFano
    {
        private Dictionary<char, int> _charOccurrencePair;
        private List<KeyValuePair<char, int>> _sortedCharsByOccurrence;
        private int _sumOfOccurrences;
        private SFDecodeTree _decodeTree;
        private Dictionary<char, string> _charCodePair;
        private string _fileToDecode;

        public ShannonFano(string inputFileName, string outputFileName)
        {
            if (!File.Exists(inputFileName))
                throw new ArgumentException("File " + inputFileName + "doesn't exist");

            _charOccurrencePair = new Dictionary<char, int>();
            _sumOfOccurrences = 0;
            _decodeTree = new SFDecodeTree();
            _charCodePair = new Dictionary<char, string>();
            _fileToDecode = outputFileName;

            FillDictionaryWithOccurrences(inputFileName);
            _sortedCharsByOccurrence = _charOccurrencePair.ToList();
            _sortedCharsByOccurrence.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            
            Compress(0, _sortedCharsByOccurrence.Count - 1, _sumOfOccurrences, "", _decodeTree.Root);
            WriteEncoded(inputFileName, outputFileName);
        }

        public void Decode()
        {
            using (BinaryReader br = new BinaryReader(File.Open(_fileToDecode, FileMode.Open)))
            {
                using (StreamWriter sw = new StreamWriter(File.Open(_fileToDecode.Substring(0,_fileToDecode.Length - 4) + "-decoded.txt", FileMode.Create)))
                {
                    _decodeTree.ResetTraverse();
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        bool bit = br.ReadBoolean();
                        if (bit)
                            _decodeTree.GoRight();
                        else
                            _decodeTree.GoLeft();

                        if (_decodeTree.Current.Char != null)
                        {
                            sw.Write(_decodeTree.Current.Char);
                            _decodeTree.ResetTraverse();
                        }
                    }
                }
            }
        }

        private void WriteEncoded(string inputFileName, string outputFileName)
        {
            using (BinaryReader br = new BinaryReader(File.Open(inputFileName, FileMode.Open)))
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(outputFileName, FileMode.Create)))
                {
                    if (br.BaseStream.Length < 1000)
                        foreach(var item in _charCodePair)
                            Console.WriteLine(item);

                    br.BaseStream.Position = 0;
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        char c = br.ReadChar();
                        foreach (char ch in _charCodePair[c])
                        {
                            string s;
                            if (ch == '0') s = "false";
                            else s = "true";
                            bw.Write(bool.Parse(s));
                        }
                    }
                    bw.Flush();
                }
            }
        }

        private void Compress(int leftIndex, int rightIndex, int sumOfOccurrences, string code, SFNode node)
        {
            if (leftIndex == rightIndex) // one character
            {
                char c = _sortedCharsByOccurrence[leftIndex].Key;
                node.Char = c;
                _charCodePair[c] = code;
                return;
            }

            int i = SplitOccurrences(leftIndex, rightIndex, sumOfOccurrences, out int leftSideOccurrences, out int rightSideOccurrences);            

            if (node.Left == null) node.Left = new SFNode();
            Compress(leftIndex, i - 1, leftSideOccurrences, code + "0", node.Left);
            if (node.Right == null) node.Right= new SFNode();
            Compress(i, rightIndex, rightSideOccurrences, code + "1", node.Right);
        }

        private int SplitOccurrences(int leftIndex, int rightIndex, int sumOfOccurrences, out int leftOccurrence, out int rightOccurrence)
        {
            leftOccurrence = _sortedCharsByOccurrence[leftIndex].Value;
            rightOccurrence = sumOfOccurrences - leftOccurrence;
            int minSideOccurrenceDifference = rightOccurrence - leftOccurrence;

            int i; // split index, included in right side
            for (i = leftIndex + 1; i <= rightIndex; i++)
            {
                leftOccurrence += _sortedCharsByOccurrence[i].Value;
                rightOccurrence -= _sortedCharsByOccurrence[i].Value;
                int sideOccurrenceDifference = Math.Abs(rightOccurrence - leftOccurrence);
                if (sideOccurrenceDifference < minSideOccurrenceDifference)
                {
                    minSideOccurrenceDifference = sideOccurrenceDifference;
                }
                else
                {
                    // revert:
                    leftOccurrence -= _sortedCharsByOccurrence[i].Value;
                    rightOccurrence += _sortedCharsByOccurrence[i].Value;
                    break;
                }
            }

            return i;
        }

        private void FillDictionaryWithOccurrences(string inputFileName)
        {
            using (BinaryReader br = new BinaryReader(File.Open(inputFileName, FileMode.Open)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    char c = br.ReadChar();
                    _sumOfOccurrences++;
                    if (_charOccurrencePair.ContainsKey(c))
                        _charOccurrencePair[c]++;
                    else
                    {
                        _charOccurrencePair.Add(c, 1);
                        _charCodePair.Add(c, "");
                    }
                }
            }
        }

        private class BinaryWriter : System.IO.BinaryWriter
        {
            private bool[] curByte = new bool[8];
            private byte curBitIndx = 0;

            public BinaryWriter(Stream s) : base(s) { }

            public override void Flush()
            {
                base.Write(ConvertToByte(curByte));
                base.Flush();
            }

            public override void Write(bool value)
            {
                curByte[curBitIndx] = value;
                curBitIndx++;

                if (curBitIndx == 8)
                {
                    base.Write(ConvertToByte(curByte));
                    this.curBitIndx = 0;
                    this.curByte = new bool[8];
                }
            }

            private static byte ConvertToByte(bool[] bools)
            {
                byte b = 0;

                byte bitIndex = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (bools[i])
                    {
                        b |= (byte)(((byte)1) << bitIndex);
                    }
                    bitIndex++;
                }

                return b;
            }
        }

        private class BinaryReader : System.IO.BinaryReader
        {
            private bool[] curByte = new bool[8];
            private byte curBitIndx = 0;
            private BitArray ba;

            public BinaryReader(Stream s) : base(s)
            {
                ba = new BitArray(new byte[] { base.ReadByte() });
                ba.CopyTo(curByte, 0);
                ba = null;
            }

            public override bool ReadBoolean()
            {
                if (curBitIndx == 8)
                {
                    ba = new BitArray(new byte[] { base.ReadByte() });
                    ba.CopyTo(curByte, 0);
                    ba = null;
                    this.curBitIndx = 0;
                }

                bool b = curByte[curBitIndx];
                curBitIndx++;
                return b;
            }
        }
    }
}
