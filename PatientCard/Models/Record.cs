using System.Collections;
using System.ComponentModel.DataAnnotations;
using DataStructures.File;

namespace PatientCard.Models
{
    public class Record : IData<Record>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [Required]
        public char[] Diagnoze { get; set; }
        public byte DiagnozeSize { get; set; }
        public Record()
        {
            this.Id = 1;
            this.Start = DateTime.Now;
            this.End = DateTime.MinValue;
            this.Diagnoze = new char[20];
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
            binaryWriter.Write(this.DiagnozeSize);
            binaryWriter.Write(this.Diagnoze);

            return memoryStream.ToArray();
        }

        public void FromByteArray(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            this.Id = binaryReader.ReadInt32();
            this.Start = DateTime.FromBinary(binaryReader.ReadInt64());
            this.End = DateTime.FromBinary(binaryReader.ReadInt64());
            this.DiagnozeSize = binaryReader.ReadByte();
            this.Diagnoze = binaryReader.ReadChars(20);
        }

        public int GetSize()
        {
            var dateTimeSize = 8;
            return sizeof(int) + sizeof(byte) + 2* dateTimeSize + 20*sizeof(char);
        }
    }
}
