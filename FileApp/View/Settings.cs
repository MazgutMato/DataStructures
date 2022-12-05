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
        private readonly int blockFactor = 50;
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
        private string RandomString(string chars, int minSize, int maxSize, bool firstUpper, bool allUpper)
        {
            var random = new Random();
            var word = new char[random.Next(minSize, maxSize)];

            if (firstUpper)
            {
                word[0] = Char.ToUpper(chars[random.Next(chars.Length)]);
            }
            else
            {
                word[0] = chars[random.Next(chars.Length)];
            }

            for (int i = 1; i < word.Length; i++)
            {
                if (allUpper)
                {
                    word[i] = Char.ToUpper(chars[random.Next(chars.Length)]);
                }
                else
                {
                    word[i] = chars[random.Next(chars.Length)];
                }
            }

            return new string(word);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (this.PatientsController.Patients == null)
            {
                MessageBox.Show("Type of file is not selected!",
                    "Select file type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textPatients.Text.Length == 0 || Convert.ToInt32(textPatients.Text) <= 0)
            {
                MessageBox.Show("Please enter number greater then 0!",
                    "Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var patients = Convert.ToInt32(textPatients.Text);

            if (textRecords.Text.Length == 0 || Convert.ToInt32(textRecords.Text) <= 0)
            {
                MessageBox.Show("Please enter number greater then 0!",
                    "Generator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var records = Convert.ToInt32(textRecords.Text);
            var random = new Random();

            while(patients > 0)
            {
                var newPatient = new Patient();
                //city.Zip = this.RandomString("0123456789", 5, 5, false, false);
                newPatient.Id = this.RandomString("0123456789", 10, 10, false, false).ToCharArray();
                newPatient.FirstName = this.RandomString("abcdefghijklmnopqrstuvwxyz", 5, 15, true, false).ToCharArray();
                newPatient.LastName = this.RandomString("abcdefghijklmnopqrstuvwxyz", 5, 20, true, false).ToCharArray();
                newPatient.Insurance = Convert.ToByte(random.Next(0, 15));
                newPatient.BirthDate = DateTime.Now.AddYears(-random.Next(0,80));

                var numberRecords = 0;
                if(records > 10)
                {
                    numberRecords = random.Next(0,10);
                }
                else
                {
                    numberRecords = records;
                }
                for(int i = 0; i < numberRecords; i++)
                {
                    var newRecord = new Record();
                    var start = random.Next(50, 365);
                    newRecord.Start = DateTime.Now.AddDays(-start);
                    newRecord.End = newRecord.Start.AddDays(random.Next(0, 30));
                    newRecord.Diagnoze = this.RandomString("abcdefghijklmnopqrstuvwxyz", 5, 15, true, false).ToCharArray();
                    if (newPatient.AddRecord(newRecord))
                    {
                        records--;
                    }

                    if (random.Next(0, 2) == 0)
                    {
                        var actualRecord = new Record();
                        var actualRecordStart = random.Next(50, 365);
                        newRecord.Start = DateTime.Now.AddDays(-actualRecordStart);
                        newRecord.Diagnoze = this.RandomString("abcdefghijklmnopqrstuvwxyz", 5, 15, true, false).ToCharArray();
                        if (newPatient.AddRecord(actualRecord))
                        {
                            records--;
                        }
                    }
                }
                
                if (PatientsController.AddPatient(newPatient))
                {
                    patients--;
                }
            }
        }
    }
}
