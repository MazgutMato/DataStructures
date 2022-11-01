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
        public InsuranceCompany Insurance { get; set; }
        public LinkedList<Record> AllRecords { get; set; }
        public Patient()
        {
            PatientId = default;
            FirstName = default;
            LastName = default;
            BirthDate = default;
            ActualRecord = null;
            Insurance = new InsuranceCompany();
            AllRecords = new LinkedList<Record>();
        }
        public Patient(string patientId, string firstName, string lastName)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = default;
            ActualRecord = null;
            Insurance = new InsuranceCompany();
            AllRecords = new LinkedList<Record>();
        }
        public Patient(string patientId, string firstName, string lastName, DateTime birthDate, InsuranceCompany company)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            ActualRecord = null;
            Insurance = company;
            AllRecords = new LinkedList<Record>();
        }
        public int CompareTo(Patient? other)
        {
            return PatientId.CompareTo(other.PatientId); ;
        }
        public void AddRecord(Record record)
        {
            AllRecords.AddLast(record);
        }
        public string ToString()
        {
            String[] information = { this.PatientId, this.FirstName, this.LastName, this.BirthDate.ToString() };
            return string.Join(',',information);
        }
    }
}
