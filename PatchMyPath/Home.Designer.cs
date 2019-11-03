namespace PatchMyPath
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
            this.GeneralTabControl = new System.Windows.Forms.TabControl();
            this.InstallsTabPage = new System.Windows.Forms.TabPage();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.InstallsGroupBox = new System.Windows.Forms.GroupBox();
            this.InstallsListBox = new System.Windows.Forms.ListBox();
            this.DuplicatorTabPage = new System.Windows.Forms.TabPage();
            this.AutoAddGroupBox = new System.Windows.Forms.GroupBox();
            this.AutoAddCheckBox = new System.Windows.Forms.CheckBox();
            this.LogGroupBox = new System.Windows.Forms.GroupBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.LinkTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.HardRadioButton = new System.Windows.Forms.RadioButton();
            this.SymbolicRadioButton = new System.Windows.Forms.RadioButton();
            this.DuplicateButton = new System.Windows.Forms.Button();
            this.OriginGroupBox = new System.Windows.Forms.GroupBox();
            this.OriginSelectButton = new System.Windows.Forms.Button();
            this.OriginTextBox = new System.Windows.Forms.TextBox();
            this.DestinationGroupBox = new System.Windows.Forms.GroupBox();
            this.DestinationSelectButton = new System.Windows.Forms.Button();
            this.DestinationTextBox = new System.Windows.Forms.TextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.GeneralTabControl.SuspendLayout();
            this.InstallsTabPage.SuspendLayout();
            this.InstallsGroupBox.SuspendLayout();
            this.DuplicatorTabPage.SuspendLayout();
            this.AutoAddGroupBox.SuspendLayout();
            this.LogGroupBox.SuspendLayout();
            this.LinkTypeGroupBox.SuspendLayout();
            this.OriginGroupBox.SuspendLayout();
            this.DestinationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneralTabControl
            // 
            this.GeneralTabControl.Controls.Add(this.InstallsTabPage);
            this.GeneralTabControl.Controls.Add(this.DuplicatorTabPage);
            this.GeneralTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralTabControl.Location = new System.Drawing.Point(0, 24);
            this.GeneralTabControl.Name = "GeneralTabControl";
            this.GeneralTabControl.SelectedIndex = 0;
            this.GeneralTabControl.Size = new System.Drawing.Size(334, 437);
            this.GeneralTabControl.TabIndex = 0;
            // 
            // InstallsTabPage
            // 
            this.InstallsTabPage.Controls.Add(this.RefreshButton);
            this.InstallsTabPage.Controls.Add(this.LaunchButton);
            this.InstallsTabPage.Controls.Add(this.DeleteButton);
            this.InstallsTabPage.Controls.Add(this.AddButton);
            this.InstallsTabPage.Controls.Add(this.InstallsGroupBox);
            this.InstallsTabPage.Location = new System.Drawing.Point(4, 22);
            this.InstallsTabPage.Name = "InstallsTabPage";
            this.InstallsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.InstallsTabPage.Size = new System.Drawing.Size(326, 411);
            this.InstallsTabPage.TabIndex = 0;
            this.InstallsTabPage.Text = "Install Manager";
            this.InstallsTabPage.UseVisualStyleBackColor = true;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RefreshButton.Location = new System.Drawing.Point(89, 351);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // LaunchButton
            // 
            this.LaunchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LaunchButton.Location = new System.Drawing.Point(8, 351);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(75, 23);
            this.LaunchButton.TabIndex = 3;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Location = new System.Drawing.Point(89, 380);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(8, 380);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // InstallsGroupBox
            // 
            this.InstallsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallsGroupBox.Controls.Add(this.InstallsListBox);
            this.InstallsGroupBox.Location = new System.Drawing.Point(8, 6);
            this.InstallsGroupBox.Name = "InstallsGroupBox";
            this.InstallsGroupBox.Size = new System.Drawing.Size(310, 339);
            this.InstallsGroupBox.TabIndex = 0;
            this.InstallsGroupBox.TabStop = false;
            this.InstallsGroupBox.Text = "Available Installs";
            // 
            // InstallsListBox
            // 
            this.InstallsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstallsListBox.FormattingEnabled = true;
            this.InstallsListBox.Location = new System.Drawing.Point(3, 16);
            this.InstallsListBox.Name = "InstallsListBox";
            this.InstallsListBox.Size = new System.Drawing.Size(304, 320);
            this.InstallsListBox.TabIndex = 0;
            this.InstallsListBox.SelectedIndexChanged += new System.EventHandler(this.InstallsListBox_SelectedIndexChanged);
            // 
            // DuplicatorTabPage
            // 
            this.DuplicatorTabPage.Controls.Add(this.AutoAddGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.LogGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.LinkTypeGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.DuplicateButton);
            this.DuplicatorTabPage.Controls.Add(this.OriginGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.DestinationGroupBox);
            this.DuplicatorTabPage.Location = new System.Drawing.Point(4, 22);
            this.DuplicatorTabPage.Name = "DuplicatorTabPage";
            this.DuplicatorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DuplicatorTabPage.Size = new System.Drawing.Size(326, 435);
            this.DuplicatorTabPage.TabIndex = 1;
            this.DuplicatorTabPage.Text = "Duplicator";
            this.DuplicatorTabPage.UseVisualStyleBackColor = true;
            // 
            // AutoAddGroupBox
            // 
            this.AutoAddGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoAddGroupBox.Controls.Add(this.AutoAddCheckBox);
            this.AutoAddGroupBox.Location = new System.Drawing.Point(6, 215);
            this.AutoAddGroupBox.Name = "AutoAddGroupBox";
            this.AutoAddGroupBox.Size = new System.Drawing.Size(314, 42);
            this.AutoAddGroupBox.TabIndex = 6;
            this.AutoAddGroupBox.TabStop = false;
            this.AutoAddGroupBox.Text = "Add to the Manager";
            // 
            // AutoAddCheckBox
            // 
            this.AutoAddCheckBox.AutoSize = true;
            this.AutoAddCheckBox.Location = new System.Drawing.Point(6, 19);
            this.AutoAddCheckBox.Name = "AutoAddCheckBox";
            this.AutoAddCheckBox.Size = new System.Drawing.Size(289, 17);
            this.AutoAddCheckBox.TabIndex = 0;
            this.AutoAddCheckBox.Text = "Add install to PatchMyPath after completing the process";
            this.AutoAddCheckBox.UseVisualStyleBackColor = true;
            // 
            // LogGroupBox
            // 
            this.LogGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogGroupBox.Controls.Add(this.LogTextBox);
            this.LogGroupBox.Location = new System.Drawing.Point(6, 263);
            this.LogGroupBox.Name = "LogGroupBox";
            this.LogGroupBox.Size = new System.Drawing.Size(312, 137);
            this.LogGroupBox.TabIndex = 4;
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
            this.LogTextBox.Size = new System.Drawing.Size(306, 118);
            this.LogTextBox.TabIndex = 0;
            // 
            // LinkTypeGroupBox
            // 
            this.LinkTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkTypeGroupBox.Controls.Add(this.HardRadioButton);
            this.LinkTypeGroupBox.Controls.Add(this.SymbolicRadioButton);
            this.LinkTypeGroupBox.Location = new System.Drawing.Point(6, 108);
            this.LinkTypeGroupBox.Name = "LinkTypeGroupBox";
            this.LinkTypeGroupBox.Size = new System.Drawing.Size(314, 101);
            this.LinkTypeGroupBox.TabIndex = 5;
            this.LinkTypeGroupBox.TabStop = false;
            this.LinkTypeGroupBox.Text = "Link Type";
            // 
            // HardRadioButton
            // 
            this.HardRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HardRadioButton.Checked = true;
            this.HardRadioButton.Location = new System.Drawing.Point(6, 19);
            this.HardRadioButton.Name = "HardRadioButton";
            this.HardRadioButton.Size = new System.Drawing.Size(302, 34);
            this.HardRadioButton.TabIndex = 1;
            this.HardRadioButton.TabStop = true;
            this.HardRadioButton.Text = "Hard Link for Files and Symbolic Links for Folders (All Game Versions)";
            this.HardRadioButton.UseVisualStyleBackColor = true;
            // 
            // SymbolicRadioButton
            // 
            this.SymbolicRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SymbolicRadioButton.Location = new System.Drawing.Point(6, 59);
            this.SymbolicRadioButton.Name = "SymbolicRadioButton";
            this.SymbolicRadioButton.Size = new System.Drawing.Size(302, 34);
            this.SymbolicRadioButton.TabIndex = 0;
            this.SymbolicRadioButton.Text = "Symbolic Links for Files and Folders (Steam and pre Rockstar Games Launcher only)" +
    "";
            this.SymbolicRadioButton.UseVisualStyleBackColor = true;
            // 
            // DuplicateButton
            // 
            this.DuplicateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DuplicateButton.Location = new System.Drawing.Point(6, 406);
            this.DuplicateButton.Name = "DuplicateButton";
            this.DuplicateButton.Size = new System.Drawing.Size(314, 23);
            this.DuplicateButton.TabIndex = 2;
            this.DuplicateButton.Text = "Duplicate GTA V Folder";
            this.DuplicateButton.UseVisualStyleBackColor = true;
            this.DuplicateButton.Click += new System.EventHandler(this.DuplicateButton_Click);
            // 
            // OriginGroupBox
            // 
            this.OriginGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginGroupBox.Controls.Add(this.OriginSelectButton);
            this.OriginGroupBox.Controls.Add(this.OriginTextBox);
            this.OriginGroupBox.Location = new System.Drawing.Point(6, 6);
            this.OriginGroupBox.Name = "OriginGroupBox";
            this.OriginGroupBox.Size = new System.Drawing.Size(314, 45);
            this.OriginGroupBox.TabIndex = 0;
            this.OriginGroupBox.TabStop = false;
            this.OriginGroupBox.Text = "Origin";
            // 
            // OriginSelectButton
            // 
            this.OriginSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginSelectButton.Location = new System.Drawing.Point(233, 17);
            this.OriginSelectButton.Name = "OriginSelectButton";
            this.OriginSelectButton.Size = new System.Drawing.Size(75, 23);
            this.OriginSelectButton.TabIndex = 1;
            this.OriginSelectButton.Text = "Select";
            this.OriginSelectButton.UseVisualStyleBackColor = true;
            this.OriginSelectButton.Click += new System.EventHandler(this.OriginSelectButton_Click);
            // 
            // OriginTextBox
            // 
            this.OriginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginTextBox.Location = new System.Drawing.Point(6, 19);
            this.OriginTextBox.Name = "OriginTextBox";
            this.OriginTextBox.ReadOnly = true;
            this.OriginTextBox.Size = new System.Drawing.Size(221, 20);
            this.OriginTextBox.TabIndex = 0;
            // 
            // DestinationGroupBox
            // 
            this.DestinationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationGroupBox.Controls.Add(this.DestinationSelectButton);
            this.DestinationGroupBox.Controls.Add(this.DestinationTextBox);
            this.DestinationGroupBox.Location = new System.Drawing.Point(6, 57);
            this.DestinationGroupBox.Name = "DestinationGroupBox";
            this.DestinationGroupBox.Size = new System.Drawing.Size(314, 45);
            this.DestinationGroupBox.TabIndex = 1;
            this.DestinationGroupBox.TabStop = false;
            this.DestinationGroupBox.Text = "Destination";
            // 
            // DestinationSelectButton
            // 
            this.DestinationSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationSelectButton.Location = new System.Drawing.Point(233, 17);
            this.DestinationSelectButton.Name = "DestinationSelectButton";
            this.DestinationSelectButton.Size = new System.Drawing.Size(75, 23);
            this.DestinationSelectButton.TabIndex = 1;
            this.DestinationSelectButton.Text = "Select";
            this.DestinationSelectButton.UseVisualStyleBackColor = true;
            this.DestinationSelectButton.Click += new System.EventHandler(this.DestinationSelectButton_Click);
            // 
            // DestinationTextBox
            // 
            this.DestinationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationTextBox.Location = new System.Drawing.Point(6, 19);
            this.DestinationTextBox.Name = "DestinationTextBox";
            this.DestinationTextBox.ReadOnly = true;
            this.DestinationTextBox.Size = new System.Drawing.Size(221, 20);
            this.DestinationTextBox.TabIndex = 0;
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Size = new System.Drawing.Size(334, 24);
            this.TopMenuStrip.TabIndex = 1;
            this.TopMenuStrip.Text = "menuStrip1";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 461);
            this.Controls.Add(this.GeneralTabControl);
            this.Controls.Add(this.TopMenuStrip);
            this.MainMenuStrip = this.TopMenuStrip;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatchMyPath";
            this.GeneralTabControl.ResumeLayout(false);
            this.InstallsTabPage.ResumeLayout(false);
            this.InstallsGroupBox.ResumeLayout(false);
            this.DuplicatorTabPage.ResumeLayout(false);
            this.AutoAddGroupBox.ResumeLayout(false);
            this.AutoAddGroupBox.PerformLayout();
            this.LogGroupBox.ResumeLayout(false);
            this.LogGroupBox.PerformLayout();
            this.LinkTypeGroupBox.ResumeLayout(false);
            this.OriginGroupBox.ResumeLayout(false);
            this.OriginGroupBox.PerformLayout();
            this.DestinationGroupBox.ResumeLayout(false);
            this.DestinationGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl GeneralTabControl;
        private System.Windows.Forms.TabPage InstallsTabPage;
        private System.Windows.Forms.TabPage DuplicatorTabPage;
        private System.Windows.Forms.GroupBox InstallsGroupBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.ListBox InstallsListBox;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.GroupBox OriginGroupBox;
        private System.Windows.Forms.Button OriginSelectButton;
        private System.Windows.Forms.TextBox OriginTextBox;
        private System.Windows.Forms.GroupBox DestinationGroupBox;
        private System.Windows.Forms.Button DestinationSelectButton;
        private System.Windows.Forms.TextBox DestinationTextBox;
        private System.Windows.Forms.GroupBox LinkTypeGroupBox;
        private System.Windows.Forms.RadioButton HardRadioButton;
        private System.Windows.Forms.RadioButton SymbolicRadioButton;
        private System.Windows.Forms.Button DuplicateButton;
        private System.Windows.Forms.GroupBox LogGroupBox;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.GroupBox AutoAddGroupBox;
        private System.Windows.Forms.CheckBox AutoAddCheckBox;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.MenuStrip TopMenuStrip;
    }
}

