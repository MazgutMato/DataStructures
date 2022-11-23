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
        public T Class { get; }
        public DynamicFile(int blockFactor, string fileName)
        {
            BlockFactor = blockFactor;
            File = new FileStream(fileName, FileMode.Create);
            Indexes = new DFTree(blockFactor);
            Class = Activator.CreateInstance<T>();
        }
        public ExternalNode? GetAdressNode(T data)
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
            while (adressNode.GetType() !=  (new ExternalNode()).GetType())
            {
                if (index[adressNode.BlockDepth] == false)
                {
                    adressNode = ((InternalNode)adressNode).LeftNode;
                }
                else
                {
                    adressNode = ((InternalNode)adressNode).RightNode;
                }
            }
            return (ExternalNode)adressNode;            
        }
        public T? Find(T data)
        {
            var block = new Block<T>(BlockFactor, data.CreateClass());

            var adressNode = this.GetAdressNode(data);

            //File is empty
            if (adressNode == null)
            {
                return default(T);
            }

            byte[] blockBytes = new byte[block.GetSize()];

            File.Seek(adressNode.Adress, SeekOrigin.Begin);
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

            //File is epmty
            if (adressNode == null)
            {
                adressNode = new ExternalNode();
                adressNode.Adress = this.FileSize();
                this.Indexes.Root = adressNode;

            }

            byte[] blockBytes = new byte[block.GetSize()];

            File.Seek(adressNode.Adress, SeekOrigin.Begin);
            File.Read(blockBytes);

            block.FromByteArray(blockBytes);

            //External node in full
            if (!block.InsertData(data))
            {
                var interNode = new InternalNode();
                //Node is root
                if(adressNode.Parent == null)
                {                  
                    this.Indexes.Root = interNode;
                } else
                {
                    interNode.Parent = adressNode.Parent;
                }                
            }

            File.Seek(adressNode.Adress, SeekOrigin.Begin);
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
