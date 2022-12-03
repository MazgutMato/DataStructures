using DataStructures.File;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        private bool IsCreateFile()
        {
            if (this.PatientsController.Patients == null)
            {
                MessageBox.Show("Type of file is not selected!",
                    "Select file type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void patientSubmit_Click(object sender, EventArgs e)
        {
            if (!this.IsCreateFile())
            {               
                return;
            }

            var patient = new Patient();

            if (textFirstName.Text.Length > 15 || textFirstName.Text.Length == 0)
            {
                MessageBox.Show("First name cannot be empty and longer then 15 chars!",
                    "First name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            patient.FirstName = textFirstName.Text.ToCharArray();

            if (textLastName.Text.Length > 20 || textLastName.Text.Length == 0)
            {
                MessageBox.Show("Last name cannot be empty and longer then 20 chars!",
                    "First name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            patient.LastName = textLastName.Text.ToCharArray();

            if (textID.Text.Length != 10)
            {
                MessageBox.Show("Id have to be 10 chars long!",
                    "Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            patient.Id = textID.Text.ToCharArray();

            patient.BirthDate= birthPicker.Value;

            if (System.Text.RegularExpressions.Regex.IsMatch(textInsurance.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers!",
                    "Insurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textInsurance.Text.Length == 0 || Convert.ToInt32(textInsurance.Text) < 0 || Convert.ToInt32(textInsurance.Text) > 255)
            {
                MessageBox.Show("Please enter number between 0 and 255!",
                    "Insurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            patient.Insurance = Convert.ToByte(textInsurance.Text);
            if (this.PatientsController.AddPatient(patient))
            {
                MessageBox.Show("Patient was successfully added!",
                    "Patient", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Patient already exists!",
                    "Patient", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!this.IsCreateFile())
            {
                return;
            }

            if (textIDDelete.Text.Length != 10)
            {
                MessageBox.Show("Id have to be 10 chars long!",
                    "Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var deletePatient = new Patient();
            deletePatient.Id = textIDDelete.Text.ToCharArray();

            if (PatientsController.DeletePatient(deletePatient))
            {
                MessageBox.Show("Patient was successfully deleted!",
                    "Patient", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Patient doesnt exist!",
                    "Patient", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
