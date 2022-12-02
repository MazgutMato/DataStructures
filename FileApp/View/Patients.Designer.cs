namespace FileApp.View
{
    partial class Patients
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.patientSubmit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelInsurance = new System.Windows.Forms.Label();
            this.textBirthDate = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.textInsurance = new System.Windows.Forms.TextBox();
            this.labelAddPatient = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textFirstName
            // 
            this.textFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textFirstName.Location = new System.Drawing.Point(86, 6);
            this.textFirstName.Margin = new System.Windows.Forms.Padding(2);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(133, 23);
            this.textFirstName.TabIndex = 0;
            // 
            // patientSubmit
            // 
            this.patientSubmit.Location = new System.Drawing.Point(150, 214);
            this.patientSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.patientSubmit.Name = "patientSubmit";
            this.patientSubmit.Size = new System.Drawing.Size(104, 26);
            this.patientSubmit.TabIndex = 1;
            this.patientSubmit.Text = "Add";
            this.patientSubmit.UseVisualStyleBackColor = true;
            this.patientSubmit.Click += new System.EventHandler(this.patientSubmit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.labelInsurance, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBirthDate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.textID, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textLastName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelLastName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textFirstName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelFirstName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textInsurance, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 180);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelInsurance
            // 
            this.labelInsurance.AutoSize = true;
            this.labelInsurance.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelInsurance.Location = new System.Drawing.Point(10, 144);
            this.labelInsurance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInsurance.Name = "labelInsurance";
            this.labelInsurance.Size = new System.Drawing.Size(72, 36);
            this.labelInsurance.TabIndex = 4;
            this.labelInsurance.Text = "InsuranceID:";
            this.labelInsurance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBirthDate
            // 
            this.textBirthDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBirthDate.Location = new System.Drawing.Point(86, 114);
            this.textBirthDate.Margin = new System.Windows.Forms.Padding(2);
            this.textBirthDate.Name = "textBirthDate";
            this.textBirthDate.Size = new System.Drawing.Size(133, 23);
            this.textBirthDate.TabIndex = 4;
            // 
            // textID
            // 
            this.textID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textID.Location = new System.Drawing.Point(86, 78);
            this.textID.Margin = new System.Windows.Forms.Padding(2);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(133, 23);
            this.textID.TabIndex = 4;
            // 
            // textLastName
            // 
            this.textLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textLastName.Location = new System.Drawing.Point(86, 42);
            this.textLastName.Margin = new System.Windows.Forms.Padding(2);
            this.textLastName.Name = "textLastName";
            this.textLastName.Size = new System.Drawing.Size(133, 23);
            this.textLastName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(23, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 36);
            this.label3.TabIndex = 4;
            this.label3.Text = "BirthDate:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelID.Location = new System.Drawing.Point(61, 72);
            this.labelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 36);
            this.labelID.TabIndex = 4;
            this.labelID.Text = "ID:";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelLastName.Location = new System.Drawing.Point(19, 36);
            this.labelLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(63, 36);
            this.labelLastName.TabIndex = 4;
            this.labelLastName.Text = "LastName:";
            this.labelLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelFirstName.Location = new System.Drawing.Point(18, 0);
            this.labelFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(64, 36);
            this.labelFirstName.TabIndex = 2;
            this.labelFirstName.Text = "FirstName:";
            this.labelFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textInsurance
            // 
            this.textInsurance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textInsurance.Location = new System.Drawing.Point(86, 150);
            this.textInsurance.Margin = new System.Windows.Forms.Padding(2);
            this.textInsurance.Name = "textInsurance";
            this.textInsurance.Size = new System.Drawing.Size(133, 23);
            this.textInsurance.TabIndex = 5;
            // 
            // labelAddPatient
            // 
            this.labelAddPatient.AutoSize = true;
            this.labelAddPatient.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelAddPatient.Location = new System.Drawing.Point(0, 0);
            this.labelAddPatient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddPatient.Name = "labelAddPatient";
            this.labelAddPatient.Size = new System.Drawing.Size(93, 21);
            this.labelAddPatient.TabIndex = 3;
            this.labelAddPatient.Text = "AddPatient";
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.patientSubmit);
            this.Controls.Add(this.labelAddPatient);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Patients";
            this.Size = new System.Drawing.Size(818, 371);
            this.Load += new System.EventHandler(this.Patients_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textFirstName;
        private Button patientSubmit;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelInsurance;
        private TextBox textBirthDate;
        private TextBox textID;
        private TextBox textLastName;
        private Label label3;
        private Label labelID;
        private Label labelLastName;
        private Label labelFirstName;
        private TextBox textInsurance;
        private Label labelAddPatient;
    }
}
