using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;

namespace DataStructures.File
{
    public class Block<T> : IRecord<T> where T : IData<T>
    {
        private int BlockFactor;
        public int ValidCount { get; set; }
        public List<T> Records { get; }
        private T ClassType;

        public Block(int blockFactor, T classType)
        {
            BlockFactor = blockFactor;            
            ClassType = classType.CreateClass();

            this.Records = new List<T>();
            for (int i = 0; i < BlockFactor; i++)
            {
                this.Records.Add(ClassType.CreateClass());
            }
            this.ValidCount = 0;
        }
        public bool InsertData(T data)
        {
            if(ValidCount < BlockFactor)
            {
                Records[ValidCount] = data;
                ValidCount++;
                return true;
            }
            return false;
        }

        public byte[] ToByteArray()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
          
            binaryWriter.Write(this.ValidCount);
            for (int i = 0; i < this.BlockFactor; i++)
            {
                binaryWriter.Write(this.Records[i].ToByteArray());
            }

            return memoryStream.ToArray();
        }

        public void FromByteArray(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            BinaryReader binaryReader= new BinaryReader(memoryStream);

            this.ValidCount = binaryReader.ReadInt32();
            for (int i = 0; i < this.BlockFactor; i++)
            {
                this.Records[i].FromByteArray(binaryReader.ReadBytes(this.ClassType.GetSize()));
            }
        }

        public int GetSize()
        {
            return ClassType.GetSize() * BlockFactor + sizeof(int);
        }
    }
}
