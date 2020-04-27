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
        private System.Collections.BitArray ba;

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

        public void WriteIntBits(uint value, uint numOfBits)
        {
            ba = new BitArray(BitConverter.GetBytes(value));
            for (sbyte i = (sbyte)(numOfBits - 1); i >= 0; i--)
            {
                //Console.WriteLine(ba[i]);
                this.Write(ba[i]);
            }
            ba = null;
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

        public uint ReadUintBits(uint numOfBits)
        {
            uint num = 0;
            for (int i = 0; i < numOfBits; i++)
            {
                num <<= 1;
                bool bit = ReadBoolean();
                if (bit) num |= 1;
            }
            return num;
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

    /*
     * Java style code
     */
    internal class Node<Value>
    {
        public char c;                        // character
        public Node<Value> left, mid, right;  // left, middle, and right subtries
        public Value val;                     // value associated with string
    }

    internal class TST<Value>
    {
        private int n;              // size
        private Node<Value> root;   // root of TST


        /**
         * Initializes an empty string symbol table.
         */
        public TST()
        {
        }

        public int size()
        {
            return n;
        }

        public String longestPrefixOf(String query)
        {
            /*if (query == null)
                throw new ArgumentNullException("calls longestPrefixOf() with null argument");
            
            if (query.Length == 0) return null;*/
            int length = 0;
            Node<Value> x = root;
            int i = 0;
            while (x != null && i < query.Length)
            {
                char c = query[i];
                if (c < x.c) x = x.left;
                else if (c > x.c) x = x.right;
                else
                {
                    i++;
                    if (x.val != null) length = i;
                    x = x.mid;
                }
            }
            return query.Substring(0, length);
        }

        public void put(String key, Value val)
        {
            if (key == null)
            {
                throw new ArgumentNullException("calls put() with null key");
            }
            if (!contains(key)) n++;
            else if (val == null) n--;       // delete existing key
            root = put(root, key, val, 0);
        }

        private Node<Value> put(Node<Value> x, String key, Value val, int d)
        {
            char c = key[d];
            if (x == null)
            {
                x = new Node<Value>();
                x.c = c;
            }
            if (c < x.c) x.left = put(x.left, key, val, d);
            else if (c > x.c) x.right = put(x.right, key, val, d);
            else if (d < key.Length - 1) x.mid = put(x.mid, key, val, d + 1);
            else x.val = val;
            return x;
        }

        public bool contains(String key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("argument to contains() is null");
            }
            return get(key) != null;
        }

        public Value get(String key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("calls get() with null argument");
            }
            if (key.Length == 0) throw new ArgumentNullException("key must have length >= 1");
            Node<Value> x = get(root, key, 0);
            if (x == null) return default(Value);
            return x.val;
        }

        // return subtrie corresponding to given key
        private Node<Value> get(Node<Value> x, String key, int d)
        {
            if (x == null) return null;
            if (key.Length == 0) throw new ArgumentNullException("key must have length >= 1");
            char c = key[d];
            if (c < x.c) return get(x.left, key, d);
            else if (c > x.c) return get(x.right, key, d);
            else if (d < key.Length - 1) return get(x.mid, key, d + 1);
            else return x;
        }
    }
}
