using DataStructures.Iterator;
using DataStructures.Tree.BSTree;
using ElectronicHealthCard.Models;

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
        public int GetCount()
        {
            return this.Hospitals.Count;
        }
        public Iterator<Hospital> GetPatients()
        {
            return Hospitals.createIterator();
        }
        public Hospital FindHospital(Hospital hospital)
        {
            return Hospitals.Find(hospital);
        }
    }
}
