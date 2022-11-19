using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface Structure<D>
    {
        public bool Add(D data);
        public bool Delete(D data);
        public D Find(D data);
    }
}
