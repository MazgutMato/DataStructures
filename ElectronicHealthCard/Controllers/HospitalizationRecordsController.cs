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
        public bool AddRecord(Hospital hospital, Patient patient, Record record)
        {
            var HospRecord = new HospitalizationRecord(patient, hospital);
            var FindHospRecord = this.HospitalizationRecords.Find(HospRecord);
            if(FindHospRecord != null)
            {
                return FindHospRecord.AddRecord(record);
            } else
            {
                HospitalizationRecords.Add(HospRecord);
                return HospRecord.AddRecord(record);
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
    }
}
