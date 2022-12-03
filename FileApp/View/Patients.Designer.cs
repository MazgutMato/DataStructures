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
            this.birthPicker = new System.Windows.Forms.DateTimePicker();
            this.labelInsurance = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.textInsurance = new System.Windows.Forms.TextBox();
            this.labelAddPatient = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelIdDelete = new System.Windows.Forms.Label();
            this.textIDDelete = new System.Windows.Forms.TextBox();
            this.labelDelete = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textFirstName
            // 
            this.textFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textFirstName.Location = new System.Drawing.Point(136, 10);
            this.textFirstName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(193, 27);
            this.textFirstName.TabIndex = 0;
            // 
            // patientSubmit
            // 
            this.patientSubmit.Location = new System.Drawing.Point(219, 285);
            this.patientSubmit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.patientSubmit.Name = "patientSubmit";
            this.patientSubmit.Size = new System.Drawing.Size(119, 35);
            this.patientSubmit.TabIndex = 1;
            this.patientSubmit.Text = "Add";
            this.patientSubmit.UseVisualStyleBackColor = true;
            this.patientSubmit.Click += new System.EventHandler(this.patientSubmit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.birthPicker, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelInsurance, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textID, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textLastName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelID, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelLastName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelFirstName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textInsurance, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textFirstName, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 40);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 239);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // birthPicker
            // 
            this.birthPicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.birthPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthPicker.Location = new System.Drawing.Point(137, 151);
            this.birthPicker.Name = "birthPicker";
            this.birthPicker.Size = new System.Drawing.Size(192, 27);
            this.birthPicker.TabIndex = 4;
            // 
            // labelInsurance
            // 
            this.labelInsurance.AutoSize = true;
            this.labelInsurance.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelInsurance.Location = new System.Drawing.Point(58, 188);
            this.labelInsurance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInsurance.Name = "labelInsurance";
            this.labelInsurance.Size = new System.Drawing.Size(74, 51);
            this.labelInsurance.TabIndex = 4;
            this.labelInsurance.Text = "Insurance:";
            this.labelInsurance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textID
            // 
            this.textID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textID.Location = new System.Drawing.Point(136, 104);
            this.textID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(193, 27);
            this.textID.TabIndex = 4;
            // 
            // textLastName
            // 
            this.textLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textLastName.Location = new System.Drawing.Point(136, 57);
            this.textLastName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textLastName.Name = "textLastName";
            this.textLastName.Size = new System.Drawing.Size(193, 27);
            this.textLastName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(57, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 47);
            this.label3.TabIndex = 4;
            this.label3.Text = "BirthDate:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelID.Location = new System.Drawing.Point(105, 94);
            this.labelID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(27, 47);
            this.labelID.TabIndex = 4;
            this.labelID.Text = "ID:";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelLastName.Location = new System.Drawing.Point(54, 47);
            this.labelLastName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(78, 47);
            this.labelLastName.TabIndex = 4;
            this.labelLastName.Text = "LastName:";
            this.labelLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelFirstName.Location = new System.Drawing.Point(53, 0);
            this.labelFirstName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(79, 47);
            this.labelFirstName.TabIndex = 2;
            this.labelFirstName.Text = "FirstName:";
            this.labelFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textInsurance
            // 
            this.textInsurance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textInsurance.Location = new System.Drawing.Point(136, 200);
            this.textInsurance.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textInsurance.Name = "textInsurance";
            this.textInsurance.Size = new System.Drawing.Size(193, 27);
            this.textInsurance.TabIndex = 5;
            // 
            // labelAddPatient
            // 
            this.labelAddPatient.AutoSize = true;
            this.labelAddPatient.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelAddPatient.Location = new System.Drawing.Point(91, 0);
            this.labelAddPatient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAddPatient.Name = "labelAddPatient";
            this.labelAddPatient.Size = new System.Drawing.Size(50, 28);
            this.labelAddPatient.TabIndex = 3;
            this.labelAddPatient.Text = "Add";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(588, 89);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(119, 35);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.labelIdDelete, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textIDDelete, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(378, 40);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(336, 42);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // labelIdDelete
            // 
            this.labelIdDelete.AutoSize = true;
            this.labelIdDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelIdDelete.Location = new System.Drawing.Point(105, 0);
            this.labelIdDelete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIdDelete.Name = "labelIdDelete";
            this.labelIdDelete.Size = new System.Drawing.Size(27, 42);
            this.labelIdDelete.TabIndex = 2;
            this.labelIdDelete.Text = "ID:";
            this.labelIdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textIDDelete
            // 
            this.textIDDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIDDelete.Location = new System.Drawing.Point(136, 7);
            this.textIDDelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textIDDelete.Name = "textIDDelete";
            this.textIDDelete.Size = new System.Drawing.Size(193, 27);
            this.textIDDelete.TabIndex = 0;
            // 
            // labelDelete
            // 
            this.labelDelete.AutoSize = true;
            this.labelDelete.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelDelete.Location = new System.Drawing.Point(439, 0);
            this.labelDelete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDelete.Name = "labelDelete";
            this.labelDelete.Size = new System.Drawing.Size(71, 28);
            this.labelDelete.TabIndex = 8;
            this.labelDelete.Text = "Delete";
            // 
            // Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelDelete);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.patientSubmit);
            this.Controls.Add(this.labelAddPatient);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Patients";
            this.Size = new System.Drawing.Size(950, 500);
            this.Load += new System.EventHandler(this.Patients_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textFirstName;
        private Button patientSubmit;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelInsurance;
        private TextBox textID;
        private TextBox textLastName;
        private Label label3;
        private Label labelID;
        private Label labelLastName;
        private Label labelFirstName;
        private Label labelAddPatient;
        private DateTimePicker birthPicker;
        private Button buttonDelete;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelIdDelete;
        private TextBox textIDDelete;
        private Label labelDelete;
        private TextBox textInsurance;
    }
}
