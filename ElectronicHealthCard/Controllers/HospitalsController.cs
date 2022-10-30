using DataStructures.Iterator;
using DataStructures.Tree.BSTree;
using ElectronicHealthCard.Models;
using ElectronicHealthCard.Pages.Record;

namespace ElectronicHealthCard.Controllers
{
    public class HospitalsController
    {
        private BSTree<Hospital> Hospitals;
        public HospitalsController()
        {
            Hospitals = new BSTree<Hospital>();
        }
        public bool AddHospital(Hospital hospital)
        {
            return Hospitals.Add(hospital);
        }
        public bool AddHospitals(List<Hospital> hospitals)
        {
            return Hospitals.FillWithMedian(hospitals);
        }
        public int GetCount()
        {
            return this.Hospitals.Count;
        }
        public Iterator<Hospital> GetHospitals()
        {
            return Hospitals.createIterator();
        }
        public Hospital FindHospital(Hospital hospital)
        {
            return Hospitals.Find(hospital);
        }        
    }
}