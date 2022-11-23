using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface Structure<T>
    {
        public bool Add(T data);
        public bool Delete(T data);
        public T? Find(T data);
    }
}
