using DataStructures.Tree.DFTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures.File
{
    public class DynamicFile<T> : BasicFile<T> where T : IData<T>
    {
        public DFTree Indexes { get; }
        public LinkedList<long> FreeAdresses { get; }
        public DynamicFile(int blockFactor, string fileName) : base(blockFactor, fileName)
        {
            FreeAdresses = new LinkedList<long>();
            Indexes = new DFTree(blockFactor);
        }
        public DynamicFile(string fileName) : base(fileName)
        {            
            var input = new StreamReader(this.SettingsFile);
            //Read blockFactor and count
            var line = input.ReadLine();
            var values = line?.Split(';');
            this.BlockFactor = Convert.ToInt32(values?[0]);
            this.Count = Convert.ToInt32(values?[1]);
            FreeAdresses = new LinkedList<long>();
            Indexes = new DFTree(this.BlockFactor);
            //Read free blocks
            line = input.ReadLine();
            values = line?.Split(';');
            if (values[0] != "0")
            {
                for(var i = 1; i < values.Length - 1; i++)
                {
                    this.FreeAdresses.AddLast(Convert.ToInt32(values[i]));
                }
            }
            //Read externalNodes
            line = input.ReadLine();
            while (line != null)
            {
                values = line?.Split(';');                
                if (values[0] == "")
                {
                    var node = new ExternalNode();
                    if (values[1] != "-1")
                    {
                        node.Adress = Convert.ToInt32(values[1]);
                        node.RecordCount = Convert.ToInt32(values[2]);
                    }
                    this.Indexes.Root = node;
                }
                else
                {
                    if(this.Indexes.Root == null)
                    {
                        this.Indexes.Root = new InternalNode();
                    }
                    var node = this.Indexes.Root;
                    for(var i = 0; i < values[0].Length - 1; i++)
                    {
                        if ((values[0])[i] == '0')
                        {
                            var nextNode = ((InternalNode)node).LeftNode;
                            if(nextNode == null)
                            {
                                nextNode = new InternalNode();
                                nextNode.Parent = node;
                                nextNode.BlockDepth = node.BlockDepth + 1;
                                ((InternalNode)node).LeftNode = nextNode;
                            }
                            node = nextNode;
                        }
                        else
                        {
                            var nextNode = ((InternalNode)node).RightNode;
                            if (nextNode == null)
                            {
                                nextNode = new InternalNode();
                                nextNode.Parent = node;
                                nextNode.BlockDepth = node.BlockDepth + 1;
                                ((InternalNode)node).RightNode = nextNode;
                            }
                            node = nextNode;
                        }
                    }
                    var externalNode = new ExternalNode();                    
                    if ((values[0])[values[0].Length - 1] == '0')
                    {                                               
                        ((InternalNode)node).LeftNode = externalNode;                        
                    } else
                    {
                        ((InternalNode)node).RightNode = externalNode;
                    }
                    externalNode.Parent = node;
                    externalNode.BlockDepth = node.BlockDepth + 1;
                    if (values[1] != "-1")
                    {
                        externalNode.Adress = Convert.ToInt32(values[1]);
                        externalNode.RecordCount = Convert.ToInt32(values[2]);
                    }
                }
                line = input.ReadLine();
            }
            this.SettingsFile.Close();
            this.SettingsFile = new FileStream(fileName + ".set", FileMode.Create);
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
        public override T? Find(T data)
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
        public override bool Add(T data)
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
            this.Count++;
            return true;
        }
        public override bool Delete(T data)
        {
            var adressNode = this.GetAdressNode(data);
            if(adressNode == null)
            {
                return false;
            }
            //Delete node
            if(adressNode.RecordCount == 1)
            {
                //Insert into freeAdresses
                this.FreeAdressInsert(adressNode.Adress);
                //Is root
                if (this.Indexes.Root == adressNode)
                {
                    this.Indexes.Root = null;
                    this.Count--;
                    return true;
                }
                else
                {
                    adressNode.RecordCount = 0;                    
                    //Disable adress
                    adressNode.Adress = -1;
                }
            } else
            {
                //Load block and delete data
                var block = this.LoadBlock(adressNode.Adress);
                var blockValid = block.ValidCount;
                for (var i = 0; i < blockValid; i++)
                {
                    if (block.Records[i].IsEqual(data))
                    {
                        block.Records[i] = block.Records[block.ValidCount - 1];
                        block.ValidCount--;
                        adressNode.RecordCount--;
                        this.SaveBlock(adressNode.Adress, block);
                        break;
                    }
                }
            }
            //Check brother node
            while (adressNode.Parent != null)
            {
                //Set brother
                DFNode brother = null;
                if (((InternalNode)adressNode.Parent).LeftNode == adressNode)
                {
                    brother = ((InternalNode)adressNode.Parent).RightNode;
                }
                else
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
                if ((adressNode.RecordCount + brotherExternal.RecordCount) <= BlockFactor)
                {
                    //Load blocks
                    Block<T> adressBlock = null;
                    if (adressNode.Adress != -1)
                    {
                        adressBlock = this.LoadBlock(adressNode.Adress);
                        this.FreeAdressInsert(adressNode.Adress);
                        adressNode.Adress = -1;
                    }else
                    {
                        adressBlock = new Block<T>(this.BlockFactor, this.Class.CreateClass());
                    }
                    Block<T> brotherBlock = null;
                    if (brotherExternal.Adress != -1)
                    {
                        brotherBlock = this.LoadBlock(brotherExternal.Adress);
                        this.FreeAdressInsert(brotherExternal.Adress);
                        brotherExternal.Adress = -1;
                    }
                    else
                    {
                        brotherBlock = new Block<T>(this.BlockFactor, this.Class.CreateClass());
                    }
                    for (int i = 0; i < brotherBlock.ValidCount; i++)
                    {
                        adressBlock.InsertData(brotherBlock.Records[i]);
                        adressNode.RecordCount++;
                    }
                    //Write new block
                    adressNode.Adress = this.FreeAdressGet();
                    this.SaveBlock(adressNode.Adress, adressBlock);                               
                    //Set new reference
                    if (adressNode.Parent.Parent == null)
                    {
                        this.Indexes.Root = adressNode;
                        adressNode.Parent = null;
                    }
                    else
                    {
                        if (adressNode.Parent == ((InternalNode)adressNode.Parent.Parent).LeftNode)
                        {
                            ((InternalNode)adressNode.Parent.Parent).LeftNode = adressNode;
                        }
                        else
                        {
                            ((InternalNode)adressNode.Parent.Parent).RightNode = adressNode;
                        }
                        adressNode.Parent = adressNode.Parent.Parent;
                    }
                    //New blockDepth
                    adressNode.BlockDepth -= 1;
                }
                else
                {
                    break;
                }
            }
            this.Count--;
            return true;
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
                this.DataFile.SetLength(newAdress);
                var successorAdress = newAdress - sampleBLock.GetSize();
                var successorNode = FreeAdresses.Find(successorAdress);
                while(successorNode != null)
                {
                    this.DataFile.SetLength(successorAdress);
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
                var value = this.FreeAdresses.First.Value;
                FreeAdresses.RemoveFirst();
                return value;
            } else
            {
                return this.FileSize();
            }
        }
        public override string ToString()
        {
            var fileSize = this.FileSize();
            var result = "--------------------------------------------------\n";
            result += "Velkost suboru: " + fileSize + "\n";
            result += "Block factor: " + BlockFactor + "\n";
            result += "Pocet prvkov: " + Count + "\n";
            result += "Pocet volnych blokov: " + FreeAdresses.Count + "\n";
            if(FreeAdresses.Count > 0)
            {
                result += "Adresy volnych blokov: ";
                foreach (var freeAdress in FreeAdresses)
                {
                    result += "[" + freeAdress + "] ";
                }
            }            
            result += "\n--------------------------------------------------\n";
            result += this.GetBlocksSequense();
            return result;
        }
        public override bool SaveFile()
        {
            StringBuilder output = new StringBuilder();
            //Save blockFactor and count
            output.AppendLine(this.BlockFactor + ";" + this.Count + ";");
            //Save freeAdresses
            var freeAdresse = "";
            foreach(var adress in FreeAdresses)
            {
                freeAdresse += adress + ";";
            }
            output.AppendLine(FreeAdresses.Count + ";" + freeAdresse);
            //Save indexesTree
            if (this.Indexes.Root != null)
            {
                Queue<DFNode> queue = new Queue<DFNode>();
                queue.Enqueue(this.Indexes.Root);
                while (queue.Count != 0)
                {

                    var node = queue.Dequeue();

                    if (node is InternalNode)
                    {
                        var interNode = (InternalNode)node;

                        queue.Enqueue(interNode.LeftNode);
                        queue.Enqueue(interNode.RightNode);
                    }
                    else
                    {
                        var exterNode = (ExternalNode)node;
                        var index = "";
                        DFNode indexNode = exterNode;
                        while(indexNode.Parent != null)
                        {
                            if (((InternalNode)indexNode.Parent).LeftNode == indexNode)
                            {
                                index = "0" + index;
                            }
                            else
                            {
                                index = "1" + index;
                            }
                            indexNode = indexNode.Parent;
                        }                        
                        if(exterNode.Adress == -1)
                        {
                            output.AppendLine(index + ";" + "-1;");
                        } else
                        {
                            output.AppendLine(index + ";" + exterNode.Adress + ";" + exterNode.RecordCount + ";");
                        }
                    }
                }
            }
            //Save settings to file
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
