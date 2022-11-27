using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public abstract class BasicFile<T> : Structure<T> where T : IData<T>
    {
        public int BlockFactor { get; set; }
        public FileStream File { get; }
        public T Class { get; }
        public int Count { get; set; }
        public BasicFile(int blockFactor, string fileName)
        {
            Count = 0;
            BlockFactor = blockFactor;
            File = new FileStream(fileName + ".dat", FileMode.Create);
            Class = Activator.CreateInstance<T>();
        }
        public BasicFile(string fileName)
        {
            File = new FileStream(fileName + ".dat", FileMode.Open);
            Class = Activator.CreateInstance<T>();
        }
        public Block<T> LoadBlock(long adress)
        {
            var block = new Block<T>(this.BlockFactor, Class.CreateClass());
            byte[] blockBytes = new byte[block.GetSize()];

            File.Seek(adress, SeekOrigin.Begin);
            File.Read(blockBytes);

            block.FromByteArray(blockBytes);
            return block;
        }
        public bool SaveBlock(long adress, Block<T> block)
        {
            if(adress < 0)
            {
                throw new InvalidOperationException("Adress cannot be negative number!");
            }
            File.Seek(adress, SeekOrigin.Begin);
            File.Write(block.ToByteArray());
            return true;
        }
        public long FileSize()
        {
            try
            {
                return File.Length;
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
            }
            return -1;
        }
        public abstract string GetBlocks();
        public abstract bool Add(T data);
        public abstract bool Delete(T data);
        public abstract T? Find(T data);        
    }
}
