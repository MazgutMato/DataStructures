using DataStructures.Tree.BSTree;
using System.ComponentModel.DataAnnotations;

namespace ElectronicHealthCard.Models
{
    public class Hospital : IComparable<Hospital>
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name cannot have less than 3 characters and more than 50 characters in length")]
        public string Name { get; set; }
        public BSTree<Patient> Patients { get; set; }
        public BSTree<PatientNameList> NameList { get; set; }
        public BSTree<HospitalRecord> StartRecords { get; set; }
        public Hospital() {
            this.Name = null;
            this.Patients = new BSTree<Patient>();
            this.NameList = new BSTree<PatientNameList>();
            this.StartRecords = new BSTree<HospitalRecord>();
        }
        public Hospital(string Name)
        {
            this.Name = Name;
            this.Patients = new BSTree<Patient>();
            this.NameList = new BSTree<PatientNameList>();
            this.StartRecords = new BSTree<HospitalRecord>();
        }

        public int CompareTo(Hospital? other)
        {
            return this.Name.CompareTo(other.Name);
        }
        public bool AddActualPatient(Patient patient, Record record)
        {
            if (this.Patients.Add(patient))
            {
                patient.ActualRecord = record;
                return true;
            }
            return false;
        }
        public bool AddPatientName(Hospitalization hospRecord)
        {
            var patientName = new PatientNameList(hospRecord.Patient.FirstName, hospRecord.Patient.LastName);
            var findPatient = this.NameList.Find(patientName);
            if(findPatient != null)
            {
                findPatient.HospitalizationRecords.Add(hospRecord);
            }
            {
                this.NameList.Add(patientName);
                patientName.HospitalizationRecords.Add(hospRecord);
            }
            return true;
        }
        public bool AddRecord(Record record)
        {
            var recordDate = new HospitalRecord(record.Start);
            var findRecord = this.StartRecords.Find(recordDate);
            if(findRecord != null)
            {               
                findRecord.Records.AddLast(record);
                return true;
            }
            else
            {
                recordDate.Records.AddLast(record);
                return this.StartRecords.Add(recordDate);
            }            
        }
        public bool AddEndedRecord(Record record)
        {
            return this.AddRecord(record);
        }
        public List<Record> FindPatients(DateTime start, DateTime end)
        {
            var result = new List<Record>();
            var recordDates = new List<HospitalRecord>();
            //Dates in range
            this.StartRecords.FindRange(new HospitalRecord(start), new HospitalRecord(end), recordDates);
            foreach (var recordDate in recordDates)
            {
                foreach (var record in recordDate.Records)
                {
                    result.Add(record);
                }
            }
            //Dates before range
            recordDates.Clear();
            this.StartRecords.FindRange(new HospitalRecord(DateTime.MinValue), new HospitalRecord(
                new DateTime(start.Year, start.Month,start.Day - 1)), recordDates);  
            foreach(var recordDate in recordDates)
            {
                foreach(var record in recordDate.Records)
                {
                    if(record.End == DateTime.MinValue || record.End >= start)
                    {
                        result.Add(record);
                    }
                }
            }
            return result;
        }
    }
}
