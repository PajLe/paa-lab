using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV4
{
    class MinFibonacciHeap
    {
        private FNode HMin; // node with Min key 
        private int Hn;     // number of nodes in the heap
        private int tH;     // number of trees in root list
        private int mH;     // number of marked nodes in the heap - NOT USED

        private FNode Min { get => HMin; }
        public int Size { get => Hn; }

        public class FNode
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
            Insert(toAdd);
            Hn++;
        }

        public void InsertNode(FNode toAdd)
        {
            toAdd.Degree = 0;
            toAdd.Parent = null;
            toAdd.Child = null;
            toAdd.Marked = false;
            Insert(toAdd);
            Hn++;
        }

        private void Insert(FNode toAdd)
        {
            if (HMin == null)
            {
                toAdd.Left = toAdd;
                toAdd.Right = toAdd;

                HMin = toAdd;
            }
            else // add to the end of the root list
            {
                toAdd.Left = HMin.Left; // toAdd.Left is previously-last node
                HMin.Left.Right = toAdd; // previously-last's Right now points to the new node (toAdd)
                HMin.Left = toAdd; // head.Left points to a new-last (toAdd)
                toAdd.Right = HMin; // toAdd is now last, its Right is head
                if (toAdd.Key < HMin.Key)
                    HMin = toAdd;
            }
            tH++;
        }

        public int PeekMin() // return type == key type
        {
            return HMin.Key;
        }

        public void Union(MinFibonacciHeap h2)
        {
            FNode thisLast = this.HMin.Left;
            FNode h2Last = h2.HMin.Left;

            thisLast.Right = h2.HMin;
            h2Last.Right = this.HMin;

            this.HMin.Left = h2Last;
            h2.HMin.Left = thisLast;

            if (h2.Min.Key < this.HMin.Key)
                this.HMin = h2.Min;

            Hn += h2.Size;
            tH += h2.tH;
        }

        public int? ExtractMin()
        {
            FNode z = HMin;
            if (z != null)
            {
                // merge childs of 'z' with the root list
                FNode child = z.Child;
                if (z.Degree > 0)
                {
                    FNode childLast = child.Left;
                    FNode thisLast = this.HMin.Left;

                    thisLast.Right = child;
                    childLast.Right = this.HMin;

                    this.HMin.Left = childLast;
                    child.Left = thisLast;
                }
                tH += z.Degree;

                // remove z from the root list
                z.Left.Right = z.Right;
                z.Right.Left = z.Left;
                tH--;
                Hn--;
                if (z == z.Right)
                    HMin = null;
                else
                {
                    HMin = z.Right;
                    Consolidate();
                }
            }
            else
                return null;

            return z.Key;
        }

        private void Consolidate()
        {
            Dictionary<int, FNode> A = new Dictionary<int, FNode>();
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
                    i--;
                }
                A.Add(d, x);
            }
            HMin = null;
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
                child.Left = child;
                child.Right = child;
                parent.Child = child;
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

            FNode current = HMin;
            if (current == null)
                return "Empty";

            for (int i = 0; i < tH - 1; i++)
            {
                s.Append(current.Key);
                if (current.Degree > 0)
                {
                    s.Append("(");
                    s.Append(Siblings(current.Child, current.Degree));
                    s.Append(")");
                }
                s.Append("<-->");
                current = current.Right;
            }

            s.Append(current.Key);
            if (current.Degree > 0)
            {
                s.Append("(");
                s.Append(Siblings(current.Child, current.Degree));
                s.Append(")");
            }

            return s.ToString();
        }

        private StringBuilder Siblings(FNode node, int siblingCount)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < siblingCount - 1; i++)
            {
                s.Append(node.Key);
                if (node.Degree > 0)
                {
                    s.Append("(");
                    s.Append(Siblings(node.Child, node.Degree));
                    s.Append(")");
                }
                s.Append(", ");
                node = node.Right;
            }

            s.Append(node.Key);
            if (node.Degree > 0)
            {
                s.Append("(");
                s.Append(Siblings(node.Child, node.Degree));
                s.Append(")");
            }
            return s;
        }

        public void DecreaseKey(FNode node, int key)
        {
            if (key >= node.Key)
                throw new ArgumentException("New key has to be smaller than the current key.");
            node.Key = key;
            FNode y = node.Parent;
            if(y != null && node.Key < y.Key)
            {
                Cut(node, y);
                CasadingCut(y);
            }
            if (node.Key < HMin.Key)
                HMin = node;
        }

        private void CasadingCut(FNode y)
        {
            FNode z = y.Parent;
            if (z != null)
            {
                if (y.Marked == false)
                    y.Marked = true;
                else
                {
                    Cut(y, z);
                    CasadingCut(z);
                }
            }
        }

        private void Cut(FNode node, FNode y)
        {
            node.Left.Right = node.Right;
            node.Right.Left = node.Left;
            y.Degree--;
            node.Parent = null;
            node.Marked = false;
            Insert(node);
        }
    }
}
