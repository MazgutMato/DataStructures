using DataStructures.Tree.DFTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public class DynamicFile<T> : Structure<T> where T : IData<T>
    {
        public int BlockFactor { get; }
        public FileStream File { get; }
        public DFTree Indexes { get; }
        public DynamicFile(int blockFactor, string fileName)
        {
            BlockFactor = blockFactor;
            File = new FileStream(fileName, FileMode.Create);
            Indexes = new DFTree(blockFactor);
        }
        public DFNode? GetAdressNode(T data)
        {
            //Index
            var hash = data.GetHash();
            var hashInt = new int[1];
            hash.CopyTo(hashInt, 0);
            hashInt[0] = hashInt[0] % 32;
            var index = new BitArray(hashInt);

            //Find block adress
            var adressNode = Indexes.Root;
            if (adressNode == null)
            {
                return null;
            }
            while (adressNode.LeftNode != null && adressNode.RightNode != null)
            {
                if (index[adressNode.BlockDepth] == false)
                {
                    adressNode = adressNode.LeftNode;
                }
                else
                {
                    adressNode = adressNode.RightNode;
                }
            }
            return adressNode;
        }
        public T? Find(T data)
        {
            var block = new Block<T>(BlockFactor, data.CreateClass());

            var adressNode = this.GetAdressNode(data);

            if(adressNode == null)
            {
                return default(T);
            }

            byte[] blockBytes = new byte[block.GetSize()];

            File.Seek(adressNode.Adress * block.GetSize(), SeekOrigin.Begin);
            File.Read(blockBytes);

            block.FromByteArray(blockBytes);

            for (int i = 0; i < block.ValidCount; i++)
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

            var adressNode = this.GetAdressNode(data);

            if(adressNode == null)
            {
                adressNode = new DFNode();
                this.Indexes.Root = adressNode;
            }

            byte[] blockBytes = new byte[block.GetSize()];

            File.Seek(adressNode.Adress * block.GetSize(), SeekOrigin.Begin);
            File.Read(blockBytes);

            block.FromByteArray(blockBytes);
            block.ValidCount = adressNode.RecordCount;

            if (!block.InsertData(data))
            {
                return false;
            }

            //File.Seek(adress * block.GetSize(), SeekOrigin.Begin);
            File.Write(block.ToByteArray());
            return true;
        }
        public bool Delete(T data)
        {           
            return false;
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
    }
}
