﻿using ElectronicHealthCard.Models;
using DataStructures.Tree.BSTree;

namespace ElectronicHealthCard.Controllers
{
    public class HospitalizationController
    {
        private BSTree<Hospitalization> HospitalizationRecords;
        public HospitalizationController()
        {
            HospitalizationRecords = new BSTree<Hospitalization>();
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
    }
}