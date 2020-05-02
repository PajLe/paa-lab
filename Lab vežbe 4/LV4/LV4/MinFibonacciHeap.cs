using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV4
{
    class MinFibonacciHeap
    {
        private FNode head; // head of the root list
        private FNode HMin; // node with Min key 
        private int Hn;     // number of nodes in the heap
        private int tH;     // number of trees in root list
        private int mH;     // number of marked nodes in the heap
        private Dictionary<int, FNode> A;

        private FNode Head { get => head; }
        private FNode Min { get => HMin; }
        public int Size { get => Hn; }

        private class FNode
        {
            public int Key { get; set; }
            public FNode Parent { get; set; }
            public FNode Left { get; set; }
            public FNode Right { get; set; }
            public FNode Child { get; set; }
            public int Degree { get; set; }
            public bool Marked { get; set; }
        }

        public MinFibonacciHeap() { }

        public void Insert(int key) // insert type == key type
        {
            FNode toAdd = new FNode();
            toAdd.Key = key;
            toAdd.Degree = 0;
            Insert(toAdd);
        }

        private void Insert(FNode toAdd)
        {
            if (HMin == null)
            {
                toAdd.Left = toAdd;
                toAdd.Right = toAdd;

                head = toAdd;
                HMin = toAdd;
            }
            else // add to the end of the root list
            {
                toAdd.Left = head.Left; // toAdd.Left is previously-last node
                head.Left.Right = toAdd; // previously-last's Right now points to new node (toAdd)
                head.Left = toAdd; // head.Left points to a new-last (toAdd)
                toAdd.Right = head; // toAdd is now last, its Right is head
                if (toAdd.Key < HMin.Key)
                    HMin = toAdd;
            }
            Hn++;
            tH++;
        }

        public int PeekMin() // return type == key type
        {
            return HMin.Key;
        }

        public void Union(MinFibonacciHeap h2)
        {
            FNode thisLast = this.head.Left;
            FNode h2Last = h2.Head.Left;

            thisLast.Right = h2.Head;
            h2Last.Right = this.head;

            this.head.Left = h2Last;
            h2.Head.Left = thisLast;

            if (h2.Min.Key < this.HMin.Key)
                this.HMin = h2.Min;

            Hn += h2.Size;
        }

        public int? ExtractMin()
        {
            FNode z = HMin;
            if (z != null)
            {
                // add each child to the root list
                FNode current = z.Child;
                for (int i = 0; i < z.Degree; i++)
                {
                    Insert(current);
                    current.Parent = null;
                    current = current.Right;
                    tH++;
                }

                // remove z from the root list
                z.Left.Right = z.Right;
                z.Right.Left = z.Left;
                tH--;
                if (z == z.Right)
                    HMin = null;
                else
                {
                    HMin = z.Right;
                    Consolidate();
                }
                Hn--;
            }
            else
                return null;

            return z.Key;
        }

        private void Consolidate()
        {
            A = new Dictionary<int, FNode>();
            FNode current = HMin;
            for (int i = 0; i < tH; i++)
            {
                FNode x = current;
                int d = x.Degree;
                current = current.Right;
                while(A.ContainsKey(d))
                {
                    FNode y = A[d];
                    if (x.Key > y.Key)
                    {
                        Link(y, x);
                        x = y;
                    }
                    else Link(x, y);
                    A.Remove(d);
                    d++;
                    tH--; // move to Link maybe?
                }
                A.Add(d, x);
            }
            A.Add(current.Degree, current);
            HMin = null;
            head = null;
            tH = 0;
            foreach (FNode node in A.Values)
                Insert(node);
        }

        private void Link(FNode parent, FNode child)
        {
            child.Left.Right = child.Right;
            child.Right.Left = child.Left;
            child.Parent = parent;
            child.Marked = false;

            if (parent.Degree == 0)
            {
                parent.Child = child;
                child.Left = child;
                child.Right = child;
            }
            else
            {
                parent.Child.Left.Right = child;
                child.Left = parent.Child.Left;
                child.Right = parent.Child;
                parent.Child.Left = child;
            }
            parent.Degree++;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            FNode current = head;
            for (int i = 0; i < tH - 1; i++)
            {
                s.Append(current.Key + "<-->");
                current = current.Right;
            }

            s.Append(current.Key);

            return s.ToString();
        }
    }
}
