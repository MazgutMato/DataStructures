namespace FileApp.View
{
    partial class SearchPatient
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.labelPatient = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelIdDelete = new System.Windows.Forms.Label();
            this.textIDDelete = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelHospitalization = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.textHosp = new System.Windows.Forms.TextBox();
            this.textResult = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(709, 57);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(119, 35);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelPatient
            // 
            this.labelPatient.AutoSize = true;
            this.labelPatient.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelPatient.Location = new System.Drawing.Point(79, 14);
            this.labelPatient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPatient.Name = "labelPatient";
            this.labelPatient.Size = new System.Drawing.Size(81, 28);
            this.labelPatient.TabIndex = 11;
            this.labelPatient.Text = "Patient";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.labelIdDelete, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textIDDelete, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(18, 54);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(336, 42);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // labelIdDelete
            // 
            this.labelIdDelete.AutoSize = true;
            this.labelIdDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelIdDelete.Location = new System.Drawing.Point(105, 0);
            this.labelIdDelete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIdDelete.Name = "labelIdDelete";
            this.labelIdDelete.Size = new System.Drawing.Size(27, 22);
            this.labelIdDelete.TabIndex = 2;
            this.labelIdDelete.Text = "ID:";
            this.labelIdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textIDDelete
            // 
            this.textIDDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textIDDelete.Location = new System.Drawing.Point(136, 3);
            this.textIDDelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textIDDelete.Name = "textIDDelete";
            this.textIDDelete.Size = new System.Drawing.Size(193, 27);
            this.textIDDelete.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(51, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 100);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.Location = new System.Drawing.Point(82, 36);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 27);
            this.textBox1.TabIndex = 0;
            // 
            // labelHospitalization
            // 
            this.labelHospitalization.AutoSize = true;
            this.labelHospitalization.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelHospitalization.Location = new System.Drawing.Point(430, 14);
            this.labelHospitalization.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHospitalization.Name = "labelHospitalization";
            this.labelHospitalization.Size = new System.Drawing.Size(158, 28);
            this.labelHospitalization.TabIndex = 13;
            this.labelHospitalization.Text = "Hospitalization";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.textHosp, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(369, 54);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(336, 42);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(105, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 42);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textHosp
            // 
            this.textHosp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textHosp.Location = new System.Drawing.Point(136, 7);
            this.textHosp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textHosp.Name = "textHosp";
            this.textHosp.Size = new System.Drawing.Size(193, 27);
            this.textHosp.TabIndex = 0;
            // 
            // textResult
            // 
            this.textResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textResult.Location = new System.Drawing.Point(30, 114);
            this.textResult.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.ReadOnly = true;
            this.textResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textResult.Size = new System.Drawing.Size(798, 306);
            this.textResult.TabIndex = 3;
            // 
            // SearchPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.labelHospitalization);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.labelPatient);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "SearchPatient";
            this.Size = new System.Drawing.Size(950, 500);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonSearch;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelIdDelete;
        private TextBox textIDDelete;
        public Label labelPatient;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox textBox1;
        public Label labelHospitalization;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label3;
        private TextBox textHosp;
        private TextBox textResult;
    }
}
