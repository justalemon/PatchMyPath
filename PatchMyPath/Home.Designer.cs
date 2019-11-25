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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.GeneralTabControl = new System.Windows.Forms.TabControl();
            this.InstallsTabPage = new System.Windows.Forms.TabPage();
            this.InstallsListBox = new System.Windows.Forms.ListBox();
            this.DuplicatorTabPage = new System.Windows.Forms.TabPage();
            this.OtherGroupBox = new System.Windows.Forms.GroupBox();
            this.AutoAddCheckBox = new System.Windows.Forms.CheckBox();
            this.DuplicationProgressBar = new System.Windows.Forms.ProgressBar();
            this.GameGroupBox = new System.Windows.Forms.GroupBox();
            this.GameComboBox = new System.Windows.Forms.ComboBox();
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
            this.SettingsTabPage = new System.Windows.Forms.TabPage();
            this.RDR2LocationGroupBox = new System.Windows.Forms.GroupBox();
            this.RDR2LocationSaveButton = new System.Windows.Forms.Button();
            this.RDR2LocationDetectButton = new System.Windows.Forms.Button();
            this.RDR2LocationSelectButton = new System.Windows.Forms.Button();
            this.RDR2LocationTextBox = new System.Windows.Forms.TextBox();
            this.SteamGroupBox = new System.Windows.Forms.GroupBox();
            this.SteamGTAVCheckBox = new System.Windows.Forms.CheckBox();
            this.IDGTAVLabel = new System.Windows.Forms.Label();
            this.IDGTAVTextBox = new System.Windows.Forms.TextBox();
            this.SteamGTAVButton = new System.Windows.Forms.Button();
            this.SteamRDR2Button = new System.Windows.Forms.Button();
            this.IDRDR2Label = new System.Windows.Forms.Label();
            this.IDRDR2TextBox = new System.Windows.Forms.TextBox();
            this.SteamRDR2CheckBox = new System.Windows.Forms.CheckBox();
            this.GTAVLocationGroupBox = new System.Windows.Forms.GroupBox();
            this.GTAVLocationSaveButton = new System.Windows.Forms.Button();
            this.GTAVLocationDetectButton = new System.Windows.Forms.Button();
            this.GTAVLocationSelectButton = new System.Windows.Forms.Button();
            this.GTAVLocationTextBox = new System.Windows.Forms.TextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.LaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LanguageGroupBox = new System.Windows.Forms.GroupBox();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.GeneralTabControl.SuspendLayout();
            this.InstallsTabPage.SuspendLayout();
            this.DuplicatorTabPage.SuspendLayout();
            this.OtherGroupBox.SuspendLayout();
            this.GameGroupBox.SuspendLayout();
            this.LinkTypeGroupBox.SuspendLayout();
            this.OriginGroupBox.SuspendLayout();
            this.DestinationGroupBox.SuspendLayout();
            this.SettingsTabPage.SuspendLayout();
            this.RDR2LocationGroupBox.SuspendLayout();
            this.SteamGroupBox.SuspendLayout();
            this.GTAVLocationGroupBox.SuspendLayout();
            this.TopMenuStrip.SuspendLayout();
            this.LanguageGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneralTabControl
            // 
            this.GeneralTabControl.Controls.Add(this.InstallsTabPage);
            this.GeneralTabControl.Controls.Add(this.DuplicatorTabPage);
            this.GeneralTabControl.Controls.Add(this.SettingsTabPage);
            resources.ApplyResources(this.GeneralTabControl, "GeneralTabControl");
            this.GeneralTabControl.Name = "GeneralTabControl";
            this.GeneralTabControl.SelectedIndex = 0;
            // 
            // InstallsTabPage
            // 
            this.InstallsTabPage.Controls.Add(this.InstallsListBox);
            resources.ApplyResources(this.InstallsTabPage, "InstallsTabPage");
            this.InstallsTabPage.Name = "InstallsTabPage";
            this.InstallsTabPage.UseVisualStyleBackColor = true;
            // 
            // InstallsListBox
            // 
            resources.ApplyResources(this.InstallsListBox, "InstallsListBox");
            this.InstallsListBox.FormattingEnabled = true;
            this.InstallsListBox.Name = "InstallsListBox";
            this.InstallsListBox.SelectedIndexChanged += new System.EventHandler(this.InstallsListBox_SelectedIndexChanged);
            // 
            // DuplicatorTabPage
            // 
            this.DuplicatorTabPage.Controls.Add(this.OtherGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.DuplicationProgressBar);
            this.DuplicatorTabPage.Controls.Add(this.GameGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.LinkTypeGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.DuplicateButton);
            this.DuplicatorTabPage.Controls.Add(this.OriginGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.DestinationGroupBox);
            resources.ApplyResources(this.DuplicatorTabPage, "DuplicatorTabPage");
            this.DuplicatorTabPage.Name = "DuplicatorTabPage";
            this.DuplicatorTabPage.UseVisualStyleBackColor = true;
            // 
            // OtherGroupBox
            // 
            resources.ApplyResources(this.OtherGroupBox, "OtherGroupBox");
            this.OtherGroupBox.Controls.Add(this.AutoAddCheckBox);
            this.OtherGroupBox.Name = "OtherGroupBox";
            this.OtherGroupBox.TabStop = false;
            // 
            // AutoAddCheckBox
            // 
            resources.ApplyResources(this.AutoAddCheckBox, "AutoAddCheckBox");
            this.AutoAddCheckBox.Name = "AutoAddCheckBox";
            this.AutoAddCheckBox.UseVisualStyleBackColor = true;
            this.AutoAddCheckBox.CheckedChanged += new System.EventHandler(this.AutoAddCheckBox_CheckedChanged);
            // 
            // DuplicationProgressBar
            // 
            resources.ApplyResources(this.DuplicationProgressBar, "DuplicationProgressBar");
            this.DuplicationProgressBar.Name = "DuplicationProgressBar";
            // 
            // GameGroupBox
            // 
            resources.ApplyResources(this.GameGroupBox, "GameGroupBox");
            this.GameGroupBox.Controls.Add(this.GameComboBox);
            this.GameGroupBox.Name = "GameGroupBox";
            this.GameGroupBox.TabStop = false;
            // 
            // GameComboBox
            // 
            resources.ApplyResources(this.GameComboBox, "GameComboBox");
            this.GameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameComboBox.FormattingEnabled = true;
            this.GameComboBox.Name = "GameComboBox";
            // 
            // LinkTypeGroupBox
            // 
            resources.ApplyResources(this.LinkTypeGroupBox, "LinkTypeGroupBox");
            this.LinkTypeGroupBox.Controls.Add(this.HardRadioButton);
            this.LinkTypeGroupBox.Controls.Add(this.SymbolicRadioButton);
            this.LinkTypeGroupBox.Name = "LinkTypeGroupBox";
            this.LinkTypeGroupBox.TabStop = false;
            // 
            // HardRadioButton
            // 
            resources.ApplyResources(this.HardRadioButton, "HardRadioButton");
            this.HardRadioButton.Checked = true;
            this.HardRadioButton.Name = "HardRadioButton";
            this.HardRadioButton.TabStop = true;
            this.HardRadioButton.UseVisualStyleBackColor = true;
            // 
            // SymbolicRadioButton
            // 
            resources.ApplyResources(this.SymbolicRadioButton, "SymbolicRadioButton");
            this.SymbolicRadioButton.Name = "SymbolicRadioButton";
            this.SymbolicRadioButton.UseVisualStyleBackColor = true;
            // 
            // DuplicateButton
            // 
            resources.ApplyResources(this.DuplicateButton, "DuplicateButton");
            this.DuplicateButton.Name = "DuplicateButton";
            this.DuplicateButton.UseVisualStyleBackColor = true;
            this.DuplicateButton.Click += new System.EventHandler(this.DuplicateButton_Click);
            // 
            // OriginGroupBox
            // 
            resources.ApplyResources(this.OriginGroupBox, "OriginGroupBox");
            this.OriginGroupBox.Controls.Add(this.OriginSelectButton);
            this.OriginGroupBox.Controls.Add(this.OriginTextBox);
            this.OriginGroupBox.Name = "OriginGroupBox";
            this.OriginGroupBox.TabStop = false;
            // 
            // OriginSelectButton
            // 
            resources.ApplyResources(this.OriginSelectButton, "OriginSelectButton");
            this.OriginSelectButton.Name = "OriginSelectButton";
            this.OriginSelectButton.UseVisualStyleBackColor = true;
            this.OriginSelectButton.Click += new System.EventHandler(this.OriginSelectButton_Click);
            // 
            // OriginTextBox
            // 
            resources.ApplyResources(this.OriginTextBox, "OriginTextBox");
            this.OriginTextBox.Name = "OriginTextBox";
            this.OriginTextBox.ReadOnly = true;
            // 
            // DestinationGroupBox
            // 
            resources.ApplyResources(this.DestinationGroupBox, "DestinationGroupBox");
            this.DestinationGroupBox.Controls.Add(this.DestinationSelectButton);
            this.DestinationGroupBox.Controls.Add(this.DestinationTextBox);
            this.DestinationGroupBox.Name = "DestinationGroupBox";
            this.DestinationGroupBox.TabStop = false;
            // 
            // DestinationSelectButton
            // 
            resources.ApplyResources(this.DestinationSelectButton, "DestinationSelectButton");
            this.DestinationSelectButton.Name = "DestinationSelectButton";
            this.DestinationSelectButton.UseVisualStyleBackColor = true;
            this.DestinationSelectButton.Click += new System.EventHandler(this.DestinationSelectButton_Click);
            // 
            // DestinationTextBox
            // 
            resources.ApplyResources(this.DestinationTextBox, "DestinationTextBox");
            this.DestinationTextBox.Name = "DestinationTextBox";
            this.DestinationTextBox.ReadOnly = true;
            // 
            // SettingsTabPage
            // 
            this.SettingsTabPage.Controls.Add(this.LanguageGroupBox);
            this.SettingsTabPage.Controls.Add(this.RDR2LocationGroupBox);
            this.SettingsTabPage.Controls.Add(this.SteamGroupBox);
            this.SettingsTabPage.Controls.Add(this.GTAVLocationGroupBox);
            resources.ApplyResources(this.SettingsTabPage, "SettingsTabPage");
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // RDR2LocationGroupBox
            // 
            resources.ApplyResources(this.RDR2LocationGroupBox, "RDR2LocationGroupBox");
            this.RDR2LocationGroupBox.Controls.Add(this.RDR2LocationSaveButton);
            this.RDR2LocationGroupBox.Controls.Add(this.RDR2LocationDetectButton);
            this.RDR2LocationGroupBox.Controls.Add(this.RDR2LocationSelectButton);
            this.RDR2LocationGroupBox.Controls.Add(this.RDR2LocationTextBox);
            this.RDR2LocationGroupBox.Name = "RDR2LocationGroupBox";
            this.RDR2LocationGroupBox.TabStop = false;
            // 
            // RDR2LocationSaveButton
            // 
            resources.ApplyResources(this.RDR2LocationSaveButton, "RDR2LocationSaveButton");
            this.RDR2LocationSaveButton.Name = "RDR2LocationSaveButton";
            this.RDR2LocationSaveButton.UseVisualStyleBackColor = true;
            this.RDR2LocationSaveButton.Click += new System.EventHandler(this.RDR2LocationSaveButton_Click);
            // 
            // RDR2LocationDetectButton
            // 
            resources.ApplyResources(this.RDR2LocationDetectButton, "RDR2LocationDetectButton");
            this.RDR2LocationDetectButton.Name = "RDR2LocationDetectButton";
            this.RDR2LocationDetectButton.UseVisualStyleBackColor = true;
            this.RDR2LocationDetectButton.Click += new System.EventHandler(this.RDR2LocationDetectButton_Click);
            // 
            // RDR2LocationSelectButton
            // 
            resources.ApplyResources(this.RDR2LocationSelectButton, "RDR2LocationSelectButton");
            this.RDR2LocationSelectButton.Name = "RDR2LocationSelectButton";
            this.RDR2LocationSelectButton.UseVisualStyleBackColor = true;
            this.RDR2LocationSelectButton.Click += new System.EventHandler(this.RDR2LocationSelectButton_Click);
            // 
            // RDR2LocationTextBox
            // 
            resources.ApplyResources(this.RDR2LocationTextBox, "RDR2LocationTextBox");
            this.RDR2LocationTextBox.Name = "RDR2LocationTextBox";
            // 
            // SteamGroupBox
            // 
            resources.ApplyResources(this.SteamGroupBox, "SteamGroupBox");
            this.SteamGroupBox.Controls.Add(this.SteamGTAVCheckBox);
            this.SteamGroupBox.Controls.Add(this.IDGTAVLabel);
            this.SteamGroupBox.Controls.Add(this.IDGTAVTextBox);
            this.SteamGroupBox.Controls.Add(this.SteamGTAVButton);
            this.SteamGroupBox.Controls.Add(this.SteamRDR2Button);
            this.SteamGroupBox.Controls.Add(this.IDRDR2Label);
            this.SteamGroupBox.Controls.Add(this.IDRDR2TextBox);
            this.SteamGroupBox.Controls.Add(this.SteamRDR2CheckBox);
            this.SteamGroupBox.Name = "SteamGroupBox";
            this.SteamGroupBox.TabStop = false;
            // 
            // SteamGTAVCheckBox
            // 
            resources.ApplyResources(this.SteamGTAVCheckBox, "SteamGTAVCheckBox");
            this.SteamGTAVCheckBox.Name = "SteamGTAVCheckBox";
            this.SteamGTAVCheckBox.UseVisualStyleBackColor = true;
            this.SteamGTAVCheckBox.CheckedChanged += new System.EventHandler(this.SteamGTAVCheckBox_CheckedChanged);
            // 
            // IDGTAVLabel
            // 
            resources.ApplyResources(this.IDGTAVLabel, "IDGTAVLabel");
            this.IDGTAVLabel.Name = "IDGTAVLabel";
            // 
            // IDGTAVTextBox
            // 
            resources.ApplyResources(this.IDGTAVTextBox, "IDGTAVTextBox");
            this.IDGTAVTextBox.Name = "IDGTAVTextBox";
            // 
            // SteamGTAVButton
            // 
            resources.ApplyResources(this.SteamGTAVButton, "SteamGTAVButton");
            this.SteamGTAVButton.Name = "SteamGTAVButton";
            this.SteamGTAVButton.UseVisualStyleBackColor = true;
            this.SteamGTAVButton.Click += new System.EventHandler(this.SteamGTAVButton_Click);
            // 
            // SteamRDR2Button
            // 
            resources.ApplyResources(this.SteamRDR2Button, "SteamRDR2Button");
            this.SteamRDR2Button.Name = "SteamRDR2Button";
            this.SteamRDR2Button.UseVisualStyleBackColor = true;
            this.SteamRDR2Button.Click += new System.EventHandler(this.SteamRDR2Button_Click);
            // 
            // IDRDR2Label
            // 
            resources.ApplyResources(this.IDRDR2Label, "IDRDR2Label");
            this.IDRDR2Label.Name = "IDRDR2Label";
            // 
            // IDRDR2TextBox
            // 
            resources.ApplyResources(this.IDRDR2TextBox, "IDRDR2TextBox");
            this.IDRDR2TextBox.Name = "IDRDR2TextBox";
            // 
            // SteamRDR2CheckBox
            // 
            resources.ApplyResources(this.SteamRDR2CheckBox, "SteamRDR2CheckBox");
            this.SteamRDR2CheckBox.Name = "SteamRDR2CheckBox";
            this.SteamRDR2CheckBox.UseVisualStyleBackColor = true;
            this.SteamRDR2CheckBox.CheckedChanged += new System.EventHandler(this.SteamRDR2CheckBox_CheckedChanged);
            // 
            // GTAVLocationGroupBox
            // 
            resources.ApplyResources(this.GTAVLocationGroupBox, "GTAVLocationGroupBox");
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVLocationSaveButton);
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVLocationDetectButton);
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVLocationSelectButton);
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVLocationTextBox);
            this.GTAVLocationGroupBox.Name = "GTAVLocationGroupBox";
            this.GTAVLocationGroupBox.TabStop = false;
            // 
            // GTAVLocationSaveButton
            // 
            resources.ApplyResources(this.GTAVLocationSaveButton, "GTAVLocationSaveButton");
            this.GTAVLocationSaveButton.Name = "GTAVLocationSaveButton";
            this.GTAVLocationSaveButton.UseVisualStyleBackColor = true;
            this.GTAVLocationSaveButton.Click += new System.EventHandler(this.GTAVLocationSaveButton_Click);
            // 
            // GTAVLocationDetectButton
            // 
            resources.ApplyResources(this.GTAVLocationDetectButton, "GTAVLocationDetectButton");
            this.GTAVLocationDetectButton.Name = "GTAVLocationDetectButton";
            this.GTAVLocationDetectButton.UseVisualStyleBackColor = true;
            this.GTAVLocationDetectButton.Click += new System.EventHandler(this.GTAVLocationDetectButton_Click);
            // 
            // GTAVLocationSelectButton
            // 
            resources.ApplyResources(this.GTAVLocationSelectButton, "GTAVLocationSelectButton");
            this.GTAVLocationSelectButton.Name = "GTAVLocationSelectButton";
            this.GTAVLocationSelectButton.UseVisualStyleBackColor = true;
            this.GTAVLocationSelectButton.Click += new System.EventHandler(this.GTAVLocationSelectButton_Click);
            // 
            // GTAVLocationTextBox
            // 
            resources.ApplyResources(this.GTAVLocationTextBox, "GTAVLocationTextBox");
            this.GTAVLocationTextBox.Name = "GTAVLocationTextBox";
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaunchToolStripMenuItem,
            this.AddToolStripMenuItem,
            this.RemoveToolStripMenuItem,
            this.RefreshToolStripMenuItem});
            resources.ApplyResources(this.TopMenuStrip, "TopMenuStrip");
            this.TopMenuStrip.Name = "TopMenuStrip";
            // 
            // LaunchToolStripMenuItem
            // 
            this.LaunchToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LaunchToolStripMenuItem.Image = global::PatchMyPath.Properties.Resources.Play;
            this.LaunchToolStripMenuItem.Name = "LaunchToolStripMenuItem";
            this.LaunchToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            resources.ApplyResources(this.LaunchToolStripMenuItem, "LaunchToolStripMenuItem");
            this.LaunchToolStripMenuItem.Click += new System.EventHandler(this.LaunchToolStripMenuItem_Click);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddToolStripMenuItem.Image = global::PatchMyPath.Properties.Resources.Add;
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            resources.ApplyResources(this.AddToolStripMenuItem, "AddToolStripMenuItem");
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveToolStripMenuItem.Image = global::PatchMyPath.Properties.Resources.Clear;
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            this.RemoveToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            resources.ApplyResources(this.RemoveToolStripMenuItem, "RemoveToolStripMenuItem");
            this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolStripMenuItem.Image = global::PatchMyPath.Properties.Resources.Refresh;
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            resources.ApplyResources(this.RefreshToolStripMenuItem, "RefreshToolStripMenuItem");
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // LanguageGroupBox
            // 
            resources.ApplyResources(this.LanguageGroupBox, "LanguageGroupBox");
            this.LanguageGroupBox.Controls.Add(this.LanguageComboBox);
            this.LanguageGroupBox.Name = "LanguageGroupBox";
            this.LanguageGroupBox.TabStop = false;
            // 
            // LanguageComboBox
            // 
            resources.ApplyResources(this.LanguageComboBox, "LanguageComboBox");
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_SelectedIndexChanged);
            // 
            // Home
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GeneralTabControl);
            this.Controls.Add(this.TopMenuStrip);
            this.MainMenuStrip = this.TopMenuStrip;
            this.Name = "Home";
            this.GeneralTabControl.ResumeLayout(false);
            this.InstallsTabPage.ResumeLayout(false);
            this.DuplicatorTabPage.ResumeLayout(false);
            this.OtherGroupBox.ResumeLayout(false);
            this.OtherGroupBox.PerformLayout();
            this.GameGroupBox.ResumeLayout(false);
            this.LinkTypeGroupBox.ResumeLayout(false);
            this.LinkTypeGroupBox.PerformLayout();
            this.OriginGroupBox.ResumeLayout(false);
            this.OriginGroupBox.PerformLayout();
            this.DestinationGroupBox.ResumeLayout(false);
            this.DestinationGroupBox.PerformLayout();
            this.SettingsTabPage.ResumeLayout(false);
            this.RDR2LocationGroupBox.ResumeLayout(false);
            this.RDR2LocationGroupBox.PerformLayout();
            this.SteamGroupBox.ResumeLayout(false);
            this.SteamGroupBox.PerformLayout();
            this.GTAVLocationGroupBox.ResumeLayout(false);
            this.GTAVLocationGroupBox.PerformLayout();
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            this.LanguageGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl GeneralTabControl;
        private System.Windows.Forms.TabPage InstallsTabPage;
        private System.Windows.Forms.TabPage DuplicatorTabPage;
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
        private System.Windows.Forms.CheckBox AutoAddCheckBox;
        private System.Windows.Forms.MenuStrip TopMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LaunchToolStripMenuItem;
        private System.Windows.Forms.TabPage SettingsTabPage;
        private System.Windows.Forms.GroupBox GTAVLocationGroupBox;
        private System.Windows.Forms.Button GTAVLocationSelectButton;
        private System.Windows.Forms.TextBox GTAVLocationTextBox;
        private System.Windows.Forms.Button GTAVLocationDetectButton;
        private System.Windows.Forms.Button GTAVLocationSaveButton;
        private System.Windows.Forms.GroupBox SteamGroupBox;
        private System.Windows.Forms.CheckBox SteamRDR2CheckBox;
        private System.Windows.Forms.Button SteamRDR2Button;
        private System.Windows.Forms.TextBox IDRDR2TextBox;
        private System.Windows.Forms.Label IDRDR2Label;
        private System.Windows.Forms.GroupBox GameGroupBox;
        private System.Windows.Forms.ComboBox GameComboBox;
        private System.Windows.Forms.GroupBox RDR2LocationGroupBox;
        private System.Windows.Forms.Button RDR2LocationSaveButton;
        private System.Windows.Forms.Button RDR2LocationDetectButton;
        private System.Windows.Forms.Button RDR2LocationSelectButton;
        private System.Windows.Forms.TextBox RDR2LocationTextBox;
        private System.Windows.Forms.CheckBox SteamGTAVCheckBox;
        private System.Windows.Forms.Label IDGTAVLabel;
        private System.Windows.Forms.TextBox IDGTAVTextBox;
        private System.Windows.Forms.Button SteamGTAVButton;
        private System.Windows.Forms.ProgressBar DuplicationProgressBar;
        private System.Windows.Forms.GroupBox OtherGroupBox;
        private System.Windows.Forms.GroupBox LanguageGroupBox;
        private System.Windows.Forms.ComboBox LanguageComboBox;
    }
}

