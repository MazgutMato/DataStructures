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
        public FileStream DataFile { get; }
        public FileStream SettingsFile { get; set; }
        public T Class { get; }
        public int Count { get; set; }
        public BasicFile(int blockFactor, string fileName)
        {
            //Data
            Count = 0;
            BlockFactor = blockFactor;
            DataFile = new FileStream(fileName + ".dat", FileMode.Create);
            Class = Activator.CreateInstance<T>();
            //Settings
            SettingsFile = new FileStream(fileName + ".set", FileMode.Create);
        }
        public BasicFile(string fileName)
        {
            //Data
            DataFile = new FileStream(fileName + ".dat", FileMode.Open);
            Class = Activator.CreateInstance<T>();
            //Settings
            SettingsFile = new FileStream(fileName + ".set", FileMode.Open);
        }
        public Block<T> LoadBlock(long adress)
        {
            var block = new Block<T>(this.BlockFactor, Class.CreateClass());
            byte[] blockBytes = new byte[block.GetSize()];

            DataFile.Seek(adress, SeekOrigin.Begin);
            DataFile.Read(blockBytes);

            block.FromByteArray(blockBytes);
            return block;
        }
        public bool SaveBlock(long adress, Block<T> block)
        {
            if(adress < 0)
            {
                throw new InvalidOperationException("Adress cannot be negative number!");
            }
            DataFile.Seek(adress, SeekOrigin.Begin);
            DataFile.Write(block.ToByteArray());
            return true;
        }
        public long FileSize()
        {
            try
            {
                return DataFile.Length;
            }
            catch (Exception ex)
            {
                var message = ex.Message.ToString();
            }
            return -1;
        }
        public string GetBlocksSequense() {
            long adress = 0;
            var fileSize = this.FileSize();
            var result = "";

            while (adress < fileSize)
            {
                var block = new Block<T>(BlockFactor, Class.CreateClass());

                byte[] blockBytes = new byte[block.GetSize()];

                DataFile.Seek(adress, SeekOrigin.Begin);
                DataFile.Read(blockBytes);

                block.FromByteArray(blockBytes);


                result += "--------------------------------------------------\r\n";
                result += "Block na adrese " + adress + "\r\n";
                result += "Pocet validnych: " + block.ValidCount + "\r\n";

                result += "Prvky: \r\n";

                for (int i = 0; i < block.ValidCount; i++)
                {
                    result += "Prvok(" + i + "):\r\n" + block.Records[i].ToString() + "\n";
                }
                result += "--------------------------------------------------\r\n";

                adress += block.GetSize();
            }
            return result;
        }
        public abstract bool Add(T data);
        public abstract bool Delete(T data);
        public abstract T? Find(T data);
        public abstract bool SaveFile();
    }
}
