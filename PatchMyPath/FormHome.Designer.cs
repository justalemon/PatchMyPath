namespace PatchMyPath
{
    partial class FormHome
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.GeneralTabControl = new System.Windows.Forms.TabControl();
            this.InstallsTabPage = new System.Windows.Forms.TabPage();
            this.InstallsListBox = new System.Windows.Forms.ListBox();
            this.InstallContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StartAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExecutableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RGLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SteamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EGLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.LogTabPage = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.LicensesTabPage = new System.Windows.Forms.TabPage();
            this.LicensesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.LaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogStatusStrip = new System.Windows.Forms.StatusStrip();
            this.LogToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GeneralTabControl.SuspendLayout();
            this.InstallsTabPage.SuspendLayout();
            this.InstallContextMenuStrip.SuspendLayout();
            this.DuplicatorTabPage.SuspendLayout();
            this.OtherGroupBox.SuspendLayout();
            this.GameGroupBox.SuspendLayout();
            this.LinkTypeGroupBox.SuspendLayout();
            this.OriginGroupBox.SuspendLayout();
            this.DestinationGroupBox.SuspendLayout();
            this.LogTabPage.SuspendLayout();
            this.LicensesTabPage.SuspendLayout();
            this.TopMenuStrip.SuspendLayout();
            this.LogStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneralTabControl
            // 
            resources.ApplyResources(this.GeneralTabControl, "GeneralTabControl");
            this.GeneralTabControl.Controls.Add(this.InstallsTabPage);
            this.GeneralTabControl.Controls.Add(this.DuplicatorTabPage);
            this.GeneralTabControl.Controls.Add(this.LogTabPage);
            this.GeneralTabControl.Controls.Add(this.LicensesTabPage);
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
            this.InstallsListBox.ContextMenuStrip = this.InstallContextMenuStrip;
            resources.ApplyResources(this.InstallsListBox, "InstallsListBox");
            this.InstallsListBox.FormattingEnabled = true;
            this.InstallsListBox.Name = "InstallsListBox";
            this.InstallsListBox.SelectedIndexChanged += new System.EventHandler(this.InstallsListBox_SelectedIndexChanged);
            // 
            // InstallContextMenuStrip
            // 
            this.InstallContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartAsToolStripMenuItem});
            this.InstallContextMenuStrip.Name = "ContextMenuStrip";
            resources.ApplyResources(this.InstallContextMenuStrip, "InstallContextMenuStrip");
            this.InstallContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.InstallContextMenuStrip_Opening);
            // 
            // StartAsToolStripMenuItem
            // 
            this.StartAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExecutableToolStripMenuItem,
            this.RGLToolStripMenuItem,
            this.SteamToolStripMenuItem,
            this.EGLToolStripMenuItem});
            this.StartAsToolStripMenuItem.Name = "StartAsToolStripMenuItem";
            resources.ApplyResources(this.StartAsToolStripMenuItem, "StartAsToolStripMenuItem");
            // 
            // ExecutableToolStripMenuItem
            // 
            this.ExecutableToolStripMenuItem.Name = "ExecutableToolStripMenuItem";
            resources.ApplyResources(this.ExecutableToolStripMenuItem, "ExecutableToolStripMenuItem");
            this.ExecutableToolStripMenuItem.Click += new System.EventHandler(this.ExecutableToolStripMenuItem_Click);
            // 
            // RGLToolStripMenuItem
            // 
            this.RGLToolStripMenuItem.Name = "RGLToolStripMenuItem";
            resources.ApplyResources(this.RGLToolStripMenuItem, "RGLToolStripMenuItem");
            this.RGLToolStripMenuItem.Click += new System.EventHandler(this.RGLToolStripMenuItem_Click);
            // 
            // SteamToolStripMenuItem
            // 
            this.SteamToolStripMenuItem.Name = "SteamToolStripMenuItem";
            resources.ApplyResources(this.SteamToolStripMenuItem, "SteamToolStripMenuItem");
            this.SteamToolStripMenuItem.Click += new System.EventHandler(this.SteamToolStripMenuItem_Click);
            // 
            // EGLToolStripMenuItem
            // 
            this.EGLToolStripMenuItem.Name = "EGLToolStripMenuItem";
            resources.ApplyResources(this.EGLToolStripMenuItem, "EGLToolStripMenuItem");
            this.EGLToolStripMenuItem.Click += new System.EventHandler(this.EGLToolStripMenuItem_Click);
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
            // LogTabPage
            // 
            this.LogTabPage.Controls.Add(this.LogTextBox);
            resources.ApplyResources(this.LogTabPage, "LogTabPage");
            this.LogTabPage.Name = "LogTabPage";
            this.LogTabPage.UseVisualStyleBackColor = true;
            // 
            // LogTextBox
            // 
            resources.ApplyResources(this.LogTextBox, "LogTextBox");
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            // 
            // LicensesTabPage
            // 
            this.LicensesTabPage.Controls.Add(this.LicensesRichTextBox);
            resources.ApplyResources(this.LicensesTabPage, "LicensesTabPage");
            this.LicensesTabPage.Name = "LicensesTabPage";
            this.LicensesTabPage.UseVisualStyleBackColor = true;
            // 
            // LicensesRichTextBox
            // 
            this.LicensesRichTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.LicensesRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.LicensesRichTextBox, "LicensesRichTextBox");
            this.LicensesRichTextBox.Name = "LicensesRichTextBox";
            this.LicensesRichTextBox.ReadOnly = true;
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaunchToolStripMenuItem,
            this.AddToolStripMenuItem,
            this.RemoveToolStripMenuItem,
            this.RefreshToolStripMenuItem,
            this.SettingsToolStripMenuItem});
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
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SettingsToolStripMenuItem.Image = global::PatchMyPath.Properties.Resources.SettingsApplications;
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            resources.ApplyResources(this.SettingsToolStripMenuItem, "SettingsToolStripMenuItem");
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // LogStatusStrip
            // 
            this.LogStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LogToolStripStatusLabel});
            resources.ApplyResources(this.LogStatusStrip, "LogStatusStrip");
            this.LogStatusStrip.Name = "LogStatusStrip";
            // 
            // LogToolStripStatusLabel
            // 
            this.LogToolStripStatusLabel.Name = "LogToolStripStatusLabel";
            resources.ApplyResources(this.LogToolStripStatusLabel, "LogToolStripStatusLabel");
            // 
            // FormHome
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LogStatusStrip);
            this.Controls.Add(this.GeneralTabControl);
            this.Controls.Add(this.TopMenuStrip);
            this.MainMenuStrip = this.TopMenuStrip;
            this.Name = "FormHome";
            this.Load += new System.EventHandler(this.Home_Load);
            this.Shown += new System.EventHandler(this.Home_Shown);
            this.GeneralTabControl.ResumeLayout(false);
            this.InstallsTabPage.ResumeLayout(false);
            this.InstallContextMenuStrip.ResumeLayout(false);
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
            this.LogTabPage.ResumeLayout(false);
            this.LogTabPage.PerformLayout();
            this.LicensesTabPage.ResumeLayout(false);
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            this.LogStatusStrip.ResumeLayout(false);
            this.LogStatusStrip.PerformLayout();
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
        private System.Windows.Forms.GroupBox GameGroupBox;
        private System.Windows.Forms.ComboBox GameComboBox;
        private System.Windows.Forms.ProgressBar DuplicationProgressBar;
        private System.Windows.Forms.GroupBox OtherGroupBox;
        private System.Windows.Forms.TabPage LogTabPage;
        internal System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.TabPage LicensesTabPage;
        private System.Windows.Forms.RichTextBox LicensesRichTextBox;
        private System.Windows.Forms.StatusStrip LogStatusStrip;
        internal System.Windows.Forms.ToolStripStatusLabel LogToolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip InstallContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem StartAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExecutableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RGLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SteamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EGLToolStripMenuItem;
    }
}

