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
        public bool Remove(T data) { 
            var removeNode = this.FindNode(data);
            //Dont found removed Node
            if(removeNode == null)
            {
                return false;
            }
            //Removed leaf Node
            if (removeNode.IsLeaf()) {
                //Removed Node is Root
                if (removeNode.Parent == null)
                {
                    this.Root = null;
                    return true;
                }
                //Is right or left son of parent
                var compResult = removeNode.Data.CompareTo(removeNode.Parent.Data);
                if (compResult == -1)
                {
                    removeNode.Parent.LeftNode = null;
                }
                else if (compResult == 1) 
                {
                    removeNode.Parent.RightNode = null;
                }
                removeNode.Parent = null;
                return true;
            }
            //Removed node has one child
            if(removeNode.LeftNode == null) {
                //Removed Node is Root
                if (removeNode.Parent == null)
                {
                    this.Root.RightNode = null;
                    this.Root = removeNode;
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
                removeNode.Parent = null;
                removeNode.RightNode = null;
                return true;
            }
            if (removeNode.RightNode == null)
            {
                if (removeNode.Parent == null)
                {
                    this.Root.LeftNode = null;
                    this.Root = removeNode;
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
            inorderSuccessor.RightNode.Parent = inorderSuccessor.Parent;
            inorderSuccessor.Parent.LeftNode = removeNode.RightNode;

            inorderSuccessor.Parent = null;
            inorderSuccessor.RightNode = null;
            return true;
        }

    }
}