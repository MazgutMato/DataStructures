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
            this.DataFile.SetLength(blockFactor * block.GetSize());            
        }
        public StaticFile(string fileName) : base(fileName) {
            var input = new StreamReader(this.SettingsFile);
            var line = input.ReadLine();
            var values = line?.Split(';');
            this.BlockFactor = Convert.ToInt32(values?[0]);
            this.Count= Convert.ToInt32(values?[1]);
            this.SettingsFile.Close();
            this.SettingsFile = new FileStream(fileName + ".set", FileMode.Create);
        }
        private long GetAdress(BitArray hash)
        {
            if (hash == null)
            {
                throw new ArgumentException("Hash cannot be null!");
            }
            var array = new byte[8];
            hash.CopyTo(array, 0);
            return BitConverter.ToInt64(array, 0) % this.BlockFactor;
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
        public override string ToString()
        {
            var result = "--------------------------------------------------\n";
            result += "Velkost suboru: " + this.FileSize() + "\n";
            result += "Block factor: " + this.BlockFactor + "\n";
            result += "Pocet prvkov: " + this.Count + "\n";
            result += "--------------------------------------------------\n";
            result += this.GetBlocksSequense();
            return result;
        }
        public override bool SaveFile()
        {
            //Save blockfactor and count
            var output = new StringBuilder();
            output.AppendLine(this.BlockFactor + ";" + this.Count + ";");
            //Save to settings file
            try
            {
                var bytes = Encoding.ASCII.GetBytes(output.ToString());
                SettingsFile.Write(bytes, 0, bytes.Length);
                SettingsFile.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            DataFile.Close();
            return true;
        }
    }
}
