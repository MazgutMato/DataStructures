using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public abstract class AbstractTreeNode<T> where T : IComparable<T>
    {
        public AbstractTreeNode<T> Parent { get; set; }
        public T Data { get; set; }
        protected AbstractTreeNode(T data)
        {            
            this.Data = data;
        }
        protected AbstractTreeNode(T data, AbstractTreeNode<T> parent)
        {
            this.Parent = parent;
            this.Data = data;
        }
        protected AbstractTreeNode(AbstractTreeNode<T> abstractTreeNode)
        {
            this.Parent = abstractTreeNode.Parent;
            this.Data = abstractTreeNode.Data;
        }
        public abstract bool IsLeaf();
        public bool IsRoot()
        {
            return this.Parent == null;
        }
    }
}
