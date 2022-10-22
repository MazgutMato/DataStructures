using DataStructures.Tree.BSTree;
using ElectronicHealthCard.Models;
using System.Text;
using System;

namespace ElectronicHealthCard.Controllers
{
    public class GeneratorController
    {
        private Random random = new Random();
        private Generator generator;
        public GeneratorController(Generator generator)
        {
            this.generator = generator;
        }
        private string RandomString(int size)
        {
            var builder = new StringBuilder(size);

            char offset = 'a';
            const int lettersOffset = 26;

            for (var i = 0; i < size; i++)
            {
                var randomChar = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(randomChar);
            }

            return builder.ToString();
        }
        public bool GenerateData(HospitalizationRecordsController hospRecordCon,
            PatientsController patCon, HospitalsController hospCon)
        {
            var count = generator.Hospital;
            while(count > 0)
            {
                var size = random.Next(20) + 3;
                if(hospCon.AddHospital(new Hospital(RandomString(size))))
                {
                    count--;
                };
            }
            return true;
        }
    }
}
