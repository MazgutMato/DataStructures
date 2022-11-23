using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.DFTree
{
    public class DFNode
    {
        public DFNode? Parent { get; set; }
        public int BlockDepth { get; set; }
        public DFNode()
        {
            this.BlockDepth = 0;
            this.Parent = null;
        }
    }
}
