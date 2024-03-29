﻿using DataStructures.File;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FileApp.Models
{
    public class Patient : IData<Patient>
    {
        private char[] _id;
        public char[] Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value.Length > 10)
                {
                    Array.Copy(value, _id, 10);
                    IdSize = 10;
                }
                else
                {
                    Array.Copy(value, _id, value.Length);
                    IdSize = Convert.ToByte(value.Length);
                }
            }
        }
        public byte IdSize { get; set; }
        private char[] _firstName;
        public char[] FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value.Length > 15)
                {
                    Array.Copy(value, _firstName, 15);
                    FirstNameSize = 15;
                }
                else
                {
                    Array.Copy(value, _firstName, value.Length);
                    FirstNameSize = Convert.ToByte(value.Length);
                }
            }
        }
        public byte FirstNameSize { get; set; }
        private char[] _lastName;
        public char[] LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value.Length > 20)
                {
                    Array.Copy(value, _lastName, 20);
                    LastNameSize = 20;
                }
                else
                {
                    Array.Copy(value, _lastName, value.Length);
                    LastNameSize = Convert.ToByte(value.Length);
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
            _id = new char[10];
            IdSize = 0;
            _firstName = new char[15];
            FirstNameSize = 0;
            _lastName = new char[20];
            LastNameSize = 0;
            Insurance = 0;
            BirthDate = DateTime.Now;
            Records = new Record[10];
            for (var i = 0; i < 10; i++)
            {
                Records[i] = new Record();
            }
            ValidRecords = 0;
        }
        public Patient(Patient other)
        {
            _id = new char[10];
            Id = other.Id;
            IdSize = other.IdSize;
            _firstName = new char[15];
            FirstName = other.FirstName;
            FirstNameSize = other.FirstNameSize;
            _lastName = new char[20];
            LastName = other.LastName;
            LastNameSize = other.LastNameSize;
            Insurance = other.Insurance;
            BirthDate = other.BirthDate;
            Records = new Record[10];
            for (var i = 0; i < 10; i++)
            {
                Records[i] = new Record(other.Records[i]);
            }
            ValidRecords = other.ValidRecords;
        }
        public bool AddRecord(Record record)
        {
            if (ValidRecords == 10)
            {
                return false;
            }
            var newId = 1;
            for (var i = 0; i < ValidRecords; i++)
            {
                if(newId <= Records[i].Id)
                {
                    newId = Records[i].Id + 1;
                }
                if (Records[i].End == DateTime.MinValue)
                {
                    return false;
                }
            }
            record.Id = newId;
            Records[ValidRecords] = record;
            ValidRecords++;
            return true;
        }
        public bool EndRecord(Record record)
        {
            for (var i = 0; i < ValidRecords; i++)
            {
                if (Records[i].Start.Date == record.Start.Date && Records[i].End.Date == DateTime.MinValue.Date)
                {
                    Records[i].End = record.End;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteRecord(Record record)
        {
            if(this.ValidRecords == 1)
            {
                this.ValidRecords--;
                return true;
            }
            for (var i = 0; i < ValidRecords; i++)
            {
                if (Records[i].Id == record.Id)
                {
                    Records[i] = Records[ValidRecords-1];
                    ValidRecords--;
                    return true;
                }
            }
            return false;
        }
        public Patient CreateClass()
        {
            return new Patient();
        }

        public BitArray GetHash()
        {
            long hash = long.Parse(this.Id);           
            return new BitArray(BitConverter.GetBytes(hash));
        }

        public int GetSize()
        {
            var dateTimeSize = 8;
            return (10 * (sizeof(char) / 2)) + sizeof(byte) + (15 * (sizeof(char) / 2)) + sizeof(byte) + (20 * (sizeof(char) / 2)) + sizeof(byte) +
                sizeof(byte) + dateTimeSize + (10 * new Record().GetSize()) + sizeof(byte);
        }

        public bool IsEqual(Patient data)
        {
            for (var i = 0; i < 10; i++)
            {
                if (data.Id[i] != Id[i])
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

            binaryWriter.Write(Id);
            binaryWriter.Write(IdSize);
            binaryWriter.Write(FirstName);
            binaryWriter.Write(FirstNameSize);
            binaryWriter.Write(LastName);
            binaryWriter.Write(LastNameSize);
            binaryWriter.Write(Insurance);
            binaryWriter.Write(BirthDate.ToBinary());
            binaryWriter.Write(ValidRecords);
            foreach (var record in Records)
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

            Id = binaryReader.ReadChars(10);
            IdSize = binaryReader.ReadByte();
            FirstName = binaryReader.ReadChars(15);
            FirstNameSize = binaryReader.ReadByte();
            LastName = binaryReader.ReadChars(20);
            LastNameSize = binaryReader.ReadByte();
            Insurance = binaryReader.ReadByte();
            BirthDate = DateTime.FromBinary(binaryReader.ReadInt64());
            ValidRecords = binaryReader.ReadByte();
            for (var i = 0; i < Records.Length; i++)
            {
                var recordSize = Records[i].GetSize();
                var bytes = binaryReader.ReadBytes(recordSize);
                Records[i].FromByteArray(bytes);
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("------------------------------------------------------------------");
            result.AppendLine("Patient ID: " + new string(this.Id));
            result.AppendLine("First name: " + new string(this.FirstName,0,this.FirstNameSize));
            result.AppendLine("Last name: " + new string(this.LastName,0,this.LastNameSize));
            result.AppendLine("Birth date: " + this.BirthDate.Date);
            result.AppendLine("Insurance: " + this.Insurance);
            result.AppendLine("Number of records: " + this.ValidRecords);
            result.AppendLine("Records: ");
            for (var i = 0; i < ValidRecords; i++)
            {
                result.AppendLine(this.Records[i].ToString());
            }
            result.AppendLine("------------------------------------------------------------------");
            return result.ToString();
        }

        public string ToString(byte recordID)
        {
            var result = new StringBuilder();
            result.AppendLine("------------------------------------------------------------------");
            result.AppendLine("Patient ID: " + new string(this.Id));
            result.AppendLine("First name: " + new string(this.FirstName, 0, this.FirstNameSize));
            result.AppendLine("Last name: " + new string(this.LastName, 0, this.LastNameSize));
            result.AppendLine("Birth date: " + this.BirthDate.Date);
            result.AppendLine("Insurance: " + this.Insurance);
            result.AppendLine("Number of records: " + this.ValidRecords);
            result.AppendLine("Record: ");
            Record findRecord = null;
            for (var i = 0; i < ValidRecords; i++)
            {
                if (Records[i].Id == recordID)
                {
                    findRecord = Records[i];
                    break;
                }                
            }
            if (findRecord != null)
            {
                result.AppendLine(findRecord.ToString());
            }
            else
            {
                result.AppendLine("Record not found!");
            }
            result.AppendLine("------------------------------------------------------------------");
            return result.ToString();
        }
    }
}
