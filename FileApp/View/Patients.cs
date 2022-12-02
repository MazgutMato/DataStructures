using FileApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileApp.View
{
    public partial class Patients : UserControl
    {
        PatientsController PatientsController;
        public Patients(PatientsController patientsController)
        {
            InitializeComponent();
            this.PatientsController = patientsController;
        }

        private void Patients_Load(object sender, EventArgs e)
        {

        }

        private void patientSubmit_Click(object sender, EventArgs e)
        {
            var patient = new Patient();
            patient.FirstName = textFirstName.Text.ToCharArray();
        }
    }
}
