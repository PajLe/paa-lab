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

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append('(');
            int i;
            for (i = 0; i < Node.KeyCount - 1; i++)
            {
                s.Append(Node.Keys[i]); // (char)
                s.Append(", ");
            }
            s.Append(Node.Keys[i]); // (char)
            s.Append(')');
            s.Append(" | ");
            s.Append(Node.Keys[Index]); // (char)
            s.Append(", [");
            s.Append(Index);
            s.Append(']');
            return s.ToString();
        }
    }

    public class IntervalSearchResult
    {
        public BTreeNode Node { get; set; }
        public int IndexFrom { get; set; }
        public int IndexTo { get; set; }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append('(');
            int i;
            for (i = 0; i < Node.KeyCount - 1; i++)
            {
                s.Append(Node.Keys[i]); // (char)
                s.Append(", ");
            }
            s.Append(Node.Keys[i]); // (char)
            s.Append(')');
            s.Append(" | ");
            s.Append(Node.Keys[IndexFrom]); // (char)
            s.Append(" - ");
            s.Append(Node.Keys[IndexTo]); // (char)
            s.Append(", [");
            s.Append(IndexFrom);
            s.Append(" - ");
            s.Append(IndexTo);
            s.Append(']');
            return s.ToString();
        }
    }

    class BTree
    {
        private BTreeNode root;
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

        public IntervalSearchResult IntervalSearch(int fromKey, int toKey)
        {
            return IntervalSearch(root, fromKey, toKey);
        }

        private IntervalSearchResult IntervalSearch(BTreeNode node, int fromKey, int toKey)
        {
            int i = 0;
            while (i < node.KeyCount && fromKey > node.Keys[i])
                i++;
            if (i < node.KeyCount && fromKey == node.Keys[i])
            {
                int j = i + 1;
                while (j < node.KeyCount && toKey > node.Keys[j])
                    j++;
                if (j < node.KeyCount && toKey == node.Keys[j])
                {
                    IntervalSearchResult s = new IntervalSearchResult();
                    s.Node = node;
                    s.IndexFrom = i;
                    s.IndexTo = j;
                    return s;
                }
            }
            if (node.IsLeaf)
                return null;
            IntervalSearchResult r = IntervalSearch(node.Children[i++], fromKey, toKey);
            while (r == null && i < node.KeyCount && fromKey == node.Keys[i])
                r = IntervalSearch(node.Children[i++], fromKey, toKey);
            if (i == node.KeyCount && fromKey == node.Keys[i - 1])
                r = IntervalSearch(node.Children[i], fromKey, toKey);
            return r;
        }

        public BTree(int maxKeysPerNode)
        {
            t = (maxKeysPerNode + 1) / 2;
            root = new BTreeNode();
            root.IsLeaf = true;
            root.Keys = new int[2 * t - 1];
            root.Children = new BTreeNode[2 * t];
        }

        public void Insert(int key)
        {
            BTreeNode r = root;
            if (r.KeyCount == 2 * t - 1)
            {
                BTreeNode toAdd = new BTreeNode();
                toAdd.Children = new BTreeNode[2 * t];
                toAdd.Keys = new int[2 * t - 1];
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
            z.Children = new BTreeNode[2 * t];
            z.Keys = new int[2 * t - 1];
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

        public void Delete(int key)
        {
            if (Search(key) != null)
                Delete(root, key);
        }

        private void Delete(BTreeNode node, int key)
        {
            if (node == null) return;
            int i = 0;
            while (i < node.KeyCount && key > node.Keys[i])
                i++;
            if (i < node.KeyCount && key == node.Keys[i]) // node contains the key
            {
                if (node.IsLeaf) // case 1
                {
                    for (int j = i; j < node.KeyCount - 1; j++)
                        node.Keys[j] = node.Keys[j + 1];
                    node.KeyCount--;
                    if (node.KeyCount == 0) // if tree was just emptied
                    {
                        root = new BTreeNode();
                        root.IsLeaf = true;
                        root.Keys = new int[2 * t - 1];
                        root.Children = new BTreeNode[2 * t];
                    }
                }
                else // case 2
                {
                    if (node.Children[i].KeyCount >= t) // case 2a
                    {
                        int predecessor = node.Children[i].Keys[node.Children[i].KeyCount - 1]; // maybe predecessor doesnt have to be last key
                        node.Keys[i] = predecessor;
                        Delete(node.Children[i], predecessor);
                    } 
                    else if (node.Children[i + 1].KeyCount >= t) // case 2b
                    {
                        int successor = node.Children[i + 1].Keys[0]; // maybe successor doesnt have to be first key
                        node.Keys[i] = successor;
                        Delete(node.Children[i + 1], successor);
                    } 
                    else // case 2c
                    {
                        BTreeNode y = node.Children[i];
                        BTreeNode z = node.Children[i + 1];

                        // merge key with y
                        y.Keys[y.KeyCount++] = key;

                        // merge z with y
                        for (int j = y.KeyCount; j < y.KeyCount + z.KeyCount; j++)
                        {
                            y.Keys[j] = z.Keys[j - y.KeyCount];
                            y.Children[j] = z.Children[j - y.KeyCount];
                        }
                        y.KeyCount += z.KeyCount;
                        y.Children[y.KeyCount] = z.Children[z.KeyCount];

                        // remove key from node
                        for (int j = i; j < node.KeyCount - 1; j++)
                            node.Keys[j] = node.Keys[j + 1];

                        // free z from node
                        for (int j = i + 1; j < node.KeyCount; j++)
                            node.Children[j] = node.Children[j + 1];

                        node.KeyCount--;

                        Delete(y, key);
                    }
                }
            }
            else // node doesn't contain key
            {
                if (node.Children[i] != null && node.Children[i].KeyCount == t - 1)
                {
                    if (i - 1 > -1 && node.Children[i - 1].KeyCount >= t) // left sibling - case 3a
                    {
                        // move key from parent to child
                        for (int j = node.Children[i].KeyCount; j > 0; j--)
                            node.Children[i].Keys[j] = node.Children[i].Keys[j - 1];
                        node.Children[i].Keys[0] = node.Keys[i - 1];
                        node.Children[i].KeyCount++;

                        // move rightmost key of left child to parent
                        node.Keys[i - 1] = node.Children[i - 1].Keys[node.Children[i - 1].KeyCount - 1]; 

                        // move children of ci to the right in order to make place for a new child
                        for (int j = node.Children[i].KeyCount; j > 0; j--)
                            node.Children[i].Children[j] = node.Children[i].Children[j - 1];
                        node.Children[i].Children[0] = node.Children[i - 1].Children[node.Children[i - 1].KeyCount]; // insert c(i-1)'s rightmost child

                        // remove c(i-1)'s rightmost key and child
                        node.Children[i - 1].KeyCount--;

                        Delete(node.Children[i], key);
                    }
                    else if (i + 1 <= node.KeyCount && node.Children[i + 1].KeyCount >= t) // right sibling - case 3a
                    {
                        // move key from parent to child
                        node.Children[i].Keys[node.Children[i].KeyCount++] = node.Keys[i];

                        // move leftmost key of right child to parent
                        node.Keys[i] = node.Children[i + 1].Keys[0];

                        // insert first child of c(i+1) to last child of ci
                        node.Children[i].Children[node.Children[i].KeyCount] = node.Children[i + 1].Children[0];

                        // remove c(i+1)'s leftmost key and child
                        for (int j = 0; j < node.Children[i + 1].KeyCount - 1; j++) 
                        {
                            node.Children[i + 1].Keys[j] = node.Children[i + 1].Keys[j + 1];
                            node.Children[i + 1].Children[j] = node.Children[i + 1].Children[j + 1];
                        }
                        node.Children[i + 1].Children[node.Children[i + 1].KeyCount - 1] = node.Children[i + 1].Children[node.Children[i + 1].KeyCount];
                        node.Children[i + 1].KeyCount--;

                        Delete(node.Children[i], key);
                    }
                    else // both siblings have t-1 keys - case 3b
                    {
                        BTreeNode y;
                        BTreeNode z;
                        int zIndex;
                        // merge parent key with y
                        if (i + 1 <= node.KeyCount)
                        {
                            y = node.Children[i];
                            z = node.Children[i + 1];
                            y.Keys[y.KeyCount++] = node.Keys[i];
                            zIndex = i + 1;
                        }
                        else if (i - 1 >= 0)
                        {
                            y = node.Children[i - 1];
                            z = node.Children[i];
                            y.Keys[y.KeyCount++] = node.Keys[i - 1];
                            zIndex = i;
                        }
                        else
                            return;

                        // merge z with y
                        for (int j = y.KeyCount; j < y.KeyCount + z.KeyCount; j++)
                        {
                            y.Keys[j] = z.Keys[j - y.KeyCount];
                            y.Children[j] = z.Children[j - y.KeyCount];
                        }
                        y.KeyCount += z.KeyCount;
                        y.Children[y.KeyCount] = z.Children[z.KeyCount];

                        // remove z from node's children
                        for (int j = zIndex; j < node.KeyCount; j++)
                            node.Children[j] = node.Children[j + 1];

                        // remove taken key from node
                        for (int j = i; j < node.KeyCount - 1; j++)
                            node.Keys[j] = node.Keys[j + 1];
                        node.KeyCount--;

                        if (node.KeyCount == 0)
                        { 
                            if(node == root)
                                root = y;
                            node = null;
                        }

                        Delete(y, key);
                    }
                }
                else
                    Delete(node.Children[i], key);
            }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            Print(root, s, 1);
            return s.ToString();
        }

        private void Print(BTreeNode node, StringBuilder s, int depth)
        {
            if (node == null) return;
            int i;
            for (i = 0; i < node.KeyCount - 1; i++)
            {
                s.Append(node.Keys[i]); // (char)
                s.Append("-");
            }
            s.Append(node.Keys[i]); // (char)
            s.Append("(\n");
            for (int j = 0; j < node.KeyCount + 1; j++)
            {
                if (node.Children[j] == null) break;
                for (int k = 0; k < depth; k++) 
                    s.Append("\t");
                Print(node.Children[j], s, depth + 1);
                s.Append("\n");
            }
            for (int k = 0; k < depth - 1; k++) 
                s.Append("\t");
            s.Append(")");
        }
    }
}
