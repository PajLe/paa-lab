using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV3
{
    public class SFNode
    {
        public char? Char { get; set; }
        public SFNode Left { get; set; }
        public SFNode Right { get; set; }
    }

    class SFDecodeTree
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
}
