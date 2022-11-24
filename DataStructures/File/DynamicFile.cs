using DataStructures.Tree.DFTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.File
{
    public class DynamicFile<T> : BasicFile<T>, Structure<T> where T : IData<T>
    {
        public DFTree Indexes { get; }
        public DynamicFile(int blockFactor, string fileName) : base(blockFactor, fileName)
        {
            Indexes = new DFTree(blockFactor);
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
            var adressNode = this.GetAdressNode(data);

            //File is empty
            if (adressNode == null)
            {
                return default(T);
            }
            
            var block = this.LoadBlock(adressNode.Adress);

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
            var adressNode = this.GetAdressNode(data);

            //File is epmty
            if (adressNode == null)
            {
                adressNode = new ExternalNode();
                adressNode.Adress = this.FileSize();
                this.Indexes.Root = adressNode;
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
                        }
                        else
                        {
                            ((InternalNode)adressNode.Parent).RightNode = interNode;
                        }
                    }
                    //Set blockDepth
                    interNode.BlockDepth = adressNode.BlockDepth;

                    //Set leftNode
                    var leftNode = adressNode;
                    leftNode.Parent = interNode;
                    leftNode.BlockDepth++;
                    interNode.LeftNode = adressNode;

                    //Set rightNode
                    var rightNode = new ExternalNode();
                    rightNode.Parent = interNode;
                    rightNode.BlockDepth = adressNode.BlockDepth;
                    interNode.RightNode = rightNode;

                    //Reorganize adressNode records
                    var leftBlock = this.LoadBlock(leftNode.Adress);
                    var rightBlock = new Block<T>(BlockFactor, Class.CreateClass());

                    var validCount = leftNode.RecordCount;
                    for (int i = 0; i < validCount; i++)
                    {
                        if (leftBlock.Records[i].GetHash()[interNode.BlockDepth] == true)
                        {
                            rightBlock.InsertData(leftBlock.Records[i]);
                            rightNode.RecordCount++;

                            leftBlock.Records[i] = leftBlock.Records[leftBlock.ValidCount - 1];
                            leftBlock.ValidCount--;
                            leftNode.RecordCount--;
                        }
                    }
                    //Check if block is empty
                    if (leftNode.RecordCount < 1)
                    {
                        rightNode.Adress = leftNode.Adress;
                        leftNode.Adress = -1;
                        this.SaveBlock(rightNode.Adress, rightBlock);
                    }
                    else
                    {
                        this.SaveBlock(leftNode.Adress, leftBlock);
                        if(rightNode.RecordCount > 0)
                        {
                            rightNode.Adress = this.FileSize();
                            this.SaveBlock(rightNode.Adress, rightBlock);
                        }
                    }
                    //Set another adress node
                    if (data.GetHash()[interNode.BlockDepth] == true)
                    {
                        adressNode = rightNode;
                    } else
                    {
                        adressNode = leftNode;
                    }

                }

            }
            //Read adress node and add data
            var block = new Block<T>(this.BlockFactor, Class.CreateClass());
            if(adressNode.Adress == -1)
            {
                adressNode.Adress = this.FileSize();
            } else
            {
                block = this.LoadBlock(adressNode.Adress);
            }
            if (block.InsertData(data))
            {
                adressNode.RecordCount++;
            } else
            {
                throw new InvalidOperationException("Data was not inserted!");                
            }

            //Write block to file
            this.SaveBlock(adressNode.Adress, block);
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
