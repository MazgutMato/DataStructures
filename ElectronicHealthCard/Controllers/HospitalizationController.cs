using ElectronicHealthCard.Models;
using DataStructures.Tree.BSTree;
using DataStructures.Iterator;

namespace ElectronicHealthCard.Controllers
{
    public class HospitalizationController
    {
        private BSTree<Hospitalization> HospitalizationRecords;
        public HospitalizationController()
        {
            HospitalizationRecords = new BSTree<Hospitalization>();
        }
        public Iterator<Hospitalization> GetHospitalizations()
        {
            return this.HospitalizationRecords.createIterator();
        }
        public int GetCount()
        {
            return HospitalizationRecords.Count;
        }
        public bool AddRecord(Hospital hospital, Patient patient, Record record)
        {
            var HospRecord = new Hospitalization(patient, hospital);
            var FindHospRecord = this.HospitalizationRecords.Find(HospRecord);
            if(FindHospRecord != null)
            {
                return FindHospRecord.AddRecord(record);
            } else
            {
                if(HospitalizationRecords.Add(HospRecord))
                {
                    return HospRecord.AddRecord(record);
                }
                else
                {
                    return false;
                }             
            }
        }        
        public bool EndRecord(Hospital hospital, Patient patient, Record record)
        {
            var HospRecord = new Hospitalization(patient, hospital);
            var FindHospRecord = this.HospitalizationRecords.Find(HospRecord);
            if(FindHospRecord != null)
            {                
                return FindHospRecord.EndRecord(record);
            }
            return false;
        }
        public bool AddEndedRecord(Hospital hospital, Patient patient, Record record)
        {
            var HospRecord = new Hospitalization(patient, hospital);
            var FindHospRecord = this.HospitalizationRecords.Find(HospRecord);
            if (FindHospRecord != null)
            {
                return FindHospRecord.AddEndedRecord(record);
            }
            else
            {
                if (HospitalizationRecords.Add(HospRecord))
                {                    
                    return HospRecord.AddEndedRecord(record);
                }
                else
                {
                    return false;
                }              
            }
        }
        public bool AddEndedRecords(List<Hospitalization> records)
        {
            if (this.HospitalizationRecords.FillWithMedian(records))
            {
                var iterator = this.HospitalizationRecords.createIterator();
                while (iterator.HasNext())
                {
                    var actual =  iterator.MoveNext();
                    actual.Hospital.AddPatientName(actual);
                }
                return true;
            } else
            {
                return false;
            }
        }
        public Hospitalization FindHospitalizationRecord(Patient patient, Hospital hospital)
        {
            return this.HospitalizationRecords.Find(new Hospitalization(patient, hospital));
        }
        public void Optimalize()
        {
            var iterator = this.HospitalizationRecords.createIterator();
            while (iterator.HasNext())
            {
                var hospitalization = iterator.MoveNext();
                hospitalization.Records.BalanceTree();
            }
            this.HospitalizationRecords.BalanceTree();
        }
        public bool ChangeHospital(Hospital oldHospital, Hospital newHospital)
        {
            //Find all old hospitalizations
            List<Hospitalization> hospitalizations = new List<Hospitalization>();
            var minPatient = new Patient("0000000000", "", "");
            var maxPatient = new Patient("9999999999", "", "");
            var minHospitalization = new Hospitalization(minPatient,oldHospital);
            var maxHospitalization = new Hospitalization(maxPatient, oldHospital);
            this.HospitalizationRecords.FindRange(minHospitalization, maxHospitalization, hospitalizations);
            foreach(var hospitalization in hospitalizations)
            {
                var iteratorRecords = hospitalization.Records.createIterator();
                while (iteratorRecords.HasNext())
                {
                    var record = iteratorRecords.MoveNext();
                    //Delete from patient
                    record.HospitalizationRecord.Patient.AllRecords.Delete(record);
                    //Add new hospitalization
                    if(record.End == DateTime.MinValue)
                    {
                        record.HospitalizationRecord.Patient.ActualRecord = null;
                        this.AddRecord(newHospital, record.HospitalizationRecord.Patient, new Record(record.Start, record.Diagnoze));
                    } else
                    {
                        this.AddEndedRecord(newHospital, record.HospitalizationRecord.Patient, new Record(record.Start, record.End,record.Diagnoze));
                    }
                }
                this.HospitalizationRecords.Delete(hospitalization);
            }
            return true;
        }
    }
}
