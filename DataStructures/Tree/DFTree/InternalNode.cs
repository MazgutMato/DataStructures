using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.DFTree
{
    public class InternalNode : DFNode
    {                
        public DFNode? LeftNode { get; set; }
        public DFNode? RightNode { get; set; }
        public InternalNode() : base()
        {
            this.LeftNode = null;
            this.RightNode = null;      
        }
    }
}
