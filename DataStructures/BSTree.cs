using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class BSTree<T> where T : IComparable<T>
    {
        public BSTNode<T> Root { get; set; }
        public int Count { get; set; }
        public bool Add(T data) {
            BSTNode<T> Parent = null;
            var Child = this.Root;

            while (Child != null) {
                Parent = Child;
                int compResult = data.CompareTo(Parent.Data);

                if (compResult == 1)
                {
                    Child = Parent.RightNode;
                }
                else if (compResult == -1)
                {
                    Child = Parent.LeftNode;
                }
                else {
                    //Found same Node
                    return false;
                }
            }

            if (Parent == null)
            {
                this.Root = new BSTNode<T>(data);
            } else
            {
                var newPosition = data.CompareTo(Parent.Data);
                if (newPosition == 1) {
                    Parent.RightNode = new BSTNode<T>(data, Parent);
                } else
                {
                    Parent.LeftNode = new BSTNode<T>(data, Parent);
                }
            }

            this.Count++;
            return true;
        }
        public T? Find(T data) {
            var findNode = this.FindNode(data);
            if (findNode != null) {
                return findNode.Data;
            }
            return default(T);
        }
        public bool RotateRight(T data)
        {
            var node = this.FindNode(data);
            if (node != null)
            {
                if (node.LeftNode == null)
                {
                    return false;
                }
                var leftNode = node.LeftNode;

                if (node.Parent != null)
                {
                    leftNode.Parent = node.Parent;
                    if (leftNode.Data.CompareTo((leftNode.Parent).Data) < 0)
                    {
                        ((BSTNode<T>)leftNode.Parent).LeftNode = leftNode;
                    }
                    else
                    {
                        ((BSTNode<T>)leftNode.Parent).RightNode = leftNode;
                    }
                }
                else
                {
                    leftNode.Parent = null;
                    this.Root = leftNode;
                }

                if (leftNode.RightNode != null)
                {
                    node.LeftNode = leftNode.RightNode;
                    (node.LeftNode).Parent = node;
                }else
                {
                    node.LeftNode = null;
                }

                node.Parent = leftNode;
                leftNode.RightNode = node;

                return true;
            }
            return false;
        }
        public bool RotateLeft(T data)
        {
            var node = this.FindNode(data);
            if (node != null)
            {
                if (node.RightNode == null)
                {
                    return false;
                }
                var rightNode = node.RightNode;

                if (node.Parent != null)
                {
                    rightNode.Parent = node.Parent;
                    if (rightNode.Data.CompareTo((rightNode.Parent).Data) < 0)
                    {
                        ((BSTNode<T>)rightNode.Parent).LeftNode = rightNode;
                    }
                    else
                    {
                        ((BSTNode<T>)rightNode.Parent).RightNode = rightNode;
                    }
                }
                else
                {
                    rightNode.Parent = null;
                    this.Root = rightNode;
                }

                if (rightNode.LeftNode != null)
                {
                    node.RightNode = rightNode.LeftNode;
                    (node.RightNode).Parent = node;
                } else
                {
                    node.RightNode = null;
                }

                node.Parent = rightNode;
                rightNode.LeftNode = node;

                return true;
            }
            return false;
        }
        private BSTNode<T>? FindNode(T data)
        {
            var Child = this.Root;
            BSTNode<T> findNode = null;

            while (Child != null && findNode == null)
            {
                int compResult = data.CompareTo(Child.Data);
                if (compResult == 0)
                {
                    findNode = Child;
                }
                else if (compResult == 1)
                {
                    Child = Child.RightNode;
                }
                else
                {
                    Child = Child.LeftNode;
                }
            }

            return findNode;
        }
        public bool Delete(T data) { 
            var removeNode = this.FindNode(data);
            //Dont found removed Node
            if(removeNode == null)
            {
                return false;
            }
            //Removed leaf Node
            if (removeNode.IsLeaf()) {
                return this.DeleteLeaf(removeNode);               
            }
            //Removed node has one child
            if(removeNode.LeftNode == null) {
                //Removed Node is Root
                if (removeNode.Parent == null)
                {
                    this.Root = removeNode.RightNode;
                    this.Root.Parent = null;
                    this.Count--;
                    return true;
                }
                //Is right or left son of parent
                var compResult = removeNode.Data.CompareTo(removeNode.Parent.Data);
                if (compResult == -1)
                {
                    ((BSTNode<T>)removeNode.Parent).LeftNode = removeNode.RightNode;
                    (removeNode.RightNode).Parent = removeNode.Parent;
                }
                else if (compResult == 1)
                {
                    ((BSTNode<T>)removeNode.Parent).RightNode = removeNode.RightNode;
                    (removeNode.RightNode).Parent = removeNode.Parent;
                }
                this.Count--;
                return true;
            }
            if (removeNode.RightNode == null)
            {
                if (removeNode.Parent == null)
                {
                    this.Root = removeNode.LeftNode;
                    this.Root.Parent = null;
                    this.Count--;
                    return true;
                }
                //Is right or left son of parent
                var compResult = removeNode.Data.CompareTo(removeNode.Parent.Data);
                if (compResult == -1)
                {
                    ((BSTNode<T>)removeNode.Parent).LeftNode = removeNode.LeftNode;
                    (removeNode.LeftNode).Parent = removeNode.Parent;
                }
                else if (compResult == 1)
                {
                    ((BSTNode<T>)removeNode.Parent).RightNode = removeNode.LeftNode;
                    (removeNode.LeftNode).Parent = removeNode.Parent;
                }
                this.Count--;
                return true;
            }
            //Else search inorderSuccessor
            var inorderSuccessor = removeNode.RightNode;
            var leftChild = removeNode.RightNode;
            while(leftChild != null)
            {
                inorderSuccessor = leftChild;
                leftChild = leftChild.LeftNode;
            }
            //Change removeNode to inorderSuccessor
            removeNode.Data = inorderSuccessor.Data;
            //Inorder successor is rightNode
            if (removeNode.Data.CompareTo(removeNode.RightNode.Data) == 0)
            {
                if (inorderSuccessor.IsLeaf())
                {
                    removeNode.RightNode = null;
                    this.Count--;
                    return true;
                }
                //Has right child
                removeNode.RightNode = inorderSuccessor.RightNode;
                removeNode.RightNode.Parent = removeNode;
                this.Count--;
                return true;
            }           
            //Inorder succesor is leaf
            if (inorderSuccessor.IsLeaf()) {               
                return this.DeleteLeaf(inorderSuccessor);
            }
            //Inorder succesor has right child
            inorderSuccessor.RightNode.Parent = inorderSuccessor.Parent;
            ((BSTNode<T>)inorderSuccessor.Parent).LeftNode = inorderSuccessor.RightNode;
            this.Count--;
            return true;
        }
        private bool DeleteLeaf(BSTNode<T> paLeaf)
        {
            //Removed Node is Root
            if (paLeaf.Parent == null)
            {
                this.Root = null;
                this.Count--;
                return true;
            }
            //Removed from parent
            var compResult = paLeaf.Data.CompareTo(paLeaf.Parent.Data);
            if (compResult == -1)
            {
                ((BSTNode<T>)paLeaf.Parent).LeftNode = null;
                this.Count--;
                return true;
            }
            else if (compResult == 1)
            {
                ((BSTNode<T>)paLeaf.Parent).RightNode = null;
                this.Count--;
                return true;
            }
            return false;
        }
    }
}