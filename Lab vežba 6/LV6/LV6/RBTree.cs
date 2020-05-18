using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV6
{
    class RBTree
    {
        private static readonly bool RED   = true;
        private static readonly bool BLACK = false;

        private RBNode root;

        private class RBNode
        {
            public int Key { get; set; }
            public RBNode Left { get; set; }
            public RBNode Right { get; set; }
            public int Size { get; set; }
            public bool Color { get; set; }

            public RBNode(int key, bool color, int size)
            {
                this.Key = key;
                this.Color = color;
                this.Size = size;
            }
        }

        private bool IsRed(RBNode x) { if (x == null) return false; return x.Color == RED; }

        private RBNode RotateRight(RBNode h)
        {
            // assert (h != null) && isRed(h.left);
            RBNode x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = x.Right.Color;
            x.Right.Color = RED;
            x.Size = h.Size;
            h.Size = Size(h.Left) + Size(h.Right) + 1;
            return x;
        }

        private RBNode RotateLeft(RBNode h)
        {
            // assert (h != null) && isRed(h.right);
            RBNode x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = x.Left.Color;
            x.Left.Color = RED;
            x.Size = h.Size;
            h.Size = Size(h.Left) + Size(h.Right) + 1;
            return x;
        }

        // flip the colors of a node and its two children
        private void FlipColors(RBNode h)
        {
            h.Color = !h.Color;
            h.Left.Color = !h.Left.Color;
            h.Right.Color = !h.Right.Color;
        }

        public void Insert(int key)
        {
            root = Insert(root, key);
            root.Color = BLACK;
        }

        // insert the key-value pair in the subtree rooted at h
        private RBNode Insert(RBNode h, int key)
        {
            if (h == null) return new RBNode(key, RED, 1);

            if (key < h.Key) h.Left = Insert(h.Left, key);
            else if (key > h.Key) h.Right = Insert(h.Right, key);

            if (IsRed(h.Right) && !IsRed(h.Left)) h = RotateLeft(h);
            if (IsRed(h.Left) && IsRed(h.Left.Left)) h = RotateRight(h);
            if (IsRed(h.Left) && IsRed(h.Right)) FlipColors(h);
            h.Size = Size(h.Left) + Size(h.Right) + 1;

            return h;
        }

        public int? Get(int key)
        {
            return Get(root, key);
        }

        private int? Get(RBNode x, int key)
        {
            while (x != null)
            {
                if (key < x.Key) x = x.Left;
                else if (key > x.Key) x = x.Right;
                else return x.Key;
            }
            return null;
        }

        public void Delete(int key)
        {
            if (!Contains(key)) return;

            // if both children of root are black, set root to red
            if (!IsRed(root.Left) && !IsRed(root.Right))
                root.Color = RED;

            root = Delete(root, key);
            if (root != null) root.Color = BLACK;
        }

        private RBNode Delete(RBNode h, int key)
        {
            if (key < h.Key)
            {
                if (!IsRed(h.Left) && !IsRed(h.Left.Left))
                    h = MoveRedLeft(h);
                h.Left = Delete(h.Left, key);
            }
            else
            {
                if (IsRed(h.Left))
                    h = RotateRight(h);
                if (key == h.Key && h.Right == null)
                    return null;
                if (!IsRed(h.Right) && !IsRed(h.Right.Left))
                    h = MoveRedRight(h);
                if (key == h.Key)
                {
                    RBNode x = Min(h.Right);
                    h.Key = x.Key;
                    h.Right = DeleteMin(h.Right);
                }
                else h.Right = Delete(h.Right, key);
            }
            return Balance(h);
        }

        private RBNode MoveRedLeft(RBNode h)
        {
            FlipColors(h);
            if (IsRed(h.Right.Left))
            {
                h.Right = RotateRight(h.Right);
                h = RotateLeft(h);
                FlipColors(h);
            }
            return h;
        }

        private RBNode MoveRedRight(RBNode h)
        {
            FlipColors(h);
            if (IsRed(h.Left.Left))
            {
                h = RotateRight(h);
                FlipColors(h);
            }
            return h;
        }

        // restore red-black tree invariant
        private RBNode Balance(RBNode h)
        {
            if (IsRed(h.Right)) h = RotateLeft(h);
            if (IsRed(h.Left) && IsRed(h.Left.Left)) h = RotateRight(h);
            if (IsRed(h.Left) && IsRed(h.Right)) FlipColors(h);

            h.Size = Size(h.Left) + Size(h.Right) + 1;
            return h;
        }

        public int Min()
        {
            return Min(root).Key;
        }

        // the smallest key in subtree rooted at x; null if no such key
        private RBNode Min(RBNode x)
        {
            if (x.Left == null) return x;
            else return Min(x.Left);
        }

        public void DeleteMin()
        {
            if (root == null) return;

            // if both children of root are black, set root to red
            if (!IsRed(root.Left) && !IsRed(root.Right))
                root.Color = RED;

            root = DeleteMin(root);
            if (root != null) root.Color = BLACK;
        }

        // delete the key-value pair with the minimum key rooted at h
        private RBNode DeleteMin(RBNode h)
        {
            if (h.Left == null)
                return null;

            if (!IsRed(h.Left) && !IsRed(h.Left.Left))
                h = MoveRedLeft(h);

            h.Left = DeleteMin(h.Left);
            return Balance(h);
        }

        public int Size()
        {
            return Size(root);
        }

        private int Size(RBNode x)
        {
            if (x == null) return 0;
            return x.Size;
        }

        public bool Contains(int key)
        {
            return Get(key) != null;
        }
    }
}
