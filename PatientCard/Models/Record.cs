using System.Collections;
using System.ComponentModel.DataAnnotations;
using DataStructures.File;

namespace PatientCard.Models
{
    public class Record : IData<Record>
    {        
        public int Id { get; set; }        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private char[] _diagnoze;
        public char[] Diagnoze {
            get
            {
                return this._diagnoze;
            }
            set
            {
                if (value.Length > 20)
                {
                    Array.Copy(value, this._diagnoze, 20);
                    this.DiagnozeSize = 20;
                }
                else
                {
                    Array.Copy(value, this._diagnoze, value.Length);
                    this.DiagnozeSize = Convert.ToByte(value.Length);
                }
            }
        }
        public byte DiagnozeSize { get; set; }
        public Record()
        {
            this.Id = 1;
            this.Start = DateTime.Now;
            this.End = DateTime.MinValue;
            this._diagnoze = new char[20];
            this.DiagnozeSize = 0;
        }

        public BitArray GetHash()
        {
            BitArray hash = new BitArray(BitConverter.GetBytes(this.Id));
            return hash;
        }

        public bool IsEqual(Record data)
        {
            return this.Id == data.Id;
        }

        public Record CreateClass()
        {
            return new Record();
        }

        public byte[] ToByteArray()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(this.Id);
            binaryWriter.Write(this.Start.ToBinary());
            binaryWriter.Write(this.End.ToBinary());            
            binaryWriter.Write(this.Diagnoze);
            binaryWriter.Write(this.DiagnozeSize);

            return memoryStream.ToArray();
        }

        public void FromByteArray(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            this.Id = binaryReader.ReadInt32();
            this.Start = DateTime.FromBinary(binaryReader.ReadInt64());
            this.End = DateTime.FromBinary(binaryReader.ReadInt64());            
            this.Diagnoze = binaryReader.ReadChars(20);
            this.DiagnozeSize = binaryReader.ReadByte();
        }

        public int GetSize()
        {
            var dateTimeSize = 8;
            return sizeof(int) + sizeof(byte) + 2* dateTimeSize + 20*(sizeof(char)/2);
        }
    }
}
