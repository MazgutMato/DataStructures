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
        public BSTree<RecordDate> EndRecords { get; set; }
        public Hospital() {
            this.Name = null;
            this.Patients = new BSTree<Patient>();
            this.NameList = new BSTree<PatientNameList>();
            this.StartRecords = new BSTree<RecordDate>();
            this.EndRecords = new BSTree<RecordDate>();
        }
        public Hospital(string Name)
        {
            this.Name = Name;
            this.Patients = new BSTree<Patient>();
            this.NameList = new BSTree<PatientNameList>();
            this.StartRecords = new BSTree<RecordDate>();
            this.EndRecords = new BSTree<RecordDate>();
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
        public bool AddPatient(HospitalizationRecord hospRecord)
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
            return true;
        }
        public bool EndRecord(Record record)
        {
            return true;
        }
        public bool AddEndedRecord(Record record)
        {
            return true;
        }
    }
}
