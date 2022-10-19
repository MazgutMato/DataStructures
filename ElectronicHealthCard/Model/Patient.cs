using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicHealthCard.Model
{
    public class Patient : IComparable<Patient>
    {
        public string PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Patient(string patientId, string firstName, string lastName, DateTime birthDate)
        {
            PatientId = patientId;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
        public int CompareTo(Patient? other)
        {
            return this.PatientId.CompareTo(other.PatientId); ;
        }
    }
}
