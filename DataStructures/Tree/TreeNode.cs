using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public abstract class TreeNode<T>
    {
        public TreeNode<T>? Parent { get; set; }
        public T? Data { get; set; }
        public bool IsRoot()
        {
            return this.Parent == null;
        }
    }
}
