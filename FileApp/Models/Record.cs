using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DataStructures.File;

namespace FileApp.Models
{
    public class Record : IData<Record>
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private char[] _diagnoze;
        public char[] Diagnoze
        {
            get
            {
                return _diagnoze;
            }
            set
            {
                if (value.Length > 20)
                {
                    Array.Copy(value, _diagnoze, 20);
                    DiagnozeSize = 20;
                }
                else
                {
                    Array.Copy(value, _diagnoze, value.Length);
                    DiagnozeSize = Convert.ToByte(value.Length);
                }
            }
        }
        public byte DiagnozeSize { get; set; }
        public Record()
        {
            Id = 1;
            Start = DateTime.Now;
            End = DateTime.MinValue;
            _diagnoze = new char[20];
            DiagnozeSize = 0;
        }
        public Record(Record other)
        {
            Id = other.Id;
            Start = other.Start;
            End = other.End;
            _diagnoze = new char[20];
            Diagnoze = other.Diagnoze;
        }
        public BitArray GetHash()
        {
            long hash = Convert.ToInt64(this.Id);
            return new BitArray(BitConverter.GetBytes(hash));
        }

        public bool IsEqual(Record data)
        {
            return Id == data.Id;
        }

        public Record CreateClass()
        {
            return new Record();
        }

        public byte[] ToByteArray()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.Write(Id);
            binaryWriter.Write(Start.ToBinary());
            binaryWriter.Write(End.ToBinary());
            binaryWriter.Write(Diagnoze);
            binaryWriter.Write(DiagnozeSize);

            return memoryStream.ToArray();
        }

        public void FromByteArray(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            BinaryReader binaryReader = new BinaryReader(memoryStream);

            Id = binaryReader.ReadInt32();
            Start = DateTime.FromBinary(binaryReader.ReadInt64());
            End = DateTime.FromBinary(binaryReader.ReadInt64());
            Diagnoze = binaryReader.ReadChars(20);
            DiagnozeSize = binaryReader.ReadByte();
        }

        public int GetSize()
        {
            var dateTimeSize = 8;
            return sizeof(int) + (2 * dateTimeSize) + (20 * (sizeof(char) / 2)) + sizeof(byte);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("ID: " + this.Id);
            result.AppendLine("Start: " + this.Start);
            if(this.End == DateTime.MinValue)
            {
                result.AppendLine("End: not defined");
            }
            else
            {
                result.AppendLine("End: " + this.End);
            }
            result.AppendLine("Diagnosis: " + new string(this.Diagnoze,0,this.DiagnozeSize));
            return result.ToString();
        }
    }
}
