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
        public bool RotateLeft()
        {
            if (this.LeftNode == null)
            {
                return false;
            }
            var current = new BSTNode<T>(this);
            var leftNode = new BSTNode<T>(this.LeftNode);

            this.LeftNode.RightNode = this;
            this.Parent = this.LeftNode;

            if (leftNode.RightNode != null)
            {
                this.LeftNode = leftNode.RightNode;
                this.LeftNode.Parent = this;
            }

            if (current.Parent != null)
            {
                this.Parent.Parent = current.Parent;
                if (leftNode.Data.CompareTo(current.Parent.Data) < 0)
                {
                    this.Parent.Parent.LeftNode = this.Parent;
                } else
                {
                    this.Parent.Parent.RightNode = this.Parent;
                }
            }

            return true;          
        }

        public bool RotateRight()
        {
            if (this.RightNode == null)
            {
                return false;
            }
            var current = new BSTNode<T>(this);
            var rightNode = new BSTNode<T>(this.RightNode);

            this.RightNode.LeftNode = this;
            this.Parent = this.RightNode;

            if (rightNode.LeftNode != null)
            {
                this.RightNode = rightNode.LeftNode;
                this.RightNode.Parent = this;
            }

            if (current.Parent != null)
            {
                this.Parent.Parent = current.Parent;
                if (rightNode.Data.CompareTo(current.Parent.Data) < 0)
                {
                    this.Parent.Parent.LeftNode = this.Parent;
                }
                else
                {
                    this.Parent.Parent.RightNode = this.Parent;
                }
            }

            return true;
        }
    }
}