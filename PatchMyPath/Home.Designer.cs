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
            this.InstallsListBox = new System.Windows.Forms.ListBox();
            this.DuplicatorTabPage = new System.Windows.Forms.TabPage();
            this.GameGroupBox = new System.Windows.Forms.GroupBox();
            this.GameComboBox = new System.Windows.Forms.ComboBox();
            this.AutoAddGroupBox = new System.Windows.Forms.GroupBox();
            this.AutoAddCheckBox = new System.Windows.Forms.CheckBox();
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
            this.SteamGroupBox = new System.Windows.Forms.GroupBox();
            this.AppIdLabel = new System.Windows.Forms.Label();
            this.SteamSaveButton = new System.Windows.Forms.Button();
            this.AppIDTextBox = new System.Windows.Forms.TextBox();
            this.UseSteamCheckBox = new System.Windows.Forms.CheckBox();
            this.GTAVLocationGroupBox = new System.Windows.Forms.GroupBox();
            this.GTAVLocationSaveButton = new System.Windows.Forms.Button();
            this.GTAVLocationDetectButton = new System.Windows.Forms.Button();
            this.GTAVLocationSelectButton = new System.Windows.Forms.Button();
            this.GTAVLocationTextBox = new System.Windows.Forms.TextBox();
            this.LoggingTabPage = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.LaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeneralTabControl.SuspendLayout();
            this.InstallsTabPage.SuspendLayout();
            this.DuplicatorTabPage.SuspendLayout();
            this.GameGroupBox.SuspendLayout();
            this.AutoAddGroupBox.SuspendLayout();
            this.LinkTypeGroupBox.SuspendLayout();
            this.OriginGroupBox.SuspendLayout();
            this.DestinationGroupBox.SuspendLayout();
            this.SettingsTabPage.SuspendLayout();
            this.SteamGroupBox.SuspendLayout();
            this.GTAVLocationGroupBox.SuspendLayout();
            this.LoggingTabPage.SuspendLayout();
            this.TopMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneralTabControl
            // 
            this.GeneralTabControl.Controls.Add(this.InstallsTabPage);
            this.GeneralTabControl.Controls.Add(this.DuplicatorTabPage);
            this.GeneralTabControl.Controls.Add(this.SettingsTabPage);
            this.GeneralTabControl.Controls.Add(this.LoggingTabPage);
            this.GeneralTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralTabControl.Location = new System.Drawing.Point(0, 37);
            this.GeneralTabControl.Name = "GeneralTabControl";
            this.GeneralTabControl.SelectedIndex = 0;
            this.GeneralTabControl.Size = new System.Drawing.Size(484, 374);
            this.GeneralTabControl.TabIndex = 0;
            // 
            // InstallsTabPage
            // 
            this.InstallsTabPage.Controls.Add(this.InstallsListBox);
            this.InstallsTabPage.Location = new System.Drawing.Point(4, 22);
            this.InstallsTabPage.Name = "InstallsTabPage";
            this.InstallsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.InstallsTabPage.Size = new System.Drawing.Size(476, 348);
            this.InstallsTabPage.TabIndex = 0;
            this.InstallsTabPage.Text = "Game Installs";
            this.InstallsTabPage.UseVisualStyleBackColor = true;
            // 
            // InstallsListBox
            // 
            this.InstallsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstallsListBox.FormattingEnabled = true;
            this.InstallsListBox.Location = new System.Drawing.Point(3, 3);
            this.InstallsListBox.Name = "InstallsListBox";
            this.InstallsListBox.Size = new System.Drawing.Size(470, 342);
            this.InstallsListBox.TabIndex = 0;
            this.InstallsListBox.SelectedIndexChanged += new System.EventHandler(this.InstallsListBox_SelectedIndexChanged);
            // 
            // DuplicatorTabPage
            // 
            this.DuplicatorTabPage.Controls.Add(this.GameGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.AutoAddGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.LinkTypeGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.DuplicateButton);
            this.DuplicatorTabPage.Controls.Add(this.OriginGroupBox);
            this.DuplicatorTabPage.Controls.Add(this.DestinationGroupBox);
            this.DuplicatorTabPage.Location = new System.Drawing.Point(4, 22);
            this.DuplicatorTabPage.Name = "DuplicatorTabPage";
            this.DuplicatorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DuplicatorTabPage.Size = new System.Drawing.Size(476, 348);
            this.DuplicatorTabPage.TabIndex = 1;
            this.DuplicatorTabPage.Text = "Duplicator Tool";
            this.DuplicatorTabPage.UseVisualStyleBackColor = true;
            // 
            // GameGroupBox
            // 
            this.GameGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameGroupBox.Controls.Add(this.GameComboBox);
            this.GameGroupBox.Location = new System.Drawing.Point(8, 6);
            this.GameGroupBox.Name = "GameGroupBox";
            this.GameGroupBox.Size = new System.Drawing.Size(462, 52);
            this.GameGroupBox.TabIndex = 7;
            this.GameGroupBox.TabStop = false;
            this.GameGroupBox.Text = "Game";
            // 
            // GameComboBox
            // 
            this.GameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameComboBox.FormattingEnabled = true;
            this.GameComboBox.Location = new System.Drawing.Point(6, 19);
            this.GameComboBox.Name = "GameComboBox";
            this.GameComboBox.Size = new System.Drawing.Size(450, 21);
            this.GameComboBox.TabIndex = 0;
            // 
            // AutoAddGroupBox
            // 
            this.AutoAddGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoAddGroupBox.Controls.Add(this.AutoAddCheckBox);
            this.AutoAddGroupBox.Location = new System.Drawing.Point(6, 237);
            this.AutoAddGroupBox.Name = "AutoAddGroupBox";
            this.AutoAddGroupBox.Size = new System.Drawing.Size(464, 42);
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
            // LinkTypeGroupBox
            // 
            this.LinkTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkTypeGroupBox.Controls.Add(this.HardRadioButton);
            this.LinkTypeGroupBox.Controls.Add(this.SymbolicRadioButton);
            this.LinkTypeGroupBox.Location = new System.Drawing.Point(6, 166);
            this.LinkTypeGroupBox.Name = "LinkTypeGroupBox";
            this.LinkTypeGroupBox.Size = new System.Drawing.Size(464, 65);
            this.LinkTypeGroupBox.TabIndex = 5;
            this.LinkTypeGroupBox.TabStop = false;
            this.LinkTypeGroupBox.Text = "Link Type";
            // 
            // HardRadioButton
            // 
            this.HardRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.SymbolicRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SymbolicRadioButton.AutoSize = true;
            this.SymbolicRadioButton.Location = new System.Drawing.Point(6, 42);
            this.SymbolicRadioButton.Name = "SymbolicRadioButton";
            this.SymbolicRadioButton.Size = new System.Drawing.Size(422, 17);
            this.SymbolicRadioButton.TabIndex = 0;
            this.SymbolicRadioButton.Text = "Symbolic Links for Files and Folders (Steam and pre Rockstar Games Launcher only)" +
    "";
            this.SymbolicRadioButton.UseVisualStyleBackColor = true;
            // 
            // DuplicateButton
            // 
            this.DuplicateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DuplicateButton.Location = new System.Drawing.Point(6, 317);
            this.DuplicateButton.Name = "DuplicateButton";
            this.DuplicateButton.Size = new System.Drawing.Size(464, 23);
            this.DuplicateButton.TabIndex = 2;
            this.DuplicateButton.Text = "Duplicate Game Folder";
            this.DuplicateButton.UseVisualStyleBackColor = true;
            this.DuplicateButton.Click += new System.EventHandler(this.DuplicateButton_Click);
            // 
            // OriginGroupBox
            // 
            this.OriginGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginGroupBox.Controls.Add(this.OriginSelectButton);
            this.OriginGroupBox.Controls.Add(this.OriginTextBox);
            this.OriginGroupBox.Location = new System.Drawing.Point(6, 64);
            this.OriginGroupBox.Name = "OriginGroupBox";
            this.OriginGroupBox.Size = new System.Drawing.Size(464, 45);
            this.OriginGroupBox.TabIndex = 0;
            this.OriginGroupBox.TabStop = false;
            this.OriginGroupBox.Text = "Origin";
            // 
            // OriginSelectButton
            // 
            this.OriginSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OriginSelectButton.Location = new System.Drawing.Point(383, 17);
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
            this.OriginTextBox.Size = new System.Drawing.Size(371, 20);
            this.OriginTextBox.TabIndex = 0;
            // 
            // DestinationGroupBox
            // 
            this.DestinationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationGroupBox.Controls.Add(this.DestinationSelectButton);
            this.DestinationGroupBox.Controls.Add(this.DestinationTextBox);
            this.DestinationGroupBox.Location = new System.Drawing.Point(6, 115);
            this.DestinationGroupBox.Name = "DestinationGroupBox";
            this.DestinationGroupBox.Size = new System.Drawing.Size(464, 45);
            this.DestinationGroupBox.TabIndex = 1;
            this.DestinationGroupBox.TabStop = false;
            this.DestinationGroupBox.Text = "Destination";
            // 
            // DestinationSelectButton
            // 
            this.DestinationSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationSelectButton.Location = new System.Drawing.Point(383, 17);
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
            this.DestinationTextBox.Size = new System.Drawing.Size(371, 20);
            this.DestinationTextBox.TabIndex = 0;
            // 
            // SettingsTabPage
            // 
            this.SettingsTabPage.Controls.Add(this.SteamGroupBox);
            this.SettingsTabPage.Controls.Add(this.GTAVLocationGroupBox);
            this.SettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTabPage.Size = new System.Drawing.Size(476, 348);
            this.SettingsTabPage.TabIndex = 2;
            this.SettingsTabPage.Text = "Settings";
            this.SettingsTabPage.UseVisualStyleBackColor = true;
            // 
            // SteamGroupBox
            // 
            this.SteamGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SteamGroupBox.Controls.Add(this.AppIdLabel);
            this.SteamGroupBox.Controls.Add(this.SteamSaveButton);
            this.SteamGroupBox.Controls.Add(this.AppIDTextBox);
            this.SteamGroupBox.Controls.Add(this.UseSteamCheckBox);
            this.SteamGroupBox.Location = new System.Drawing.Point(8, 86);
            this.SteamGroupBox.Name = "SteamGroupBox";
            this.SteamGroupBox.Size = new System.Drawing.Size(462, 74);
            this.SteamGroupBox.TabIndex = 2;
            this.SteamGroupBox.TabStop = false;
            this.SteamGroupBox.Text = "Steam";
            // 
            // AppIdLabel
            // 
            this.AppIdLabel.AutoSize = true;
            this.AppIdLabel.Location = new System.Drawing.Point(6, 45);
            this.AppIdLabel.Name = "AppIdLabel";
            this.AppIdLabel.Size = new System.Drawing.Size(40, 13);
            this.AppIdLabel.TabIndex = 3;
            this.AppIdLabel.Text = "App ID";
            // 
            // SteamSaveButton
            // 
            this.SteamSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SteamSaveButton.Location = new System.Drawing.Point(381, 40);
            this.SteamSaveButton.Name = "SteamSaveButton";
            this.SteamSaveButton.Size = new System.Drawing.Size(75, 23);
            this.SteamSaveButton.TabIndex = 2;
            this.SteamSaveButton.Text = "Save";
            this.SteamSaveButton.UseVisualStyleBackColor = true;
            // 
            // AppIDTextBox
            // 
            this.AppIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppIDTextBox.Location = new System.Drawing.Point(52, 42);
            this.AppIDTextBox.Name = "AppIDTextBox";
            this.AppIDTextBox.Size = new System.Drawing.Size(323, 20);
            this.AppIDTextBox.TabIndex = 1;
            // 
            // UseSteamCheckBox
            // 
            this.UseSteamCheckBox.AutoSize = true;
            this.UseSteamCheckBox.Location = new System.Drawing.Point(6, 19);
            this.UseSteamCheckBox.Name = "UseSteamCheckBox";
            this.UseSteamCheckBox.Size = new System.Drawing.Size(306, 17);
            this.UseSteamCheckBox.TabIndex = 0;
            this.UseSteamCheckBox.Text = "Use Steam to launch the game (Disables Launcher Bypass)";
            this.UseSteamCheckBox.UseVisualStyleBackColor = true;
            // 
            // GTAVLocationGroupBox
            // 
            this.GTAVLocationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVLocationSaveButton);
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVLocationDetectButton);
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVLocationSelectButton);
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVLocationTextBox);
            this.GTAVLocationGroupBox.Location = new System.Drawing.Point(6, 6);
            this.GTAVLocationGroupBox.Name = "GTAVLocationGroupBox";
            this.GTAVLocationGroupBox.Size = new System.Drawing.Size(464, 74);
            this.GTAVLocationGroupBox.TabIndex = 1;
            this.GTAVLocationGroupBox.TabStop = false;
            this.GTAVLocationGroupBox.Text = "Grand Theft Auto V Location";
            // 
            // GTAVLocationSaveButton
            // 
            this.GTAVLocationSaveButton.Location = new System.Drawing.Point(168, 45);
            this.GTAVLocationSaveButton.Name = "GTAVLocationSaveButton";
            this.GTAVLocationSaveButton.Size = new System.Drawing.Size(75, 23);
            this.GTAVLocationSaveButton.TabIndex = 3;
            this.GTAVLocationSaveButton.Text = "Save";
            this.GTAVLocationSaveButton.UseVisualStyleBackColor = true;
            this.GTAVLocationSaveButton.Click += new System.EventHandler(this.GTAVLocationSaveButton_Click);
            // 
            // GTAVLocationDetectButton
            // 
            this.GTAVLocationDetectButton.Location = new System.Drawing.Point(87, 45);
            this.GTAVLocationDetectButton.Name = "GTAVLocationDetectButton";
            this.GTAVLocationDetectButton.Size = new System.Drawing.Size(75, 23);
            this.GTAVLocationDetectButton.TabIndex = 2;
            this.GTAVLocationDetectButton.Text = "Detect";
            this.GTAVLocationDetectButton.UseVisualStyleBackColor = true;
            this.GTAVLocationDetectButton.Click += new System.EventHandler(this.GTAVLocationDetectButton_Click);
            // 
            // GTAVLocationSelectButton
            // 
            this.GTAVLocationSelectButton.Location = new System.Drawing.Point(6, 45);
            this.GTAVLocationSelectButton.Name = "GTAVLocationSelectButton";
            this.GTAVLocationSelectButton.Size = new System.Drawing.Size(75, 23);
            this.GTAVLocationSelectButton.TabIndex = 1;
            this.GTAVLocationSelectButton.Text = "Select";
            this.GTAVLocationSelectButton.UseVisualStyleBackColor = true;
            this.GTAVLocationSelectButton.Click += new System.EventHandler(this.GTAVLocationSelectButton_Click);
            // 
            // GTAVLocationTextBox
            // 
            this.GTAVLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GTAVLocationTextBox.Location = new System.Drawing.Point(6, 19);
            this.GTAVLocationTextBox.Name = "GTAVLocationTextBox";
            this.GTAVLocationTextBox.Size = new System.Drawing.Size(452, 20);
            this.GTAVLocationTextBox.TabIndex = 0;
            // 
            // LoggingTabPage
            // 
            this.LoggingTabPage.Controls.Add(this.LogTextBox);
            this.LoggingTabPage.Location = new System.Drawing.Point(4, 22);
            this.LoggingTabPage.Name = "LoggingTabPage";
            this.LoggingTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LoggingTabPage.Size = new System.Drawing.Size(476, 348);
            this.LoggingTabPage.TabIndex = 3;
            this.LoggingTabPage.Text = "Logging";
            this.LoggingTabPage.UseVisualStyleBackColor = true;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Location = new System.Drawing.Point(3, 3);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LogTextBox.Size = new System.Drawing.Size(470, 342);
            this.LogTextBox.TabIndex = 0;
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaunchToolStripMenuItem,
            this.AddToolStripMenuItem,
            this.RemoveToolStripMenuItem,
            this.RefreshToolStripMenuItem});
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Size = new System.Drawing.Size(484, 37);
            this.TopMenuStrip.TabIndex = 1;
            // 
            // LaunchToolStripMenuItem
            // 
            this.LaunchToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LaunchToolStripMenuItem.Image = global::PatchMyPath.Properties.Resources.Start;
            this.LaunchToolStripMenuItem.Name = "LaunchToolStripMenuItem";
            this.LaunchToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.LaunchToolStripMenuItem.Size = new System.Drawing.Size(33, 33);
            this.LaunchToolStripMenuItem.Text = "Launch";
            this.LaunchToolStripMenuItem.Click += new System.EventHandler(this.LaunchToolStripMenuItem_Click);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddToolStripMenuItem.Image = global::PatchMyPath.Properties.Resources.Add;
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(33, 33);
            this.AddToolStripMenuItem.Text = "Add";
            this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
            // 
            // RemoveToolStripMenuItem
            // 
            this.RemoveToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveToolStripMenuItem.Image = global::PatchMyPath.Properties.Resources.Remove;
            this.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem";
            this.RemoveToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.RemoveToolStripMenuItem.Size = new System.Drawing.Size(33, 33);
            this.RemoveToolStripMenuItem.Text = "Remove";
            this.RemoveToolStripMenuItem.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolStripMenuItem.Image = global::PatchMyPath.Properties.Resources.Refresh;
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2);
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(33, 33);
            this.RefreshToolStripMenuItem.Text = "Refresh";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 411);
            this.Controls.Add(this.GeneralTabControl);
            this.Controls.Add(this.TopMenuStrip);
            this.MainMenuStrip = this.TopMenuStrip;
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PatchMyPath";
            this.GeneralTabControl.ResumeLayout(false);
            this.InstallsTabPage.ResumeLayout(false);
            this.DuplicatorTabPage.ResumeLayout(false);
            this.GameGroupBox.ResumeLayout(false);
            this.AutoAddGroupBox.ResumeLayout(false);
            this.AutoAddGroupBox.PerformLayout();
            this.LinkTypeGroupBox.ResumeLayout(false);
            this.LinkTypeGroupBox.PerformLayout();
            this.OriginGroupBox.ResumeLayout(false);
            this.OriginGroupBox.PerformLayout();
            this.DestinationGroupBox.ResumeLayout(false);
            this.DestinationGroupBox.PerformLayout();
            this.SettingsTabPage.ResumeLayout(false);
            this.SteamGroupBox.ResumeLayout(false);
            this.SteamGroupBox.PerformLayout();
            this.GTAVLocationGroupBox.ResumeLayout(false);
            this.GTAVLocationGroupBox.PerformLayout();
            this.LoggingTabPage.ResumeLayout(false);
            this.LoggingTabPage.PerformLayout();
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
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
        private System.Windows.Forms.GroupBox AutoAddGroupBox;
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
        private System.Windows.Forms.CheckBox UseSteamCheckBox;
        private System.Windows.Forms.Button SteamSaveButton;
        private System.Windows.Forms.TextBox AppIDTextBox;
        private System.Windows.Forms.Label AppIdLabel;
        private System.Windows.Forms.TabPage LoggingTabPage;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.GroupBox GameGroupBox;
        private System.Windows.Forms.ComboBox GameComboBox;
    }
}

