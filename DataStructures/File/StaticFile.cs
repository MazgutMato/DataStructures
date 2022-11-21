using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public class StaticFile<T> : Structure<T> where T : IData<T>
    {   
        public int BlockFactor { get; } 
        public FileStream File { get; }
        public StaticFile(int blockFactor, string fileName)
        {
            BlockFactor = blockFactor;
            File = new FileStream(fileName, FileMode.Create);
        }
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
            var block = new Block<T>(BlockFactor, data.CreateClass());
            var hash = data.GetHash();
            var adress = this.GetAdress(hash);

            byte[] blockBytes = new byte[block.GetSize()];

            File.Seek(adress*block.GetSize(), SeekOrigin.Begin);
            File.Read(blockBytes);

            block.FromByteArray(blockBytes);
            
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
            var block = new Block<T>(BlockFactor, data.CreateClass());
            var hash = data.GetHash();
            var adress = this.GetAdress(hash);

            byte[] blockBytes = new byte[block.GetSize()];

            File.Seek(adress*block.GetSize(), SeekOrigin.Begin);
            File.Read(blockBytes);

            block.FromByteArray(blockBytes);

            if (!block.InsertData(data))
            {
                return false;
            }

            File.Seek(adress*block.GetSize(), SeekOrigin.Begin);
            File.Write(block.ToByteArray());
            return true;
        }
        public bool Delete(T data)
        {
            var block = new Block<T>(BlockFactor, data.CreateClass());
            var hash = data.GetHash();
            var adress = this.GetAdress(hash);

            byte[] blockBytes = new byte[block.GetSize()];

            File.Seek(adress * block.GetSize(), SeekOrigin.Begin);
            File.Read(blockBytes);

            block.FromByteArray(blockBytes);

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

                    File.Seek(adress * block.GetSize(), SeekOrigin.Begin);
                    File.Write(block.ToByteArray());
                    return true;
                }
            }

            return false;
        }
        public long FileSize()
        {
            try
            {
                return File.Length;
            } catch (Exception ex)
            {
                var message = ex.Message.ToString();
            }
            return -1;
        }
        public string GetBlocks(T data)
        {
            long adress = 0;
            var fileSize = this.FileSize();
            var result = "";

            while(adress < fileSize)
            {
                var block = new Block<T>(BlockFactor, data.CreateClass());

                byte[] blockBytes = new byte[block.GetSize()];

                File.Seek(adress, SeekOrigin.Begin);
                File.Read(blockBytes);

                block.FromByteArray(blockBytes);

                result += "Block na adrese " + adress + "\n";
                result += "\t Pocet validnych: " + block.ValidCount + "\n";

                if (block.ValidCount > 0)
                {
                    result += "\t Prvky: \n";

                    for (int i = 0; i < block.ValidCount; i++)
                    {
                        result += "\t\tPrvok(" + i + "):\n\t\t\t" + block.Records[i].ToString() + "\n";
                    }
                }

                adress += block.GetSize();
            }
            return result;
        }
    }
}
