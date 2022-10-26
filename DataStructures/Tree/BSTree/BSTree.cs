using DataStructures.Iterator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DataStructures.Tree.BSTree
{
    public class BSTree<T> : Iterable<T> where T : IComparable<T>
    {
        public BSTNode<T> Root { get; set; }
        public int Count { get; set; }
        public Iterator<T> createIterator()
        {
            return new BSTIterator<T>(this);
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
            if (findNode != null && data.CompareTo(findNode.Data) == 0)
            {
                return findNode.Data;
            }
            return default;
        }
        public bool FindRange(T min, T max, ICollection<T> structure)
        {
            return this.FindNodeRange(this.Root, min, max, structure);            
        }
        private bool FindNodeRange(BSTNode<T> node,T min, T max, ICollection<T> structure)
        {
            BSTNode<T> current = this.Root;
            Stack<BSTNode<T>> stack = new Stack<BSTNode<T>>();

            if (current == null)
            {
                return false;
            }

            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {                    
                    if(current.Data.CompareTo(min) >= 0)
                    {
                        stack.Push(current);
                        current = current.LeftNode;
                    } else
                    {
                        current = null;
                    }
                }                
                while(current == null && stack.Count > 0){
                    current = stack.Pop();
                    if(current.Data.CompareTo(max) <= 0)
                    {
                        structure.Add(current.Data);
                    }                    
                    current = current.RightNode;
                }
            }

            return true;

            //int cmpLow = min.CompareTo(node.Data);
            //int cmpHigh = max.CompareTo(node.Data);

            //if (cmpLow < 0)
            //{
            //    FindNodeRange(node.LeftNode, min, max, structure);
            //}
            //if (cmpLow <= 0 && cmpHigh >= 0)
            //{
            //    structure.Add(node.Data);
            //}
            //if (cmpHigh > 0)
            //{
            //    FindNodeRange(node.RightNode, min, max, structure);
            //}

            //return true;
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
                        this.GetParent(heightChange).LeftHeight = Math.Max(heightChange.LeftHeight, heightChange.RightHeight) + 1;
                    }
                    else
                    {
                        this.GetParent(heightChange).RightHeight = Math.Max(heightChange.LeftHeight, heightChange.RightHeight) + 1;
                    }
                    heightChange = this.GetParent(heightChange);
                }

                return true;
            }

            return false;
        }
        private BSTNode<T>? FindNode(T data)
        {
            var findNode = this.Root;

            while (findNode != null)
            {                
                int compResult = data.CompareTo(findNode.Data);
                if (compResult == 0)
                {
                    return findNode;
                }
                else if (compResult == 1)
                {                    
                    findNode = findNode.RightNode;
                }
                else
                {   
                    findNode = findNode.LeftNode;
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
        public int GetNodeHeight(T data)
        {
            var node = this.FindNode(data);
            return node.GetHeight();
        }
        public void BalanceTree()
        {
            //Make levelorder traversal
            var queue = new Queue<BSTNode<T>>();
            var levelOrder = new Stack<BSTNode<T>>();   
            
            if(this.Root == null)
            {
                return;
            }

            queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                var topNode = queue.Dequeue();

                levelOrder.Push(topNode);

                if(topNode.LeftNode != null)
                {
                    queue.Enqueue(topNode.LeftNode);
                }

                if (topNode.RightNode != null)
                {
                    queue.Enqueue(topNode.RightNode);
                }
            }
            //Balance tree
            BSTNode<T> current;
            while (levelOrder.Count > 0)
            {
                current = levelOrder.Pop();
                //HightSet
                if(current.LeftNode != null)
                {
                    current.LeftHeight = Math.Max(current.LeftNode.LeftHeight, current.LeftNode.RightHeight) + 1;
                } else
                {
                    current.LeftHeight = 0;
                }
                if (current.RightNode != null)
                {
                    current.RightHeight = Math.Max(current.RightNode.LeftHeight, current.RightNode.RightHeight) + 1;
                }
                else
                {
                    current.RightHeight = 0;
                }
                //HightCheck
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
        public bool FillWithMedian(List<T> structure)
        {
            if(this.Count > 0)
            {
                return false;
            }
            structure.Sort();
            return this.FindMedian(0, structure.Count - 1, structure);
        }
        private bool FindMedian(int min, int max, List<T> structure)
        {
            if (min <= max)
            {
                var median = (min + max) / 2;
                this.Add(structure[median]);
                FindMedian(min, median - 1, structure);
                FindMedian( median + 1, max,structure);
                return true;
            }
            return false;
        }
    }
}