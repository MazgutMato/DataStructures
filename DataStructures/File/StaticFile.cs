using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public class StaticFile<T> where T : IData<T>
    {   
        public int BlockFactor { get; } 
        public FileStream File { get; }
        public StaticFile(int blockFactor, string fileName)
        {
            BlockFactor = blockFactor;
            File = new FileStream(fileName, FileMode.Create);
        }
        public T? Find(T data)
        {
            Block<T> block = new Block<T>(BlockFactor, data.CreateClass());

            BitArray hash = data.GetHash();

            byte[] blockBytes = new byte[block.GetSize()];

            //file.seek(adresa bloku)
            File.Read(blockBytes);

            block.FromByteArray(blockBytes);
            
            //ValidCount control
            foreach(var record in block.Records)
            {
                if(data.Equals(record) == true)
                {
                    return record;
                }
            }
            return default(T);
        }
    }
}
