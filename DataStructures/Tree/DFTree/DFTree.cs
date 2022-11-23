using DataStructures.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.DFTree
{
    public class DFTree
    {
        public int BlockFactror { get; }
        public int MaxBlockDepth { get; set; }
        public DFNode? Root { get; set; }
        public DFTree(int blockFactor) 
        { 
            this.BlockFactror= blockFactor;
            this.Root = null;
        }
    }
}
