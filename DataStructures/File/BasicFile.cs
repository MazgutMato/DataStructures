using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public class BasicFile<T> where T : IData<T>
    {
        public int BlockFactor { get; }
        public FileStream File { get; }
        public T Class { get; }
        public BasicFile(int blockFactor, string fileName)
        {
            BlockFactor = blockFactor;
            File = new FileStream(fileName, FileMode.Create);
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
        public virtual string GetBlocks()
        {
            long adress = 0;
            var fileSize = this.FileSize();
            var result = "--------------------------------------------------\n";
            result += "Velkost suboru: " + fileSize + "\n";
            result += "--------------------------------------------------\n";

            while (adress < fileSize)
            {
                var block = new Block<T>(BlockFactor, Class.CreateClass());

                byte[] blockBytes = new byte[block.GetSize()];

                File.Seek(adress, SeekOrigin.Begin);
                File.Read(blockBytes);

                block.FromByteArray(blockBytes);

                result += "--------------------------------------------------\n";
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
                result += "--------------------------------------------------\n";
            }            
            return result;
        }
    }
}
