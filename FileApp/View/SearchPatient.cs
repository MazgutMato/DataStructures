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
using static System.Net.Mime.MediaTypeNames;

namespace FileApp.View
{
    public partial class SearchPatient : UserControl
    {
        private PatientsController PatientsController;
        public SearchPatient(PatientsController patientsController)
        {
            InitializeComponent();
            PatientsController = patientsController;
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

            if (textIDDelete.Text.Length != 10)
            {
                MessageBox.Show("Id have to be 10 chars long!",
                    "Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            patient.Id = textIDDelete.Text.ToCharArray();

            var findPatient = PatientsController.Find(patient);

            if(findPatient == null)
            {
                MessageBox.Show("Patient with current id not exists!",
                    "Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(textHosp.Text != "")
            {
                textResult.Text = findPatient.ToString(Convert.ToByte(textHosp.Text));
            }
            else
            {
                textResult.Text = findPatient.ToString();
            }
        }
    }
}
