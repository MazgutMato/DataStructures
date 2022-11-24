using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree.DFTree
{
    public class ExternalNode : DFNode
    {
        public int RecordCount { get; set; }        
        public long Adress { get; set; }
        public ExternalNode() : base()
        {
            this.RecordCount = 0;
            this.Adress = -1;
        }
        public bool isEqual(ExternalNode other)
        {
            return this.Adress == other.Adress;
        }
    }
}
