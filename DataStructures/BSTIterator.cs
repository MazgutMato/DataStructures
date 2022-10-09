using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BSTIterator<T> where T : IComparable<T>
    {
        private Queue<BSTNode<T>> Path;

        public BSTIterator(BSTNode<T> root)
        {
            this.Path = new Queue<BSTNode<T>>();
        }
    }
}
