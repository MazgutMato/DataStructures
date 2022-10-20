﻿using DataStructures.Iterator;
using DataStructures.Tree.BSTree;
using ElectronicHealthCard.Models;

namespace ElectronicHealthCard.Controllers
{
    public class PatientsController
    {
        private BSTree<Patient> Patients;
        public PatientsController()
        {
            Patients = new BSTree<Patient>();
        }
        public bool AddPatient(Patient patient)
        {
            return Patients.Add(patient);
        }
        public int GetCount()
        {
            return this.Patients.Count;
        }
        public Iterator<Patient> GetPatients()
        {
            return Patients.createIterator();
        }
    }
}
