using DataStructures.Tree.BSTree;
using ElectronicHealthCard.Pages.Hospital;

namespace ElectronicHealthCard.Models
{
    public class Hospitalization : IComparable<Hospitalization>
    {
        public Patient Patient { get; set; }
        public Hospital Hospital { get; set; }
        public BSTree<Record> Records { get; set; }
        public Hospitalization()
        {
            Patient = new Patient();
            Hospital = new Hospital();
            Records = new BSTree<Record>();
        }
        public Hospitalization(Patient patient, Hospital hospital)
        {
            Patient = patient;
            Hospital = hospital;
            Records = new BSTree<Record>();
        }
        public int CompareTo(Hospitalization? other)
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
            if (this.Patient.ActualRecord == null)
            {
                if (this.Records.Add(record))
                {
                    record.HospitalizationRecord = this;
                    //Add to patient tree
                    this.Patient.AddRecord(record);
                    //Add to hospital tree
                    this.Hospital.AddActualPatient(this.Patient, record);
                    this.Hospital.AddRecord(record);
                    this.Hospital.AddPatientName(this);
                    //Add to insurance tree
                    this.Patient.Insurance.AddRecord(record);
                    return true;
                }
            }
            return false;
        }
        public bool EndRecord(Record record)
        {
            var findRecord = this.Records.Find(record);
            if (findRecord != null && findRecord.CompareTo(this.Patient.ActualRecord) == 0)
            {
                if (this.Hospital.DeleteActualPatients(this.Patient))
                {
                    findRecord.End = record.End;
                    return true;
                }                
                return false;
            }
            return false;
        }
        public bool AddEndedRecord(Record record)
        {
            if (this.Records.Add(record))
            {
                record.HospitalizationRecord = this;

                //Add to patient tree
                this.Patient.AddRecord(record);
                //Add to hospital tree
                this.Hospital.AddRecord(record);
                this.Hospital.AddPatientName(this);
                //Add to insurance tree
                this.Patient.Insurance.AddRecord(record);
                return true;
            }
            return false;
        }
    }
}
