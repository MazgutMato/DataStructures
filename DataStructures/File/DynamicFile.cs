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
        public LinkedList<long> FreeAdresses { get; }
        public DynamicFile(int blockFactor, string fileName) : base(blockFactor, fileName)
        {
            FreeAdresses = new LinkedList<long>();
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
            while (adressNode is InternalNode)
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
            if (adressNode == null || adressNode.Adress == -1)
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
                    var leftNode = new ExternalNode();
                    leftNode.Parent = interNode;
                    leftNode.BlockDepth = adressNode.BlockDepth + 1;
                    interNode.LeftNode = leftNode;

                    //Set rightNode
                    var rightNode = new ExternalNode();
                    rightNode.Parent = interNode;
                    rightNode.BlockDepth = adressNode.BlockDepth + 1;
                    interNode.RightNode = rightNode;

                    //Reorganize adressNode records                    
                    var leftBlock = new Block<T>(BlockFactor, Class.CreateClass());
                    var rightBlock = new Block<T>(BlockFactor, Class.CreateClass());

                    var adressBlock = this.LoadBlock(adressNode.Adress);
                    for (int i = 0; i < adressNode.RecordCount; i++)
                    {
                        if (adressBlock.Records[i].GetHash()[interNode.BlockDepth] == true)
                        {
                            rightBlock.InsertData(adressBlock.Records[i]);
                            rightNode.RecordCount++;
                        } else
                        {
                            leftBlock.InsertData(adressBlock.Records[i]);
                            leftNode.RecordCount++;
                        }
                    }
                    //Check if block is empty
                    if (leftNode.RecordCount < 1)
                    {
                        rightNode.Adress = adressNode.Adress;
                        leftNode.Adress = -1;
                        this.SaveBlock(rightNode.Adress, rightBlock);
                    }
                    else
                    {
                        leftNode.Adress = adressNode.Adress;
                        this.SaveBlock(leftNode.Adress, leftBlock);
                        if(rightNode.RecordCount > 0)
                        {
                            rightNode.Adress = this.FreeAdressGet();
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
                adressNode.Adress = this.FreeAdressGet();
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
            var adressNode = this.GetAdressNode(data);
            if(adressNode == null)
            {
                return false;
            }
            //Delete node
            if(adressNode.RecordCount == 1)
            {
                adressNode.RecordCount = 0;
                //Insert into freeAdresses
                this.FreeAdressInsert(adressNode.Adress);
                //Disable adress
                adressNode.Adress = -1;
            } else
            {
                //Load block and delete data
                var block = this.LoadBlock(adressNode.Adress);
                for (var i = 0; i < this.BlockFactor; i++)
                {
                    if (block.Records[i].IsEqual(data))
                    {
                        block.Records[i] = block.Records[block.ValidCount - 1];
                        block.ValidCount--;
                        adressNode.RecordCount--;
                        this.SaveBlock(adressNode.Adress, block);
                    }
                }
                //Check brother node
                while(adressNode.Parent != null)
                {
                    //Set brother
                    DFNode brother = null; 
                    if(((InternalNode)adressNode.Parent).LeftNode == adressNode)
                    {
                        brother = ((InternalNode)adressNode.Parent).RightNode;
                    } else
                    {
                        brother = ((InternalNode)adressNode.Parent).LeftNode;
                    }
                    //Stop if brother is InterNode
                    if (brother is InternalNode)
                    {
                        break;
                    }
                    var brotherExternal = (ExternalNode)brother;
                    //Consolidate if possible
                    if((adressNode.RecordCount + brotherExternal.RecordCount) <= BlockFactor)
                    {
                        //Load blocks
                        var adressBlock = this.LoadBlock(adressNode.Adress);
                        var brotherBlock = this.LoadBlock(brotherExternal.Adress);
                        for(int i = 0; i < brotherBlock.ValidCount; i++)
                        {
                            adressBlock.InsertData(brotherBlock.Records[i]);
                            adressNode.RecordCount++;
                        }
                        //Write new block
                        this.SaveBlock(adressNode.Adress, adressBlock);
                        //Insert freeAdress
                        this.FreeAdressInsert(brotherExternal.Adress);
                        //Set new reference
                        if(adressNode.Parent.Parent == null)
                        {
                            this.Indexes.Root = adressNode;
                            adressNode.Parent = null;
                        }
                        else
                        {
                            if(adressNode.Parent == ((InternalNode)adressNode.Parent.Parent).LeftNode)
                            {
                                ((InternalNode)adressNode.Parent.Parent).LeftNode = adressNode;
                            } else
                            {
                                ((InternalNode)adressNode.Parent.Parent).RightNode = adressNode;
                            }
                            adressNode.Parent = adressNode.Parent.Parent;
                        }                        
                    }
                    else
                    {
                        break;
                    }
                }
            }            
            return false;
        }
        private bool FreeAdressInsert(long newAdress)
        {
            if(newAdress < 0)
            {
                throw new InvalidOperationException("Invalid adress!");
            }
            //FileCut
            var sampleBLock = new Block<T>(BlockFactor, Class.CreateClass());
            if(newAdress == (this.FileSize() - sampleBLock.GetSize()) ){
                this.File.SetLength(newAdress);
                var successorAdress = newAdress - sampleBLock.GetSize();
                var successorNode = FreeAdresses.Find(successorAdress);
                while(successorNode != null)
                {
                    this.File.SetLength(successorAdress);
                    FreeAdresses.Remove(successorAdress);
                    successorAdress = successorAdress - sampleBLock.GetSize();
                    successorNode = FreeAdresses.Find(successorAdress);
                }
                return true;
            }
            //Find before adress
            var adressNode = FreeAdresses.First;
            while (adressNode != null) { 
                if(adressNode.Value > newAdress)
                {
                    break;
                }
                adressNode = adressNode.Next;
            }
            //Save into freeAdrese
            if (adressNode != null)
            {
                FreeAdresses.AddBefore(adressNode, newAdress);
            }
            else
            {
                FreeAdresses.AddLast(newAdress);
            }
            return true;
        }
        private long FreeAdressGet()
        {
            if(FreeAdresses.Count > 0)
            {
                var value = this.FreeAdresses.Last.Value;
                FreeAdresses.RemoveLast();
                return value;
            } else
            {
                return this.FileSize();
            }
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
