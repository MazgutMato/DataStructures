using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public abstract class Tree<D> : Structure<D>
    {
        public int Count { get; set; }
        protected TreeNode<D>? Root { get; set; }
        public abstract bool Add(D data);
        public abstract bool Delete(D data);
        public abstract D Find(D data);
    }
}
