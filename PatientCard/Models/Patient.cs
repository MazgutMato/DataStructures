using DataStructures.File;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientCard.Models
{
    public class Patient : IData<Patient>
    {
        public char[] Id { get; set; }
        public char[] FirstName { get; set; }
        public byte FirstNameSize { get; set; }
        public char[] LastName { get; set; }
        public byte LastNameSize { get; set; }
        public byte Insurance { get; set; }
        public DateTime BirthDate { get; set; }
        public Record[] Records { get; set; }
        public byte ValidRecords { get; set; }
        public Patient()
        {
            this.Id = new char[10];
            this.FirstName = new char[15];
            this.FirstNameSize = 0;
            this.LastName = new char[20];
            this.LastNameSize = 0;
            this.Insurance = 0;
            this.BirthDate = DateTime.Now;
            this.Records = new Record[10];
            this.ValidRecords = 0;
        }
        public Patient CreateClass()
        {
            return new Patient();
        }

        public BitArray GetHash()
        {
            BitArray hash = new BitArray(Encoding.UTF8.GetBytes(this.Id));
            return hash;
        }

        public int GetSize()
        {
            var dateTimeSize = 8;
            return 10+sizeof(char) + 15*sizeof(char) + sizeof(byte) + 20*sizeof(char) + sizeof(byte) +
                sizeof(byte) + dateTimeSize + 10*new Record().GetSize() + sizeof(byte);
        }

        public bool IsEqual(Patient data)
        {
            for(var i = 0; i < 10; i++)
            {
                if (data.Id[i] != this.Id[i])
                {
                    return false;
                }
            }
            return true;
        }

        public byte[] ToByteArray()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(this.Id);
            binaryWriter.Write(this.FirstName);
            binaryWriter.Write(this.FirstNameSize);
            binaryWriter.Write(this.LastName);
            binaryWriter.Write(this.LastNameSize);
            binaryWriter.Write(this.Insurance);
            binaryWriter.Write(this.BirthDate.ToBinary());
            foreach(var record in this.Records)
            {
                binaryWriter.Write(record.ToByteArray());
            }
            binaryWriter.Write(this.ValidRecords);
            return memoryStream.ToArray();
        }

        public void FromByteArray(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            this.Id = binaryReader.ReadChars(10);
            this.FirstName = binaryReader.ReadChars(15);
            this.FirstNameSize = binaryReader.ReadByte();
            this.LastName = binaryReader.ReadChars(20);
            this.LastNameSize = binaryReader.ReadByte();
            this.Insurance = binaryReader.ReadByte();
            this.BirthDate = DateTime.FromBinary(binaryReader.ReadInt64());
            for(var i = 0; i < 10; i++)
            {
                Records[i].FromByteArray(binaryReader.ReadBytes(Records[i].GetSize()));
            }
            this.ValidRecords = binaryReader.ReadByte();
        }
    }
}
