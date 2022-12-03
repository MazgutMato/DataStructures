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

namespace FileApp.View
{
    public partial class Settings : UserControl
    {
        PatientsController PatientsController;
        private readonly int blockFactor = 5;
        public Settings(PatientsController patientsController)
        {
            InitializeComponent();
            this.PatientsController = patientsController;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void StaticFileButton_Click(object sender, EventArgs e)
        {
            string message = "Do you want to load previous data?";
            string title = "Data load";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if(result == DialogResult.Cancel)
            {
                return;
            }
            if (result == DialogResult.Yes)
            {
                PatientsController.Patients = new StaticFile<Patient>("StaticFile");
            }
            else
            {
                PatientsController.Patients = new StaticFile<Patient>(blockFactor,"StaticFile");
            }
            StaticFileButton.Enabled = false;
            DynamicFileButton.Enabled = false;
            StaticFileButton.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
        }

        private void DynamicFileButton_Click(object sender, EventArgs e)
        {
            string message = "Do you want to load previous data?";
            string title = "Data load";
            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (result == DialogResult.Yes)
            {
                PatientsController.Patients = new DynamicFile<Patient>("DynamicFile");
            }
            else
            {
                PatientsController.Patients = new DynamicFile<Patient>(blockFactor, "DynamicFile");
            }
            StaticFileButton.Enabled = false;
            DynamicFileButton.Enabled = false;
            DynamicFileButton.BackColor = Color.FromKnownColor(KnownColor.ControlDark);
        }
    }
}
