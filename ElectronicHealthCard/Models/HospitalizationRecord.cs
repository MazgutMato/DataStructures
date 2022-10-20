using DataStructures.Tree.BSTree;

namespace ElectronicHealthCard.Models
{
    public class HospitalizationRecord : IComparable<HospitalizationRecord>
    {
        public Patient Patient { get; set; }
        public Hospital Hospital { get; set; }
        public BSTree<Record> Records { get; set; }
        public HospitalizationRecord()
        {
            Patient = null;
            Hospital = null;
            Records = new BSTree<Record>();
        }
        public HospitalizationRecord(Patient patient, Hospital hospital)
        {
            Patient = patient;
            Hospital = hospital;
            Records = new BSTree<Record>();
        }
        public int CompareTo(HospitalizationRecord? other)
        {
            var comHospital = this.Hospital.Name.CompareTo(other.Hospital.Name);
            var comPacient = this.Patient.PatientId.CompareTo(other.Patient);            
            if(comHospital != 0)
            {
                return comHospital;
            } else
            {
                return comPacient;
            }
        }
        public bool AddRecord(Record record)
        {
            return this.Records.Add(record);
        }
    }
}
