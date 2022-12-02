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
            this.StaticFileButton.Location = new System.Drawing.Point(33, 27);
            this.StaticFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.StaticFileButton.Name = "StaticFileButton";
            this.StaticFileButton.Size = new System.Drawing.Size(112, 32);
            this.StaticFileButton.TabIndex = 0;
            this.StaticFileButton.Text = "StaticFile";
            this.StaticFileButton.UseVisualStyleBackColor = true;
            this.StaticFileButton.Click += new System.EventHandler(this.StaticFileButton_Click);
            // 
            // DynamicFileButton
            // 
            this.DynamicFileButton.Location = new System.Drawing.Point(33, 63);
            this.DynamicFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.DynamicFileButton.Name = "DynamicFileButton";
            this.DynamicFileButton.Size = new System.Drawing.Size(112, 32);
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
            this.labelFile.Size = new System.Drawing.Size(76, 21);
            this.labelFile.TabIndex = 2;
            this.labelFile.Text = "File type:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.DynamicFileButton);
            this.Controls.Add(this.StaticFileButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(720, 362);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button StaticFileButton;
        private Button DynamicFileButton;
        private Label labelFile;
    }
}
