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
        private int tH;     // number of trees in root list
        private int mH;     // number of marked nodes in the heap
        private int Hn;     // number of nodes in the heap

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

        public void Insert(int key)
        {
            FNode toAdd = new FNode();
            toAdd.Key = key;
            toAdd.Degree = 0;
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
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            FNode current = head;
            for (int i = 0; i < Hn; i++)
            {
                s.Append(current.Key + "<-->");
                current = current.Right;
            }

            return s.ToString();
        }
    }
}
