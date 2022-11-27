using DataStructures;
using DataStructures.File;
using DataStructures.Iterator;
using DataStructures.Tree.BSTree;
using PatientCard.Models;

namespace PatientCard.Controllers
{
    public class PatientsController
    {
        public BasicFile<Patient>? Patients;
        public PatientsController()
        {
            Patients = null;
        }
        public bool AddPatient(Patient patient)
        {
            if(Patients == null)
            {
                return false;
            }
            return Patients.Add(patient);
        }
        public Patient? FindPatient(Patient patient)
        {
            if (Patients == null)
            {
                return null;
            }
            return Patients.Find(patient);
        }
    }
}
