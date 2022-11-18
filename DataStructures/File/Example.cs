﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public class Example : IData<Example>
    {
        public int ID { get; set; }
        public Example()
        {
            ID = 1;
        }

        public BitArray GetHash()
        {
            BitArray hash = new BitArray(new int[] { this.ID });
            return hash;
        }

        public int GetSize()
        {
            return sizeof(int);
        }

        public byte[] ToByteArray()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(this.ID);

            return memoryStream.ToArray();
        }

        Example IData<Example>.CreateClass()
        {
            return new Example();
        }

        public bool Compare(Example data)
        {
            return data.ID == this.ID;
        }

        public void FromByteArray(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            this.ID = binaryReader.ReadInt32();
        }
    }
}
