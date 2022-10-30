using ElectronicHealthCard.Models;
using DataStructures.Tree.BSTree;

namespace ElectronicHealthCard.Controllers
{
    public class HospitalizationRecordsController
    {
        private BSTree<HospitalizationRecord> HospitalizationRecords;
        public HospitalizationRecordsController()
        {
            HospitalizationRecords = new BSTree<HospitalizationRecord>();
        }
        public int GetCount()
        {
            return HospitalizationRecords.Count;
        }
        public bool AddRecord(Hospital hospital, Patient patient, Record record)
        {
            var HospRecord = new HospitalizationRecord(patient, hospital);
            var FindHospRecord = this.HospitalizationRecords.Find(HospRecord);
            if(FindHospRecord != null)
            {
                return FindHospRecord.AddRecord(record);
            } else
            {
                if(HospitalizationRecords.Add(HospRecord))
                {
                    hospital.AddPatient(HospRecord);
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
            var HospRecord = new HospitalizationRecord(patient, hospital);
            var FindHospRecord = this.HospitalizationRecords.Find(HospRecord);
            if(FindHospRecord != null)
            {                
                return FindHospRecord.EndRecord(record);
            }
            return false;
        }
        public bool AddEndedRecord(Hospital hospital, Patient patient, Record record)
        {
            var HospRecord = new HospitalizationRecord(patient, hospital);
            var FindHospRecord = this.HospitalizationRecords.Find(HospRecord);
            if (FindHospRecord != null)
            {
                record.HospitalizationRecord = FindHospRecord;
                return FindHospRecord.AddEndedRecord(record);
            }
            else
            {
                if (HospitalizationRecords.Add(HospRecord))
                {
                    record.HospitalizationRecord = HospRecord;
                    hospital.AddPatient(HospRecord);
                    return HospRecord.AddEndedRecord(record);
                }
                else
                {
                    return false;
                }              
            }
        }
        public bool AddEndedRecords(List<HospitalizationRecord> records)
        {
            if (this.HospitalizationRecords.FillWithMedian(records))
            {
                var iterator = this.HospitalizationRecords.createIterator();
                while (iterator.HasNext())
                {
                    var actual =  iterator.MoveNext();
                    actual.Hospital.AddPatient(actual);
                }
                return true;
            } else
            {
                return false;
            }
        }
        public HospitalizationRecord FindHospitalizationRecord(Patient patient, Hospital hospital)
        {
            return this.HospitalizationRecords.Find(new HospitalizationRecord(patient, hospital));
        }
    }
}
