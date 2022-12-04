namespace FileApp.View
{
    partial class FileInfo
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
            this.textInfo = new System.Windows.Forms.TextBox();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textInfo
            // 
            this.textInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textInfo.Location = new System.Drawing.Point(67, 43);
            this.textInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textInfo.Multiline = true;
            this.textInfo.Name = "textInfo";
            this.textInfo.ReadOnly = true;
            this.textInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInfo.Size = new System.Drawing.Size(762, 294);
            this.textInfo.TabIndex = 4;
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(719, 343);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(110, 44);
            this.buttonInfo.TabIndex = 5;
            this.buttonInfo.Text = "Get info";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // FileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.textInfo);
            this.Name = "FileInfo";
            this.Size = new System.Drawing.Size(950, 500);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textInfo;
        private Button buttonInfo;
    }
}
