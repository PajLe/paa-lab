using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV3
{
    internal class SFNode
    {
        public char? Char { get; set; }
        public SFNode Left { get; set; }
        public SFNode Right { get; set; }
    }

    internal class SFDecodeTree
    {
        private SFNode root;
        private SFNode current;

        public SFNode Current { get => current; set => current = value; }
        public SFNode Root { get => root; }

        public SFDecodeTree()
        {
            root = new SFNode();
            Current = Root;
        }

        public void GoLeft()
        {
            Current = Current.Left;
        }

        public void GoRight()
        {
            Current = Current.Right;
        }

        public void ResetTraverse()
        {
            Current = Root;
        }
    }

    internal class BinaryWriter : System.IO.BinaryWriter
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

    internal class BinaryReader : System.IO.BinaryReader
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
