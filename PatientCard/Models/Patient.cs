using DataStructures.File;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientCard.Models
{
    public class Patient : IData<Patient>
    {
        private char[] _id;
        public char[] Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if (value.Length > 10)
                {
                    Array.Copy(value, this._id, 10);
                    this.IdSize = 10;
                }
                else
                {
                    Array.Copy(value, this._id, value.Length);
                    this.IdSize = Convert.ToByte(value.Length);
                }
            }
        }
        public byte IdSize { get; set; }
        private char[] _firstName;
        public char[] FirstName {
            get
            {
                return this._firstName;
            }
            set
            {
                if (value.Length > 15)
                {
                    Array.Copy(value, this._firstName, 15);
                    this.FirstNameSize = 15;
                }
                else
                {
                    Array.Copy(value, this._firstName, value.Length);
                    this.FirstNameSize = Convert.ToByte(value.Length);
                }
            }
        }
        public byte FirstNameSize { get; set; }
        private char[] _lastName;
        public char[] LastName {
            get
            {
                return this._lastName;
            }
            set
            {
                if (value.Length > 20)
                {
                    Array.Copy(value, this._lastName, 20);
                    this.LastNameSize = 20;
                }
                else
                {
                    Array.Copy(value, this._lastName, value.Length);
                    this.LastNameSize = Convert.ToByte(value.Length);
                }
            }
        }
        public byte LastNameSize { get; set; }
        public byte Insurance { get; set; }
        public DateTime BirthDate { get; set; }
        public Record[] Records { get; set; }
        public byte ValidRecords { get; set; }
        public Patient()
        {
            this._id = new char[10];
            this.IdSize = 0;
            this._firstName = new char[15];
            this.FirstNameSize = 0;
            this._lastName = new char[20];
            this.LastNameSize = 0;
            this.Insurance = 0;
            this.BirthDate = DateTime.Now;
            this.Records = new Record[10];
            for(var i = 0; i < 10; i++)
            {
                this.Records[i] = new Record();
            }
            this.ValidRecords = 0;
        }
        public bool AddRecord(Record record)
        {
            if(this.ValidRecords == 10)
            {
                return false;
            }
            this.Records[this.ValidRecords] = record;
            this.ValidRecords++;
            return true;
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
            return 10+(sizeof(char) / 2)+ sizeof(byte) + 15* (sizeof(char) / 2) + sizeof(byte) + 20*(sizeof(char) / 2) + sizeof(byte) +
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
            binaryWriter.Write(this.IdSize);
            binaryWriter.Write(this.FirstName);
            binaryWriter.Write(this.FirstNameSize);
            binaryWriter.Write(this.LastName);
            binaryWriter.Write(this.LastNameSize);
            binaryWriter.Write(this.Insurance);
            binaryWriter.Write(this.BirthDate.ToBinary());
            binaryWriter.Write(this.ValidRecords);
            foreach (var record in this.Records)
            {
                var bytes = record.ToByteArray();
                binaryWriter.Write(bytes);
            }
            return memoryStream.ToArray();
        }

        public void FromByteArray(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            this.Id = binaryReader.ReadChars(10);
            this.IdSize = binaryReader.ReadByte();
            this.FirstName = binaryReader.ReadChars(15);
            this.FirstNameSize = binaryReader.ReadByte();
            this.LastName = binaryReader.ReadChars(20);
            this.LastNameSize = binaryReader.ReadByte();
            this.Insurance = binaryReader.ReadByte();
            this.BirthDate = DateTime.FromBinary(binaryReader.ReadInt64());
            this.ValidRecords = binaryReader.ReadByte();
            for (var i = 0; i < Records.Length; i++)
            {
                var recordSize = Records[i].GetSize();
                var bytes = binaryReader.ReadBytes(recordSize);
                Records[i].FromByteArray(bytes);
            }            
        }
    }
}
