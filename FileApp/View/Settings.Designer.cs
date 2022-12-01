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
            this.SuspendLayout();
            // 
            // StaticFileButton
            // 
            this.StaticFileButton.Location = new System.Drawing.Point(42, 92);
            this.StaticFileButton.Name = "StaticFileButton";
            this.StaticFileButton.Size = new System.Drawing.Size(189, 54);
            this.StaticFileButton.TabIndex = 0;
            this.StaticFileButton.Text = "StaticFile";
            this.StaticFileButton.UseVisualStyleBackColor = true;
            // 
            // DynamicFileButton
            // 
            this.DynamicFileButton.Location = new System.Drawing.Point(42, 152);
            this.DynamicFileButton.Name = "DynamicFileButton";
            this.DynamicFileButton.Size = new System.Drawing.Size(189, 54);
            this.DynamicFileButton.TabIndex = 1;
            this.DynamicFileButton.Text = "DynamicFile";
            this.DynamicFileButton.UseVisualStyleBackColor = true;
            this.DynamicFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelFile.Location = new System.Drawing.Point(42, 40);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(203, 38);
            this.labelFile.TabIndex = 2;
            this.labelFile.Text = "SelectFileType";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.DynamicFileButton);
            this.Controls.Add(this.StaticFileButton);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(1028, 604);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StaticFileButton;
        private Button DynamicFileButton;
        private Label labelFile;
    }
}
