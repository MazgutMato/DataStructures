using DataStructures.Tree.BSTree;
using ElectronicHealthCard.Models;
using System.Text;
using System;
using System.Collections;

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
        private string RandomString(char paOffset, int numberOfChar, int size)
        {
            var builder = new StringBuilder(size);

            var offset = paOffset;
            var lettersOffset = numberOfChar;

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
            //Hospitals generate
            var count = generator.Hospital;
            var hospitals = new List<Hospital>();
            while(count > 0)
            {
                var size = random.Next(20) + 3;
                var hospital = new Hospital(RandomString(size));
                if (hospCon.AddHospital(hospital))
                {
                    hospitals.Add(hospital);
                    count--;
                };
            }
            //Patients generate
            count = generator.Patient;
            var patients = new List<Patient>();
            while (count > 0)
            {
                var patient = new Patient(RandomString('0', 9, 10),
                    RandomString(5), RandomString(8), DateTime.Now.AddDays(random.Next(1000)));
                if (patCon.AddPatient(patient))
                {
                    patients.Add(patient);
                    var countRecord = random.Next(generator.MinEndedRecord, generator.MaxEndedRecord);
                    while(countRecord > 0)
                    {
                        var record = new Record(DateTime.Now,DateTime.Now.AddDays(random.Next(30)), RandomString(50));
                        if (hospRecordCon.AddEndedRecord(hospitals[random.Next(hospitals.Count)], patient, record))
                        {
                            countRecord--;
                        }                           
                    }
                    count--;
                };
            }
            //Actual patients generate
            foreach(var hospital in hospitals)
            {
                count = random.Next(generator.MinActivePatient, generator.MaxActivePatient);
                while(count > 0)
                {
                    var record = new Record(DateTime.Now, RandomString(50));
                    if (hospRecordCon.AddRecord(hospital, patients[random.Next(patients.Count)], record))
                    {
                        count--;
                    }
                }
            }
            return true;
        }
    }
}
