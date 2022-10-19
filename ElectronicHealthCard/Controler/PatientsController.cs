using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Tree.BSTree;
using ElectronicHealthCard.Model;
using ElectronicHealthCard.View;

namespace ElectronicHealthCard.Controler
{
    public class PatientsController
    {
        public IPatientsView PatientsView;
        public BSTree<Patient> Patients;
        public Patient SelectedPatient;
        public PatientsController(IPatientsView patientsView, BSTree<Patient> patients)
        {
            PatientsView = patientsView;
            Patients = patients;
            patientsView.SetController(this);
        }
    }
}
