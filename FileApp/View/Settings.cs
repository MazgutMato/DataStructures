﻿using System;
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
        public Settings(PatientsController patientsController)
        {
            InitializeComponent();
            this.PatientsController = patientsController;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
