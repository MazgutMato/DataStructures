using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BSTIterator<T> where T : IComparable<T>
    {
        public Queue<BSTNode<T>> Path;

        public BSTIterator(BSTNode<T> root)
        {
            this.Path = new Queue<BSTNode<T>>();
            this.GenerateInorderPath(root);
        }
        private void GenerateInorderPath(BSTNode<T> root)
        {
            BSTNode<T> current = root;
            if(current != null)
            {
                this.GenerateInorderPath(current.LeftNode);
                this.Path.Enqueue(current);
                this.GenerateInorderPath(current.RightNode);
            }
        }
        public T GetNext()
        {
            return this.Path.Dequeue().Data;
        }
    }
}
