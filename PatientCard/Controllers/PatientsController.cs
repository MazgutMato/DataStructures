using DataStructures;
using DataStructures.File;
using DataStructures.Iterator;
using DataStructures.Tree.BSTree;
using PatientCard.Models;

namespace PatientCard.Controllers
{
    public class PatientsController
    {
        private Structure<Patient> Patients;
        public PatientsController()
        {
            Patients = new DynamicFile<Patient>(5,"Data");
        }
        public bool AddPatient(Patient patient)
        {
            return Patients.Add(patient);
        }
        public Patient? FindPatient(Patient patient)
        {
            return Patients.Find(patient);
        }
    }
}
