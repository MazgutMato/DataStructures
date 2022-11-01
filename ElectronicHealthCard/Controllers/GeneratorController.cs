using DataStructures.Tree.BSTree;
using ElectronicHealthCard.Models;
using System.Text;
using System;
using System.Collections;
using ElectronicHealthCard.Pages;

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
        public bool GenerateData(HospitalizationController hospRecordCon,
            PatientsController patCon, HospitalsController hospCon, InsuranceController insCon)
        {
            //Hospitals generate
            var count = generator.Hospital;
            var hospitals = new List<Hospital>();
            while (count > 0)
            {
                var size = random.Next(20) + 3;
                var hospital = new Hospital(RandomString(size));
                hospitals.Add(hospital);
                count--;
            }
            hospCon.AddHospitals(hospitals);
            //Insurance company generate
            count = generator.InsuranceCompany;
            var companies = new List<InsuranceCompany>();
            while (count > 0)
            {
                var name = random.Next(10) + 3;
                var code = 4;
                var company = new InsuranceCompany(RandomString(name), RandomString(code));
                companies.Add(company);
                count--;
            }
            insCon.AddCompanies(companies);
            //Patients generate
            count = generator.Patient;
            var patients = new List<Patient>();
            while (count > 0)
            {
                var patient = new Patient(RandomString('0', 9, 10),
                    RandomString(5), RandomString(8), 
                    new DateTime(random.Next(1920, DateTime.Now.Year),
                    random.Next(1, 12),
                    random.Next(1, 28)),
                    companies[random.Next(companies.Count)]
                    );
                patients.Add(patient);
                count--;
            };
            patCon.AddPatients(patients);
            //Old records generate
            var hospRecords = new List<Hospitalization>();
            foreach (var patient in patients)
            {
                var countRecord = random.Next(generator.MinEndedRecord, generator.MaxEndedRecord);
                var hospRecord = new Hospitalization(patient, hospitals[random.Next(hospitals.Count)]);                
                while (countRecord > 0)
                {
                    var subb = generator.MaxDate.Subtract(generator.MinDate).Days;
                    var startDate = generator.MinDate.AddDays(random.Next(subb));
                    var record = new Record( startDate, startDate.AddDays(random.Next(subb)), RandomString(50) );
                    hospRecord.AddEndedRecord(record);
                    countRecord--;
                }
                hospRecords.Add(hospRecord);
            }
            hospRecordCon.AddEndedRecords(hospRecords);
            //Actual patients generate
            foreach (var hospital in hospitals)
            {
                count = random.Next(generator.MinActivePatient, generator.MaxActivePatient);
                while (count > 0)
                {
                    var subb = generator.MaxDate.Subtract(generator.MinDate).Days;
                    var startDate = generator.MinDate.AddDays(random.Next(subb));
                    var record = new Record(startDate, RandomString(50));
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
