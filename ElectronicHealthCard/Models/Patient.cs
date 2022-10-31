using ElectronicHealthCard.Pages.Patient;
using ElectronicHealthCard.Pages.Record;
using System.ComponentModel.DataAnnotations;

namespace ElectronicHealthCard.Models
{
    public class Patient : IComparable<Patient>
    {
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Patient Id consist of 10 digits!")]
        public string PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Record ActualRecord { get; set; }
        public LinkedList<Record> AllRecords { get; set; }
        public Patient() {
            PatientId = default;
            FirstName = default;
            LastName = default;
            BirthDate = default;
            ActualRecord = null;
            AllRecords = new LinkedList<Record>();
        }
        public Patient(string patientId, string firstName, string lastName)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = default;
            ActualRecord = null;
            AllRecords = new LinkedList<Record>();
        }
        public Patient(string patientId, string firstName, string lastName, DateTime birthDate)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            ActualRecord = null;
            AllRecords = new LinkedList<Record>();
        }
        public int CompareTo(Patient? other)
        {
            return this.PatientId.CompareTo(other.PatientId); ;
        }
        public void AddRecord(Record record)
        {
            this.AllRecords.AddLast(record);
        }
    }
}
