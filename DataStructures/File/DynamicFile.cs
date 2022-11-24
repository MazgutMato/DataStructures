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

            //Find block adress
            var adressNode = Indexes.Root;
            if (adressNode == null)
            {
                return null;
            }
            while (adressNode.GetType() != (new ExternalNode()).GetType())
            {
                if (hash[adressNode.BlockDepth] == false)
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
            var block = new Block<T>(BlockFactor, Class.CreateClass());

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
            var block = new Block<T>(BlockFactor, Class.CreateClass());

            var adressNode = this.GetAdressNode(data);

            //File is epmty
            if (adressNode == null)
            {
                adressNode = new ExternalNode();
                adressNode.Adress = this.FileSize();
                adressNode.RecordCount++;
                this.Indexes.Root = adressNode;
                block.InsertData(data);
            }
            else
            {
                //External node in full
                while (adressNode.RecordCount == BlockFactor)
                {
                    var interNode = new InternalNode();
                    //Node is root
                    if (adressNode.Parent == null)
                    {
                        this.Indexes.Root = interNode;
                    }
                    else
                    {
                        interNode.Parent = adressNode.Parent;
                        //Left or right son of parent
                        if (adressNode == ((InternalNode)adressNode.Parent).LeftNode)
                        {
                            ((InternalNode)adressNode.Parent).LeftNode = interNode;
                        } else
                        {
                            ((InternalNode)adressNode.Parent).RightNode = interNode;
                        }
                        //Set blockDepth
                        interNode.BlockDepth = adressNode.BlockDepth;
                        //Set leftNode                        
                        adressNode.Parent = interNode;
                        adressNode.BlockDepth++;
                        interNode.LeftNode = adressNode;
                        //Set rightNode
                        var rightNode = new ExternalNode();
                        rightNode.Parent = interNode;
                        rightNode.BlockDepth = adressNode.BlockDepth;
                        rightNode.Adress = this.FileSize();
                        interNode.RightNode = rightNode;
                    }
                }
                byte[] blockBytes = new byte[block.GetSize()];

                File.Seek(adressNode.Adress, SeekOrigin.Begin);
                File.Read(blockBytes);

                block.FromByteArray(blockBytes);
                block.InsertData(data);

            }
            //Write block to file
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
