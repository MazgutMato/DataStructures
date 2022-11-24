using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public class StaticFile<T> : BasicFile<T>, Structure<T> where T : IData<T>
    {
        public StaticFile(int blockFactor, string fileName) : base(blockFactor, fileName) { }
        private int GetAdress(BitArray hash) {
            if (hash == null)
            {
                throw new ArgumentException("Hash cannot be null!");
            }              
            var result = new int[1];
            hash.CopyTo(result, 0);
            return result[0] % this.BlockFactor;
        }
        public T? Find(T data)
        {
            var hash = data.GetHash();
            var adress = this.GetAdress(hash) * (new Block<T>(this.BlockFactor, this.Class.CreateClass())).GetSize();

            var block = this.LoadBlock(adress);
            
            for(int i = 0; i < block.ValidCount; i++)
            {
                if (data.IsEqual(block.Records[i]) == true)
                {
                    return block.Records[i];
                }
            }
            return default(T);
        }
        public bool Add(T data)
        {
            var hash = data.GetHash();
            var adress = this.GetAdress(hash) * (new Block<T>(this.BlockFactor, this.Class.CreateClass())).GetSize(); ;

            var block = this.LoadBlock(adress);

            if (!block.InsertData(data))
            {
                return false;
            }
            
            return this.SaveBlock(adress, block);
        }
        public bool Delete(T data)
        {            
            var hash = data.GetHash();
            var adress = this.GetAdress(hash) * (new Block<T>(this.BlockFactor, this.Class.CreateClass())).GetSize(); ;

            var block = this.LoadBlock(adress);

            for (int i = 0; i < block.ValidCount; i++)
            {
                if (data.IsEqual(block.Records[i]) == true)
                {
                    if (i == block.ValidCount - 1)
                    {
                        block.ValidCount--;
                    }
                    else
                    {
                        block.Records[i] = block.Records[block.ValidCount - 1];
                        block.ValidCount--;
                    }

                    this.SaveBlock(adress, block);
                    return true;
                }
            }

            return false;
        }
    }
}
