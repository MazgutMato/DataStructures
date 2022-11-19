using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public abstract class TreeNode<D>
    {
        public TreeNode<D>? Parent { get; set; }
        public D? Data { get; set; }
        public bool IsRoot()
        {
            return this.Parent == null;
        }
    }
}
