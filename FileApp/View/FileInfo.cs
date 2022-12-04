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
    public partial class FileInfo : UserControl
    {
        private PatientsController PatientsController;
        public FileInfo(PatientsController patientsController)
        {
            InitializeComponent();
            PatientsController = patientsController;
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (this.PatientsController.Patients == null)
            {
                MessageBox.Show("Type of file is not selected!",
                    "Select file type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.textInfo.Text = PatientsController.Patients.GetBlocksSequense();
        }
    }
}
