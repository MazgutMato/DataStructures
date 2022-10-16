using DataStructures.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Tree.BSTree
{
    public class BSTNode<T> : AbstractTreeNode<T> where T : IComparable<T>
    {
        public BSTNode<T> LeftNode { get; set; }
        public BSTNode<T> RightNode { get; set; }
        public int LeftHeight { get; set; }
        public int RightHeight { get; set; }

        public BSTNode(T paData) : base(paData)
        {
            LeftNode = null;
            RightNode = null;
        }
        public BSTNode(T paData, BSTNode<T> paParent) : base(paData, paParent)
        {
            LeftNode = null;
            RightNode = null;
        }

        public BSTNode(BSTNode<T> BSTNode) : base(BSTNode)
        {
            LeftNode = BSTNode.LeftNode;
            RightNode = BSTNode.RightNode;
        }

        public override bool IsLeaf()
        {
            if (RightNode == null && LeftNode == null)
            {
                return true;
            }
            return false;
        }

        public int GetHeight()
        {
            return (this.RightHeight - this.LeftHeight);
        }
    }
}