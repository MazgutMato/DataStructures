using DataStructures.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class BSTNode<T> : AbstractTreeNode<T> where T : IComparable<T>
    {
        public BSTNode<T> LeftNode { get; set; }
        public BSTNode<T> RightNode { get; set; }

        public BSTNode(T paData) : base(paData)
        {
            this.LeftNode = null;
            this.RightNode = null;
        }
        public BSTNode(T paData, BSTNode<T> paParent) : base(paData, paParent)
        {
            this.LeftNode = null;
            this.RightNode = null;
        }

        public BSTNode(BSTNode<T> BSTNode) : base(BSTNode)
        {
            this.LeftNode = BSTNode.LeftNode;
            this.RightNode = BSTNode.RightNode;
        }

        public override bool IsLeaf()
        {
            if (this.RightNode == null && this.LeftNode == null)
            {
                return true;
            }
            return false;
        }
    }
}