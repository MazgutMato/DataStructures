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
            Patient = new Patient();
            Hospital = new Hospital();
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
            var comPacient = this.Patient.PatientId.CompareTo(other.Patient.PatientId);            
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
            if (this.Records.Add(record))
            {
                this.Patient.ActualRecord = record;
                this.Hospital.Patients.Add(this.Patient);
                return true;
            }
            return false;
        }
        public bool EndRecord(Record record)
        {
            var findRecord = this.Records.Find(record);
            if (findRecord != null && findRecord.CompareTo(this.Patient.ActualRecord) == 0)
            {
                this.Patient.ActualRecord = null;
                this.Hospital.Patients.Delete(this.Patient);
                findRecord.End = record.End;
                return true;
            }
            return false;
        }
        public bool AddEndedRecord(Record record)
        {
            if (this.Records.Add(record))
            {
                return true;
            }
            return false;
        }
    }
}
