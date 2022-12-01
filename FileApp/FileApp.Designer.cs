﻿namespace FileApp;

partial class FileApp
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.SettingsButton = new System.Windows.Forms.Button();
            this.PatientsButton = new System.Windows.Forms.Button();
            this.RecordsButton = new System.Windows.Forms.Button();
            this.NavigationPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Panel = new System.Windows.Forms.Panel();
            this.NavigationPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsButton
            // 
            this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsButton.Location = new System.Drawing.Point(3, 167);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(201, 78);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // PatientsButton
            // 
            this.PatientsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatientsButton.Location = new System.Drawing.Point(3, 3);
            this.PatientsButton.Name = "PatientsButton";
            this.PatientsButton.Size = new System.Drawing.Size(201, 76);
            this.PatientsButton.TabIndex = 1;
            this.PatientsButton.Text = "Patients";
            this.PatientsButton.UseVisualStyleBackColor = true;
            this.PatientsButton.Click += new System.EventHandler(this.PatientsButton_Click);
            // 
            // RecordsButton
            // 
            this.RecordsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecordsButton.Location = new System.Drawing.Point(3, 85);
            this.RecordsButton.Name = "RecordsButton";
            this.RecordsButton.Size = new System.Drawing.Size(201, 76);
            this.RecordsButton.TabIndex = 2;
            this.RecordsButton.Text = "Records";
            this.RecordsButton.UseVisualStyleBackColor = true;
            this.RecordsButton.Click += new System.EventHandler(this.RecordsButton_Click);
            // 
            // NavigationPanel
            // 
            this.NavigationPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.NavigationPanel.Controls.Add(this.tableLayoutPanel1);
            this.NavigationPanel.Location = new System.Drawing.Point(-7, -5);
            this.NavigationPanel.Name = "NavigationPanel";
            this.NavigationPanel.Size = new System.Drawing.Size(207, 551);
            this.NavigationPanel.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PatientsButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RecordsButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SettingsButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(207, 248);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.Window;
            this.Panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel.Location = new System.Drawing.Point(200, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(978, 544);
            this.Panel.TabIndex = 8;
            // 
            // FileApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 544);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.NavigationPanel);
            this.Name = "FileApp";
            this.Text = "FileApp";
            this.Load += new System.EventHandler(this.FileApp_Load);
            this.NavigationPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private Button SettingsButton;
    private Button PatientsButton;
    private Button RecordsButton;
    private Panel NavigationPanel;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel Panel;
}
