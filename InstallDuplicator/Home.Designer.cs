﻿namespace InstallDuplicator
{
    partial class Home
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DuplicateButton = new System.Windows.Forms.Button();
            this.LogGroupBox = new System.Windows.Forms.GroupBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.SelectFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.LinkTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.HardRadioButton = new System.Windows.Forms.RadioButton();
            this.SymbolicRadioButton = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LogGroupBox.SuspendLayout();
            this.LinkTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DuplicateButton
            // 
            this.DuplicateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DuplicateButton.Location = new System.Drawing.Point(12, 426);
            this.DuplicateButton.Name = "DuplicateButton";
            this.DuplicateButton.Size = new System.Drawing.Size(460, 23);
            this.DuplicateButton.TabIndex = 2;
            this.DuplicateButton.Text = "Duplicate GTA V Folder";
            this.DuplicateButton.UseVisualStyleBackColor = true;
            this.DuplicateButton.Click += new System.EventHandler(this.DuplicateButton_Click);
            // 
            // LogGroupBox
            // 
            this.LogGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogGroupBox.Controls.Add(this.LogTextBox);
            this.LogGroupBox.Location = new System.Drawing.Point(12, 186);
            this.LogGroupBox.Name = "LogGroupBox";
            this.LogGroupBox.Size = new System.Drawing.Size(460, 234);
            this.LogGroupBox.TabIndex = 3;
            this.LogGroupBox.TabStop = false;
            this.LogGroupBox.Text = "Logging";
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(3, 16);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(454, 215);
            this.LogTextBox.TabIndex = 0;
            // 
            // LinkTypeGroupBox
            // 
            this.LinkTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkTypeGroupBox.Controls.Add(this.HardRadioButton);
            this.LinkTypeGroupBox.Controls.Add(this.SymbolicRadioButton);
            this.LinkTypeGroupBox.Location = new System.Drawing.Point(12, 114);
            this.LinkTypeGroupBox.Name = "LinkTypeGroupBox";
            this.LinkTypeGroupBox.Size = new System.Drawing.Size(460, 66);
            this.LinkTypeGroupBox.TabIndex = 4;
            this.LinkTypeGroupBox.TabStop = false;
            this.LinkTypeGroupBox.Text = "Link Type";
            // 
            // HardRadioButton
            // 
            this.HardRadioButton.AutoSize = true;
            this.HardRadioButton.Checked = true;
            this.HardRadioButton.Location = new System.Drawing.Point(6, 19);
            this.HardRadioButton.Name = "HardRadioButton";
            this.HardRadioButton.Size = new System.Drawing.Size(350, 17);
            this.HardRadioButton.TabIndex = 1;
            this.HardRadioButton.TabStop = true;
            this.HardRadioButton.Text = "Hard Link for Files and Symbolic Links for Folders (All Game Versions)";
            this.HardRadioButton.UseVisualStyleBackColor = true;
            // 
            // SymbolicRadioButton
            // 
            this.SymbolicRadioButton.AutoSize = true;
            this.SymbolicRadioButton.Location = new System.Drawing.Point(6, 42);
            this.SymbolicRadioButton.Name = "SymbolicRadioButton";
            this.SymbolicRadioButton.Size = new System.Drawing.Size(425, 17);
            this.SymbolicRadioButton.TabIndex = 0;
            this.SymbolicRadioButton.Text = "Symbolic Links for Files and Folders (Steam and non Rockstar Games Launcher only)" +
    "";
            this.SymbolicRadioButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(367, 20);
            this.textBox1.TabIndex = 0;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.LinkTypeGroupBox);
            this.Controls.Add(this.LogGroupBox);
            this.Controls.Add(this.DuplicateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatchMyPath Install Duplicator";
            this.LogGroupBox.ResumeLayout(false);
            this.LogGroupBox.PerformLayout();
            this.LinkTypeGroupBox.ResumeLayout(false);
            this.LinkTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button DuplicateButton;
        private System.Windows.Forms.GroupBox LogGroupBox;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.FolderBrowserDialog SelectFolderBrowserDialog;
        private System.Windows.Forms.GroupBox LinkTypeGroupBox;
        private System.Windows.Forms.RadioButton SymbolicRadioButton;
        private System.Windows.Forms.RadioButton HardRadioButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

