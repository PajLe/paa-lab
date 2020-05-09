using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV5
{
    public class BTreeNode
    {
        public int[] Keys { get; set; }
        public BTreeNode[] Children { get; set; }
        public int KeyCount { get; set; }
        public bool IsLeaf { get; set; }
    }

    public class SearchResult
    {
        public BTreeNode Node { get; set; }
        public int Index { get; set; }
    }

    class BTree
    {
        private BTreeNode root;
        private int maxKeysPerNode;
        private readonly int t; // min node degree

        public SearchResult Search(int key) // O(tlogt(n)), t - min node degree
        {
            return Search(root, key);
        }

        private SearchResult Search(BTreeNode node, int key)
        {
            int i = 0;
            while (i < node.KeyCount && key > node.Keys[i])
                i++;
            if (i < node.KeyCount && key == node.Keys[i])
            {
                SearchResult s = new SearchResult();
                s.Node = node;
                s.Index = i;
                return s;
            }
            else if (node.IsLeaf)
                return null;
            else
                return Search(node.Children[i], key);
        }

        public BTree(int maxKeysPerNode)
        {
            this.maxKeysPerNode = maxKeysPerNode;
            t = (maxKeysPerNode + 1) / 2;
            root = new BTreeNode();
            root.IsLeaf = true;
            root.Keys = new int[maxKeysPerNode];
            root.Children = new BTreeNode[maxKeysPerNode + 1];
        }

        public void Insert(int key)
        {
            BTreeNode r = root;
            if (r.KeyCount == 2 * t - 1)
            {
                BTreeNode toAdd = new BTreeNode();
                root = toAdd;
                toAdd.Children[0] = r;
                SplitChild(toAdd, 0);
                Insert(toAdd, key);
            }
            else
                Insert(r, key);
        }

        private void Insert(BTreeNode x, int key)
        {
            int i = x.KeyCount - 1;
            if (x.IsLeaf)
            {
                while (i >= 0 && key < x.Keys[i])
                    x.Keys[i + 1] = x.Keys[i--];
                x.Keys[i + 1] = key;
                x.KeyCount++;
            }
            else
            {
                while (i >= 0 && key < x.Keys[i]) i--;
                i++;
                if (x.Children[i].KeyCount == 2*t - 1)
                {
                    SplitChild(x, i);
                    if (key > x.Keys[i]) i++;
                }
                Insert(x.Children[i], key);
            }
        }

        // node - parent of the full node
        // index - index of node's child which is full
        private void SplitChild(BTreeNode node, int index)
        {
            BTreeNode z = new BTreeNode();
            BTreeNode y = node.Children[index];
            z.IsLeaf = y.IsLeaf;
            z.KeyCount = t - 1;

            for (int j = 0; j < t - 1; j++) // move larger part of y to the new node
                z.Keys[j] = y.Keys[j + t];

            if (!y.IsLeaf)
                for (int j = 0; j < t; j++) // move larger children of y to the new node
                    z.Children[j] = y.Children[j + t];

            y.KeyCount = t - 1;

            for (int j = node.KeyCount; j > index; j--) // move children of node to the right to make place for z
                node.Children[j + 1] = node.Children[j];
            node.Children[index + 1] = z;

            for (int j = node.KeyCount - 1; j > index - 1; j--) // move keys of node to the right to make place for y's median
                node.Keys[j + 1] = node.Keys[j];
            node.Keys[index] = y.Keys[t - 1]; // y's t-th element, but (t-1)th index

            node.KeyCount++;
        }
    }
}
