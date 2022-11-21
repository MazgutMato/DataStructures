using DataStructures.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Tree.BSTree
{
    public class BSTNode<T> : TreeNode<T> where T : IComparable<T>
    {
        public BSTNode<T> LeftNode { get; set; }
        public BSTNode<T> RightNode { get; set; }
        public int LeftHeight { get; set; }
        public int RightHeight { get; set; }

        public BSTNode(T paData)
        {
            LeftNode = null;
            RightNode = null;
        }
        public BSTNode(T paData, BSTNode<T> paParent)
        {
            LeftNode = null;
            RightNode = null;
        }

        public BSTNode(BSTNode<T> BSTNode)
        {
            LeftNode = BSTNode.LeftNode;
            RightNode = BSTNode.RightNode;
        }

        public bool IsLeaf()
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