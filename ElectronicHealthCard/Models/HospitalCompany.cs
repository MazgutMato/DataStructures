using DataStructures.Tree.BSTree;

namespace ElectronicHealthCard.Models
{
    public class HospitalCompany : IComparable<HospitalCompany>
    {
        public InsuranceCompany InsuranceCompany { get; set; }
        public BSTree<Patient> ActualPatients { get; set; }
        public HospitalCompany()
        {
            InsuranceCompany = new InsuranceCompany();
            ActualPatients = new BSTree<Patient>();
        }
        public HospitalCompany(InsuranceCompany insuranceCompany)
        {
            InsuranceCompany = insuranceCompany;
            ActualPatients = new BSTree<Patient>();
        }
        public bool AddActualPatient(Patient patient)
        {
            return ActualPatients.Add(patient);
        }
        public bool DeleteActualPatient(Patient patient)
        {
            return ActualPatients.Delete(patient);
        }
        public int CompareTo(HospitalCompany? other)
        {
            return InsuranceCompany.CompareTo(other.InsuranceCompany);
        }
    }
}
