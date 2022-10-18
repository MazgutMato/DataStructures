using DataStructures.Iterator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Tree.BSTree
{
    public class BSTree<T> : Iterable<T> where T : IComparable<T>
    {
        public BSTNode<T> Root { get; set; }
        public int Count { get; set; }
        public Iterator<T> createIterator()
        {
            throw new NotImplementedException();
        }
        public bool Add(T data)
        {
            BSTNode<T> Parent = null;
            var Child = Root;

            while (Child != null)
            {
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
                else
                {
                    //Found same Node
                    return false;
                }
            }

            if (Parent == null)
            {
                Root = new BSTNode<T>(data);
            }
            else
            {
                var newPosition = data.CompareTo(Parent.Data);
                if (newPosition == 1)
                {
                    Parent.RightNode = new BSTNode<T>(data, Parent);
                }
                else
                {
                    Parent.LeftNode = new BSTNode<T>(data, Parent);
                }
            }

            Count++;
            return true;
        }
        public T? Find(T data)
        {
            var findNode = FindNode(data);
            if (findNode != null)
            {
                return findNode.Data;
            }
            return default;
        }
        private bool RotateRight(BSTNode<T> node)
        {
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
                    if (leftNode.Data.CompareTo(leftNode.Parent.Data) < 0)
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
                    Root = leftNode;
                }

                if (leftNode.RightNode != null)
                {
                    node.LeftNode = leftNode.RightNode;
                    node.LeftNode.Parent = node;
                }
                else
                {
                    node.LeftNode = null;
                }

                node.Parent = leftNode;
                leftNode.RightNode = node;

                //Height change
                if(node.LeftNode != null)
                {
                    node.LeftHeight = Math.Max((node.LeftNode).LeftHeight, (node.LeftNode).RightHeight) + 1;
                } else
                {
                    node.LeftHeight = 0;
                }
                                               
                var heightChange = node;
                while(heightChange.Parent != null)
                {                    
                    if (heightChange.Data.CompareTo(heightChange.Parent.Data) < 0)
                    {
                        ((BSTNode<T>)heightChange.Parent).LeftHeight = Math.Max(heightChange.LeftHeight, heightChange.RightHeight) + 1;
                    }
                    else
                    {
                        ((BSTNode<T>)heightChange.Parent).RightHeight = Math.Max(heightChange.LeftHeight, heightChange.RightHeight) + 1;
                    }
                    heightChange = ((BSTNode<T>)heightChange.Parent);
                }               

                return true;
            }
            return false;
        }
        private bool RotateLeft(BSTNode<T> node)
        {
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
                    if (rightNode.Data.CompareTo(rightNode.Parent.Data) < 0)
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
                    Root = rightNode;
                }

                if (rightNode.LeftNode != null)
                {
                    node.RightNode = rightNode.LeftNode;
                    node.RightNode.Parent = node;
                }
                else
                {
                    node.RightNode = null;
                }

                node.Parent = rightNode;
                rightNode.LeftNode = node;

                //Height change
                if (node.RightNode != null)
                {
                    node.RightHeight = Math.Max((node.RightNode).LeftHeight, (node.RightNode).RightHeight) + 1;
                }
                else
                {
                    node.RightHeight = 0;
                }

                //ToDo spravit private method rovnaka v RoteteRight
                var heightChange = node;
                while (heightChange.Parent != null)
                {
                    if (heightChange.Data.CompareTo(heightChange.Parent.Data) < 0)
                    {
                        ((BSTNode<T>)heightChange.Parent).LeftHeight = Math.Max(heightChange.LeftHeight, heightChange.RightHeight) + 1;
                    }
                    else
                    {
                        ((BSTNode<T>)heightChange.Parent).RightHeight = Math.Max(heightChange.LeftHeight, heightChange.RightHeight) + 1;
                    }
                    heightChange = ((BSTNode<T>)heightChange.Parent);
                }

                return true;
            }

            return false;
        }
        private BSTNode<T>? FindNode(T data)
        {
            var Child = Root;
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
        public bool Delete(T data)
        {
            var removeNode = FindNode(data);
            //Dont found removed Node
            if (removeNode == null)
            {
                return false;
            }
            //Removed leaf Node
            if (removeNode.IsLeaf())
            {
                return DeleteLeaf(removeNode);
            }
            //Removed node has one child
            if (removeNode.LeftNode == null)
            {
                //Removed Node is Root
                if (removeNode.Parent == null)
                {
                    Root = removeNode.RightNode;
                    Root.Parent = null;
                    Count--;
                    return true;
                }
                //Is right or left son of parent
                var compResult = removeNode.Data.CompareTo(removeNode.Parent.Data);
                if (compResult == -1)
                {
                    ((BSTNode<T>)removeNode.Parent).LeftNode = removeNode.RightNode;
                    removeNode.RightNode.Parent = removeNode.Parent;
                }
                else if (compResult == 1)
                {
                    ((BSTNode<T>)removeNode.Parent).RightNode = removeNode.RightNode;
                    removeNode.RightNode.Parent = removeNode.Parent;
                }
                Count--;
                return true;
            }
            if (removeNode.RightNode == null)
            {
                if (removeNode.Parent == null)
                {
                    Root = removeNode.LeftNode;
                    Root.Parent = null;
                    Count--;
                    return true;
                }
                //Is right or left son of parent
                var compResult = removeNode.Data.CompareTo(removeNode.Parent.Data);
                if (compResult == -1)
                {
                    ((BSTNode<T>)removeNode.Parent).LeftNode = removeNode.LeftNode;
                    removeNode.LeftNode.Parent = removeNode.Parent;
                }
                else if (compResult == 1)
                {
                    ((BSTNode<T>)removeNode.Parent).RightNode = removeNode.LeftNode;
                    removeNode.LeftNode.Parent = removeNode.Parent;
                }
                Count--;
                return true;
            }
            //Else search inorderSuccessor
            var inorderSuccessor = removeNode.RightNode;
            var leftChild = removeNode.RightNode;
            while (leftChild != null)
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
                    Count--;
                    return true;
                }
                //Has right child
                removeNode.RightNode = inorderSuccessor.RightNode;
                removeNode.RightNode.Parent = removeNode;
                Count--;
                return true;
            }
            //Inorder succesor is leaf
            if (inorderSuccessor.IsLeaf())
            {
                return DeleteLeaf(inorderSuccessor);
            }
            //Inorder succesor has right child
            inorderSuccessor.RightNode.Parent = inorderSuccessor.Parent;
            ((BSTNode<T>)inorderSuccessor.Parent).LeftNode = inorderSuccessor.RightNode;
            Count--;
            return true;
        }
        private bool DeleteLeaf(BSTNode<T> paLeaf)
        {
            //Removed Node is Root
            if (paLeaf.Parent == null)
            {
                Root = null;
                Count--;
                return true;
            }
            //Removed from parent
            var compResult = paLeaf.Data.CompareTo(paLeaf.Parent.Data);
            if (compResult == -1)
            {
                ((BSTNode<T>)paLeaf.Parent).LeftNode = null;
                Count--;
                return true;
            }
            else if (compResult == 1)
            {
                ((BSTNode<T>)paLeaf.Parent).RightNode = null;
                Count--;
                return true;
            }
            return false;
        }
        private void SetHeight()
        {
            BSTNode<T> current = this.Root;
            Stack<BSTNode<T>> stack = new Stack<BSTNode<T>>();
            //tree is empty
            if (current == null)
            {
                return;
            }
            //iterete tree and set height
            while (current != null || stack.Count > 0)
            {
                //go to left
                while (current != null)
                {
                    stack.Push(current);
                    current.LeftHeight = 0;
                    current.RightHeight = 0;
                    current = current.LeftNode;
                }
                //take right if left is null
                current = stack.Peek();
                current = current.RightNode;
                if(current != null)
                {
                    current.LeftHeight = 0;
                    current.RightHeight = 0;

                }
                //update height when delete node from stack
                var deleteNode = stack.Pop();
                while(this.GetParent(deleteNode) != null)
                {
                    var compResult = deleteNode.Data.CompareTo(this.GetParent(deleteNode).Data);
                    if (compResult == -1)
                    {
                        this.GetParent(deleteNode).LeftHeight =
                            Math.Max(deleteNode.LeftHeight, deleteNode.RightHeight) + 1;
                    }
                    else if (compResult == 1)
                    {
                        this.GetParent(deleteNode).RightHeight =
                            Math.Max(deleteNode.LeftHeight, deleteNode.RightHeight) + 1;
                    }
                    //change delete node to parent
                    deleteNode = this.GetParent(deleteNode);
                }            
            }
        }
        public int GetHeight(T data)
        {
            var node = this.FindNode(data);
            return node.GetHeight();
        }
        public void BalanceTree()
        {
            this.SetHeight();
            BSTIterator<T> inorderIterator = new BSTIterator<T>(this);
            BSTNode<T> current;
            while (inorderIterator.HasNext())
            {
                current = inorderIterator.Path.Dequeue();
                while (Math.Abs(current.GetHeight()) > 1)
                {
                    if (current.GetHeight() > 1)
                    {
                        while(current.RightNode.GetHeight() < 0)
                        {
                            this.RotateRight(current.RightNode);
                            Console.WriteLine("Rotuje {0} doprava",current.RightNode.Data);
                        }
                        this.RotateLeft(current);
                        Console.WriteLine("Rotuje {0} doprava", current.Data);
                    }
                    if (current.GetHeight() < -1)
                    {
                        while (current.LeftNode.GetHeight() > 0)
                        {
                            this.RotateLeft(current.LeftNode);
                            Console.WriteLine("Rotuje {0} dolava", current.LeftNode.Data);
                        }
                        this.RotateRight(current);
                        Console.WriteLine("Rotuje {0} doprava", current.Data);
                    }
                }                
            }
        }
        private BSTNode<T>? GetParent(BSTNode<T> node)
        {

            return node == null ? null : ((BSTNode<T>)node.Parent);
        }
    }
}