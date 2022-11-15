using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataStructures.File
{
    public class Block<T> : IRecord<T> where T : IData<T>
    {
        private int BlockFactor;
        private int ValidCount;
        public List<T> Records { get; }
        private T ClassType;

        public Block(int blockFactor, T classType)
        {
            BlockFactor = blockFactor;            
            ClassType = classType;

            this.Records = new List<T>();
            for (int i = 0; i < BlockFactor; i++)
            {
                this.Records.Add(ClassType.CreateClass());
            }
            this.ValidCount = 0;
        }

        public T FromByteArray(byte[] byteArray)
        {
            throw new NotImplementedException();
        }

        public int GetSize()
        {
            throw new NotImplementedException();
        }

        public byte[] ToByteArray()
        {
            throw new NotImplementedException();
        }
    }
}
