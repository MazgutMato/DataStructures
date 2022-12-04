using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.File;
using FileApp.Models;

namespace FileApp
{
    public class PatientsController
    {
        public BasicFile<Patient>? Patients;

        public PatientsController()
        {
            Patients = null;
        }

        public PatientsController(BasicFile<Patient>? patients)
        {
            Patients = patients;
        }

        public bool AddPatient(Patient patient)
        {
            if(Patients == null)
            {
                return false;
            }
            if(Patients.Find(patient) != null)
            {
                return false;
            }
            return this.Patients.Add(patient);
        }

        public Patient? Find(Patient patient)
        {
            if(Patients == null)
            {
                return null;
            }
            var findPatient = this.Patients.Find(patient);
            return findPatient == null ? null : new Patient(findPatient);
        }

        public bool DeletePatient(Patient patient)
        {
            if (Patients == null)
            {
                return false;
            }
            return this.Patients.Delete(patient);
        }

        public bool AddRecord(Patient patient, Record record)
        {
            if (Patients == null)
            {
                return false;
            }
            var findPatient = this.Patients.Find(patient);
            if(findPatient == null)
            {
                return false;
            }
            if (findPatient.AddRecord(record))
            {
                this.Patients.Delete(findPatient);
                this.Patients.Add(findPatient);
            } else
            {
                return false;
            }
            return true;
        }
        public bool EndRecord(Patient patient, Record record)
        {
            if (Patients == null)
            {
                return false;
            }
            var findPatient = this.Patients.Find(patient);
            if (findPatient == null)
            {
                return false;
            }
            if (findPatient.EndRecord(record))
            {
                this.Patients.Delete(findPatient);
                this.Patients.Add(findPatient);
            }
            else
            {
                return false;
            }
            return true;            
        }
        public bool DeleteRecord(Patient patient, Record record)
        {
            if (Patients == null)
            {
                return false;
            }
            var findPatient = this.Patients.Find(patient);
            if (findPatient == null)
            {
                return false;
            }
            if (findPatient.DeleteRecord(record))
            {
                this.Patients.Delete(findPatient);
                this.Patients.Add(findPatient);
            }
            else
            {
                return false;
            }
            return true;
        }
        public void Save()
        {
            if(this.Patients != null)
            {
                Patients.SaveFile();
            }
        }
    }
}
