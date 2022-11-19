using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public abstract class Tree<D,N> : Structure<D>
    {
        public int Count { get; set; }
        protected N? Root { get; set; }
        public abstract bool Add(D data);
        public abstract bool Delete(D data);
        public abstract D Find(D data);
    }
}
