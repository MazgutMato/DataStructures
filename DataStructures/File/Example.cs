using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public class Example : IData<Example>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int NameValidChar { get; set; }
        public int NameMaxCHat { get; } = 15;
        public Example()
        {
            ID = 0;
            Name = "Example";
            NameValidChar = Name.Length;
        }
        public bool Equals(Example data)
        {
            return data.ID == this.ID;
        }

        public BitArray GetHash()
        {
            BitArray hash1 = new BitArray(this.ID);
            BitArray hash2 = new BitArray(new int[] {this.ID});
            return hash1;
        }

        public int GetSize()
        {
            
        }

        public byte[] ToByteArray()
        {
            throw new NotImplementedException();
        }

        Example IData<Example>.CreateClass()
        {
            throw new NotImplementedException();
        }

        Example IRecord<Example>.FromByteArray(byte[] byteArray)
        {
            throw new NotImplementedException();
        }
    }
}
