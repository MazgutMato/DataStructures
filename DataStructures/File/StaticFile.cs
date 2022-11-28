using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public class StaticFile<T> : BasicFile<T> where T : IData<T>
    {
        public StaticFile(int blockFactor, string fileName) : base(blockFactor, fileName)
        {
            var block = new Block<T>(blockFactor, this.Class.CreateClass());
            this.File.SetLength(blockFactor * block.GetSize());

            ////Create settings file
            //var settings = new FileStream(fileName + ".set",FileMode.Create);
            //MemoryStream memoryStream = new MemoryStream();
            //BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
            //binaryWriter.Write(this.BlockFactor);
            ////Save settings file
            //var bytes = memoryStream.ToArray();
            //File.Seek(0, SeekOrigin.Begin);
            //File.Write(bytes);
        }
        private int GetAdress(BitArray hash)
        {
            if (hash == null)
            {
                throw new ArgumentException("Hash cannot be null!");
            }
            var result = new int[1];
            hash.CopyTo(result, 0);
            return result[0] % this.BlockFactor;
        }
        public override T? Find(T data)
        {
            var hash = data.GetHash();
            var adress = this.GetAdress(hash) * (new Block<T>(this.BlockFactor, this.Class.CreateClass())).GetSize();

            var block = this.LoadBlock(adress);

            for (int i = 0; i < block.ValidCount; i++)
            {
                if (data.IsEqual(block.Records[i]) == true)
                {
                    return block.Records[i];
                }
            }
            return default(T);
        }
        public override bool Add(T data)
        {
            var hash = data.GetHash();
            var adress = this.GetAdress(hash) * (new Block<T>(this.BlockFactor, this.Class.CreateClass())).GetSize(); ;

            var block = this.LoadBlock(adress);

            if (!block.InsertData(data))
            {
                return false;
            }

            if (!this.SaveBlock(adress, block))
            {
                return false;
            }

            this.Count++;
            return true;
        }
        public override bool Delete(T data)
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

                    if (!this.SaveBlock(adress, block))
                    {
                        return false;
                    }
                    this.Count--;
                    return true;
                }
            }

            return false;
        }
        public override string GetBlocks()
        {
            long adress = 0;
            var fileSize = this.FileSize();
            var result = "--------------------------------------------------\n";
            result += "Velkost suboru: " + fileSize + "\n";
            result += "Pocet prvkov: " + this.Count + "\n";
            result += "--------------------------------------------------\n";

            while (adress < fileSize)
            {
                var block = new Block<T>(BlockFactor, Class.CreateClass());

                byte[] blockBytes = new byte[block.GetSize()];

                File.Seek(adress, SeekOrigin.Begin);
                File.Read(blockBytes);

                block.FromByteArray(blockBytes);

                if (block.ValidCount > 0)
                {

                    result += "--------------------------------------------------\n";
                    result += "Block na adrese " + adress + "\n";
                    result += "\t Pocet validnych: " + block.ValidCount + "\n";

                    result += "\t Prvky: \n";

                    for (int i = 0; i < block.ValidCount; i++)
                    {
                        result += "\t\tPrvok(" + i + "):\n\t\t\t" + block.Records[i].ToString() + "\n";
                    }
                    result += "--------------------------------------------------\n";
                }

                adress += block.GetSize();
            }
            return result;
        }
    }
}
