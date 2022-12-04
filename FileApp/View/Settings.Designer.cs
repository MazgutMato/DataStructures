namespace FileApp.View
{
    partial class Settings
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
            this.StaticFileButton = new System.Windows.Forms.Button();
            this.DynamicFileButton = new System.Windows.Forms.Button();
            this.labelFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.textRecords = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.textPatients = new System.Windows.Forms.TextBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // StaticFileButton
            // 
            this.StaticFileButton.Location = new System.Drawing.Point(38, 36);
            this.StaticFileButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.StaticFileButton.Name = "StaticFileButton";
            this.StaticFileButton.Size = new System.Drawing.Size(128, 43);
            this.StaticFileButton.TabIndex = 0;
            this.StaticFileButton.Text = "StaticFile";
            this.StaticFileButton.UseVisualStyleBackColor = true;
            this.StaticFileButton.Click += new System.EventHandler(this.StaticFileButton_Click);
            // 
            // DynamicFileButton
            // 
            this.DynamicFileButton.Location = new System.Drawing.Point(38, 84);
            this.DynamicFileButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DynamicFileButton.Name = "DynamicFileButton";
            this.DynamicFileButton.Size = new System.Drawing.Size(128, 43);
            this.DynamicFileButton.TabIndex = 1;
            this.DynamicFileButton.Text = "DynamicFile";
            this.DynamicFileButton.UseVisualStyleBackColor = true;
            this.DynamicFileButton.Click += new System.EventHandler(this.DynamicFileButton_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelFile.Location = new System.Drawing.Point(0, 0);
            this.labelFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(96, 28);
            this.labelFile.TabIndex = 2;
            this.labelFile.Text = "File type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(188, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Generator";
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 2;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel13.Controls.Add(this.textRecords, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel13.Location = new System.Drawing.Point(201, 84);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(336, 42);
            this.tableLayoutPanel13.TabIndex = 31;
            // 
            // textRecords
            // 
            this.textRecords.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textRecords.Location = new System.Drawing.Point(136, 7);
            this.textRecords.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textRecords.Name = "textRecords";
            this.textRecords.Size = new System.Drawing.Size(193, 27);
            this.textRecords.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Right;
            this.label15.Location = new System.Drawing.Point(47, 0);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 42);
            this.label15.TabIndex = 2;
            this.label15.Text = "Number of records:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel14.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.textPatients, 1, 0);
            this.tableLayoutPanel14.Location = new System.Drawing.Point(201, 36);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(336, 42);
            this.tableLayoutPanel14.TabIndex = 30;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Right;
            this.label17.Location = new System.Drawing.Point(47, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 42);
            this.label17.TabIndex = 2;
            this.label17.Text = "Number of patients:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textPatients
            // 
            this.textPatients.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textPatients.Location = new System.Drawing.Point(136, 7);
            this.textPatients.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textPatients.Name = "textPatients";
            this.textPatients.Size = new System.Drawing.Size(193, 27);
            this.textPatients.TabIndex = 0;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(418, 132);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(119, 35);
            this.buttonGenerate.TabIndex = 29;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel13);
            this.Controls.Add(this.tableLayoutPanel14);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.DynamicFileButton);
            this.Controls.Add(this.StaticFileButton);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(823, 483);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StaticFileButton;
        private Button DynamicFileButton;
        private Label labelFile;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel13;
        private TextBox textRecords;
        private Label label15;
        private TableLayoutPanel tableLayoutPanel14;
        private Label label17;
        private TextBox textPatients;
        private Button buttonGenerate;
    }
}
