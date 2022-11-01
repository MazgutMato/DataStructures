using DataStructures.Tree.BSTree;
using System.Runtime.InteropServices;

namespace ElectronicHealthCard.Models
{
    public class PatientNameList : IComparable<PatientNameList>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BSTree<Hospitalization> HospitalizationRecords { get; set; }
        public PatientNameList()
        {
            FirstName = null;
            LastName = null;
        }
        public PatientNameList(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            HospitalizationRecords = new BSTree<Hospitalization>();
        }
        public void AddHospRecord(Hospitalization hospRec)
        {
            HospitalizationRecords.Add(hospRec);
        }
        public int CompareTo(PatientNameList? other)
        {
            var compFirstName = FirstName.CompareTo(other.FirstName);
            var compLastname = LastName.CompareTo(other.LastName);
            if (compFirstName != 0)
            {
                return compFirstName;
            }
            else
            {
                return compLastname;
            }
        }
    }
}
