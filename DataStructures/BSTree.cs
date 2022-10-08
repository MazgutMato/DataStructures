using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class BSTree<T> where T : IComparable<T>
    {
        public BSTNode<T> Root { get; set; }
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

            return true;
        }
        public T? Find(T data) {
            var findNode = this.FindNode(data);
            return findNode.Data;
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
                this.DeleteLeaf(removeNode);
            }
            //Removed node has one child
            if(removeNode.LeftNode == null) {
                //Removed Node is Root
                if (removeNode.Parent == null)
                {
                    this.Root = removeNode.RightNode;
                    this.Root.Parent = null;
                    return true;
                }
                //Is right or left son of parent
                var compResult = removeNode.Data.CompareTo(removeNode.Parent.Data);
                if (compResult == -1)
                {
                    removeNode.Parent.LeftNode = removeNode.RightNode;
                }
                else if (compResult == 1)
                {
                    removeNode.Parent.RightNode = removeNode.RightNode;
                }
                return true;
            }
            if (removeNode.RightNode == null)
            {
                if (removeNode.Parent == null)
                {
                    this.Root = removeNode.LeftNode;
                    this.Root.Parent = null;
                    return true;
                }
                //Is right or left son of parent
                var compResult = removeNode.Data.CompareTo(removeNode.Parent.Data);
                if (compResult == -1)
                {
                    removeNode.Parent.LeftNode = removeNode.LeftNode;
                }
                else if (compResult == 1)
                {
                    removeNode.Parent.RightNode = removeNode.LeftNode;
                }
                removeNode.Parent = null;
                removeNode.LeftNode = null;
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

            //Inorder succesor is leaf
            if (inorderSuccessor.IsLeaf()) { 
                this.DeleteLeaf(inorderSuccessor);
                return true;
            }
            //Inorder succesor has right child
            inorderSuccessor.RightNode.Parent = inorderSuccessor.Parent;
            if(removeNode.Parent == null)
            {
                inorderSuccessor.Parent.RightNode = inorderSuccessor.RightNode;
            } else
            {
                inorderSuccessor.Parent.LeftNode = inorderSuccessor.RightNode;
            }
            return true;
        }
        private bool DeleteLeaf(BSTNode<T> paLeaf)
        {
            //Removed Node is Root
            if (paLeaf.Parent == null)
            {
                this.Root = null;
                return true;
            }
            //Removed from parent
            var compResult = paLeaf.Data.CompareTo(paLeaf.Parent.Data);
            if (compResult == -1)
            {
                paLeaf.Parent.LeftNode = null;
            }
            else if (compResult == 1 || compResult == 0)
            {
                paLeaf.Parent.RightNode = null;
            }
            return true;
        }
    }
}