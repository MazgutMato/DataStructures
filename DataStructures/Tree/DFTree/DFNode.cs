using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.DFTree
{
    public class DFNode
    {
        public int RecordCount { get; set; }
        public int BlockDepth { get; set; }
        public int Adress { get; set; }
        public DFNode? LeftNode { get; set; }
        public DFNode? RightNode { get; set; }
        public DFNode()
        {
            this.BlockDepth = 0;
            this.RecordCount = 0;
            this.Adress = 0;
            this.LeftNode = null;
            this.RightNode = null;            
        }
    }
}
