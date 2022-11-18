using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public interface IData<T> : IRecord<T>
    {
        public BitArray GetHash();
        public bool Compare(T data);
        public T CreateClass();
    }
}
