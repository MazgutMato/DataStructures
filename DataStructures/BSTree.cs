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
            var BeforeNode = this.Root;
            var AfterNode = this.Root;

            while (AfterNode != null) {
                BeforeNode = AfterNode;
                int compResult = data.CompareTo(AfterNode.Data);

                if (compResult == 1)
                {
                    AfterNode = AfterNode.RightNode;
                }
                else if (compResult == -1)
                {
                    AfterNode = AfterNode.LeftNode;
                }
                else {
                    return false;
                }
            }

            if (BeforeNode == null)
            {
                this.Root = new BSTNode<T>(data);
            } else
            {
                var newPosition = data.CompareTo(BeforeNode.Data);
                if (newPosition == 1) {
                    BeforeNode.RightNode = new BSTNode<T>(data, BeforeNode);
                } else
                {
                    BeforeNode.LeftNode = new BSTNode<T>(data, BeforeNode);
                }
            }

            return true;
        }
        public T Find(T data) {
            var afterNode = this.Root;
            T findNode = default(T);

            while (afterNode != null && findNode == null)
            {
                int compResult = data.CompareTo(afterNode.Data);
                if (compResult == 0)
                {
                    findNode = afterNode.Data;
                }
                else if (compResult == 1)
                {
                    afterNode = afterNode.RightNode;
                }
                else { 
                    afterNode = afterNode.LeftNode;
                }
            }

            return findNode;
        }
    }
}