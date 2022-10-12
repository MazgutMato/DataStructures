using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class BSTNode<T> where T : IComparable<T>
    {
        public BSTNode<T> LeftNode { get; set; }
        public BSTNode<T> RightNode { get; set; }
        public BSTNode<T> Parent { get; set; }
        public T Data { get; set; }

        public BSTNode(T paData){
            this.Data = paData;
        }
        public BSTNode(T paData, BSTNode<T> paParent)
        {
            this.Data = paData;
            this.Parent = paParent;
        }

        public BSTNode(BSTNode<T> BSTNode)
        {
            this.Data = BSTNode.Data;
            this.Parent = BSTNode.Parent;
            this.LeftNode = BSTNode.LeftNode;
            this.RightNode = BSTNode.RightNode;
        }

        public bool IsLeaf() {
            if (this.RightNode == null && this.LeftNode == null) {
                return true;
            }
            return false;
        }
    }
}