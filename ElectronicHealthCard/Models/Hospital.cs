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
        public BSTree<RecordDate> StartRecords { get; set; }
        public Hospital() {
            this.Name = null;
            this.Patients = new BSTree<Patient>();
            this.NameList = new BSTree<PatientNameList>();
            this.StartRecords = new BSTree<RecordDate>();
        }
        public Hospital(string Name)
        {
            this.Name = Name;
            this.Patients = new BSTree<Patient>();
            this.NameList = new BSTree<PatientNameList>();
            this.StartRecords = new BSTree<RecordDate>();
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
        public bool AddPatientName(HospitalizationRecord hospRecord)
        {
            var patientName = new PatientNameList(hospRecord.Patient.FirstName, hospRecord.Patient.LastName);
            var findPatient = this.NameList.Find(patientName);
            if(findPatient != null)
            {
                findPatient.HospitalizationRecords.AddLast(hospRecord);
            }
            else
            {
                this.NameList.Add(patientName);
                patientName.HospitalizationRecords.AddLast(hospRecord);
            }
            return true;
        }
        public bool AddRecord(Record record)
        {
            var recordDate = new RecordDate(record.Start);
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
            var recordDates = new List<RecordDate>();
            //Dates in range
            this.StartRecords.FindRange(new RecordDate(start), new RecordDate(end), recordDates);
            foreach (var recordDate in recordDates)
            {
                foreach (var record in recordDate.Records)
                {
                    result.Add(record);
                }
            }
            //Dates before range
            recordDates.Clear();
            this.StartRecords.FindRange(new RecordDate(DateTime.MinValue), new RecordDate(start), recordDates);
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
            return result.Distinct().ToList();
        }
    }
}
