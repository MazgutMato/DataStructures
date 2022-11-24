using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.DFTree
{
    public class DFNode
    {
        public int BlockDepth { get; set; }
        public DFNode? Parent { get; set; }
        public DFNode()
        {
            this.Parent = null;
            this.BlockDepth = 0;
        }
    }
}
