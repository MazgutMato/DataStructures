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
    public partial class Records : UserControl
    {
        PatientsController PatientsController;
        public Records(PatientsController patientsController)
        {
            InitializeComponent();
            PatientsController = patientsController;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (this.PatientsController.Patients == null)
            {
                MessageBox.Show("Type of file is not selected!",
                    "Select file type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var patient = new Patient();

            if (startPatient.Text.Length != 10)
            {
                MessageBox.Show("Id have to be 10 chars long!",
                    "Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            patient.Id = startPatient.Text.ToCharArray();

            var record = new Record();
            record.Start = dateStart.Value;
            if (startDiagnosis.Text.Length > 20 || startDiagnosis.Text.Length == 0)
            {
                MessageBox.Show("Diagnosis cannot be empty and longer then 20 chars!",
                    "Diagnosis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            record.Diagnoze = startDiagnosis.Text.ToCharArray();

            if(PatientsController.AddRecord(patient, record))
            {
                MessageBox.Show("Record successfully added!",
                    "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Record add faild!",
                    "Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            if (this.PatientsController.Patients == null)
            {
                MessageBox.Show("Type of file is not selected!",
                    "Select file type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var patient = new Patient();

            if (endPatient.Text.Length != 10)
            {
                MessageBox.Show("Id have to be 10 chars long!",
                    "Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            patient.Id = startPatient.Text.ToCharArray();

            var record = new Record();
            record.Start = dateStartEnd.Value;
            if(dateStartEnd.Value > dateEnd.Value)
            {
                MessageBox.Show("Date end cannot be earlier then start!",
                    "Date end", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            record.End = dateEnd.Value;

            if (PatientsController.EndRecord(patient, record))
            {
                MessageBox.Show("Record successfully ended!",
                    "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Record end faild!",
                    "Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.PatientsController.Patients == null)
            {
                MessageBox.Show("Type of file is not selected!",
                    "Select file type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var patient = new Patient();

            if (textDeletePatient.Text.Length != 10)
            {
                MessageBox.Show("Id have to be 10 chars long!",
                    "Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            patient.Id = textDeletePatient.Text.ToCharArray();

            var record = new Record();
            record.Id = Convert.ToInt32(textHospId.Text);            

            if (PatientsController.DeleteRecord(patient, record))
            {
                MessageBox.Show("Record successfully deleted!",
                    "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Record delete faild!",
                    "Diagnosis", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
