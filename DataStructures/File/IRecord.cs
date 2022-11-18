using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public interface IRecord<T>
    {
        public byte[] ToByteArray();
        public void FromByteArray(byte[] byteArray);
        public int GetSize();
    }
}
