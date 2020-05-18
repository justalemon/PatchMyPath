namespace PatchMyPath
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.ConfigTabControl = new System.Windows.Forms.TabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.OtherGroupBox = new System.Windows.Forms.GroupBox();
            this.DownloadListsButton = new System.Windows.Forms.Button();
            this.LanguageGroupBox = new System.Windows.Forms.GroupBox();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.RDR2TabPage = new System.Windows.Forms.TabPage();
            this.RDR2LauncherGroupBox = new System.Windows.Forms.GroupBox();
            this.RDR2LauncherSaveButton = new System.Windows.Forms.Button();
            this.RDR2IDTextBox = new System.Windows.Forms.TextBox();
            this.RDR2LauncherComboBox = new System.Windows.Forms.ComboBox();
            this.RDR2LocationGroupBox = new System.Windows.Forms.GroupBox();
            this.RDR2LocationSaveButton = new System.Windows.Forms.Button();
            this.RDR2DetectButton = new System.Windows.Forms.Button();
            this.RDR2SelectButton = new System.Windows.Forms.Button();
            this.RDR2LocationTextBox = new System.Windows.Forms.TextBox();
            this.GTAVTabPage = new System.Windows.Forms.TabPage();
            this.GTAVLauncherGroupBox = new System.Windows.Forms.GroupBox();
            this.GTAVLauncherSaveButton = new System.Windows.Forms.Button();
            this.GTAVIDTextBox = new System.Windows.Forms.TextBox();
            this.GTAVLauncherComboBox = new System.Windows.Forms.ComboBox();
            this.GTAVLocationGroupBox = new System.Windows.Forms.GroupBox();
            this.GTAVSaveButton = new System.Windows.Forms.Button();
            this.GTAVDetectButton = new System.Windows.Forms.Button();
            this.GTAVSelectButton = new System.Windows.Forms.Button();
            this.GTAVLocationTextBox = new System.Windows.Forms.TextBox();
            this.GTAIVTabPage = new System.Windows.Forms.TabPage();
            this.GTAIVLauncherGroupBox = new System.Windows.Forms.GroupBox();
            this.GTAIVLauncherSaveButton = new System.Windows.Forms.Button();
            this.GTAIVIDTextBox = new System.Windows.Forms.TextBox();
            this.GTAIVLauncherComboBox = new System.Windows.Forms.ComboBox();
            this.GTAIVLocationGroupBox = new System.Windows.Forms.GroupBox();
            this.GTAIVSaveButton = new System.Windows.Forms.Button();
            this.GTAIVDetectButton = new System.Windows.Forms.Button();
            this.GTAIVSelectButton = new System.Windows.Forms.Button();
            this.GTAIVLocationTextBox = new System.Windows.Forms.TextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.ConfigTabControl.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            this.OtherGroupBox.SuspendLayout();
            this.LanguageGroupBox.SuspendLayout();
            this.RDR2TabPage.SuspendLayout();
            this.RDR2LauncherGroupBox.SuspendLayout();
            this.RDR2LocationGroupBox.SuspendLayout();
            this.GTAVTabPage.SuspendLayout();
            this.GTAVLauncherGroupBox.SuspendLayout();
            this.GTAVLocationGroupBox.SuspendLayout();
            this.GTAIVTabPage.SuspendLayout();
            this.GTAIVLauncherGroupBox.SuspendLayout();
            this.GTAIVLocationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigTabControl
            // 
            this.ConfigTabControl.Controls.Add(this.GeneralTabPage);
            this.ConfigTabControl.Controls.Add(this.RDR2TabPage);
            this.ConfigTabControl.Controls.Add(this.GTAVTabPage);
            this.ConfigTabControl.Controls.Add(this.GTAIVTabPage);
            resources.ApplyResources(this.ConfigTabControl, "ConfigTabControl");
            this.ConfigTabControl.Name = "ConfigTabControl";
            this.ConfigTabControl.SelectedIndex = 0;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Controls.Add(this.OtherGroupBox);
            this.GeneralTabPage.Controls.Add(this.LanguageGroupBox);
            resources.ApplyResources(this.GeneralTabPage, "GeneralTabPage");
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // OtherGroupBox
            // 
            resources.ApplyResources(this.OtherGroupBox, "OtherGroupBox");
            this.OtherGroupBox.Controls.Add(this.DownloadListsButton);
            this.OtherGroupBox.Name = "OtherGroupBox";
            this.OtherGroupBox.TabStop = false;
            // 
            // DownloadListsButton
            // 
            resources.ApplyResources(this.DownloadListsButton, "DownloadListsButton");
            this.DownloadListsButton.Name = "DownloadListsButton";
            this.DownloadListsButton.UseVisualStyleBackColor = true;
            this.DownloadListsButton.Click += new System.EventHandler(this.DownloadListsButton_Click);
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
            // RDR2TabPage
            // 
            this.RDR2TabPage.Controls.Add(this.RDR2LauncherGroupBox);
            this.RDR2TabPage.Controls.Add(this.RDR2LocationGroupBox);
            resources.ApplyResources(this.RDR2TabPage, "RDR2TabPage");
            this.RDR2TabPage.Name = "RDR2TabPage";
            this.RDR2TabPage.UseVisualStyleBackColor = true;
            // 
            // RDR2LauncherGroupBox
            // 
            resources.ApplyResources(this.RDR2LauncherGroupBox, "RDR2LauncherGroupBox");
            this.RDR2LauncherGroupBox.Controls.Add(this.RDR2LauncherSaveButton);
            this.RDR2LauncherGroupBox.Controls.Add(this.RDR2IDTextBox);
            this.RDR2LauncherGroupBox.Controls.Add(this.RDR2LauncherComboBox);
            this.RDR2LauncherGroupBox.Name = "RDR2LauncherGroupBox";
            this.RDR2LauncherGroupBox.TabStop = false;
            // 
            // RDR2LauncherSaveButton
            // 
            resources.ApplyResources(this.RDR2LauncherSaveButton, "RDR2LauncherSaveButton");
            this.RDR2LauncherSaveButton.Name = "RDR2LauncherSaveButton";
            this.RDR2LauncherSaveButton.UseVisualStyleBackColor = true;
            this.RDR2LauncherSaveButton.Click += new System.EventHandler(this.RDR2LauncherSaveButton_Click);
            // 
            // RDR2IDTextBox
            // 
            resources.ApplyResources(this.RDR2IDTextBox, "RDR2IDTextBox");
            this.RDR2IDTextBox.Name = "RDR2IDTextBox";
            // 
            // RDR2LauncherComboBox
            // 
            this.RDR2LauncherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RDR2LauncherComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.RDR2LauncherComboBox, "RDR2LauncherComboBox");
            this.RDR2LauncherComboBox.Name = "RDR2LauncherComboBox";
            this.RDR2LauncherComboBox.SelectedIndexChanged += new System.EventHandler(this.RDR2LauncherComboBox_SelectedIndexChanged);
            // 
            // RDR2LocationGroupBox
            // 
            resources.ApplyResources(this.RDR2LocationGroupBox, "RDR2LocationGroupBox");
            this.RDR2LocationGroupBox.Controls.Add(this.RDR2LocationSaveButton);
            this.RDR2LocationGroupBox.Controls.Add(this.RDR2DetectButton);
            this.RDR2LocationGroupBox.Controls.Add(this.RDR2SelectButton);
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
            // RDR2DetectButton
            // 
            resources.ApplyResources(this.RDR2DetectButton, "RDR2DetectButton");
            this.RDR2DetectButton.Name = "RDR2DetectButton";
            this.RDR2DetectButton.UseVisualStyleBackColor = true;
            this.RDR2DetectButton.Click += new System.EventHandler(this.RDR2DetectButton_Click);
            // 
            // RDR2SelectButton
            // 
            resources.ApplyResources(this.RDR2SelectButton, "RDR2SelectButton");
            this.RDR2SelectButton.Name = "RDR2SelectButton";
            this.RDR2SelectButton.UseVisualStyleBackColor = true;
            this.RDR2SelectButton.Click += new System.EventHandler(this.RDR2SelectButton_Click);
            // 
            // RDR2LocationTextBox
            // 
            resources.ApplyResources(this.RDR2LocationTextBox, "RDR2LocationTextBox");
            this.RDR2LocationTextBox.Name = "RDR2LocationTextBox";
            // 
            // GTAVTabPage
            // 
            this.GTAVTabPage.Controls.Add(this.GTAVLauncherGroupBox);
            this.GTAVTabPage.Controls.Add(this.GTAVLocationGroupBox);
            resources.ApplyResources(this.GTAVTabPage, "GTAVTabPage");
            this.GTAVTabPage.Name = "GTAVTabPage";
            this.GTAVTabPage.UseVisualStyleBackColor = true;
            // 
            // GTAVLauncherGroupBox
            // 
            resources.ApplyResources(this.GTAVLauncherGroupBox, "GTAVLauncherGroupBox");
            this.GTAVLauncherGroupBox.Controls.Add(this.GTAVLauncherSaveButton);
            this.GTAVLauncherGroupBox.Controls.Add(this.GTAVIDTextBox);
            this.GTAVLauncherGroupBox.Controls.Add(this.GTAVLauncherComboBox);
            this.GTAVLauncherGroupBox.Name = "GTAVLauncherGroupBox";
            this.GTAVLauncherGroupBox.TabStop = false;
            // 
            // GTAVLauncherSaveButton
            // 
            resources.ApplyResources(this.GTAVLauncherSaveButton, "GTAVLauncherSaveButton");
            this.GTAVLauncherSaveButton.Name = "GTAVLauncherSaveButton";
            this.GTAVLauncherSaveButton.UseVisualStyleBackColor = true;
            this.GTAVLauncherSaveButton.Click += new System.EventHandler(this.GTAVLauncherSaveButton_Click);
            // 
            // GTAVIDTextBox
            // 
            resources.ApplyResources(this.GTAVIDTextBox, "GTAVIDTextBox");
            this.GTAVIDTextBox.Name = "GTAVIDTextBox";
            // 
            // GTAVLauncherComboBox
            // 
            this.GTAVLauncherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GTAVLauncherComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.GTAVLauncherComboBox, "GTAVLauncherComboBox");
            this.GTAVLauncherComboBox.Name = "GTAVLauncherComboBox";
            this.GTAVLauncherComboBox.SelectedIndexChanged += new System.EventHandler(this.GTAVLauncherComboBox_SelectedIndexChanged);
            // 
            // GTAVLocationGroupBox
            // 
            resources.ApplyResources(this.GTAVLocationGroupBox, "GTAVLocationGroupBox");
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVSaveButton);
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVDetectButton);
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVSelectButton);
            this.GTAVLocationGroupBox.Controls.Add(this.GTAVLocationTextBox);
            this.GTAVLocationGroupBox.Name = "GTAVLocationGroupBox";
            this.GTAVLocationGroupBox.TabStop = false;
            // 
            // GTAVSaveButton
            // 
            resources.ApplyResources(this.GTAVSaveButton, "GTAVSaveButton");
            this.GTAVSaveButton.Name = "GTAVSaveButton";
            this.GTAVSaveButton.UseVisualStyleBackColor = true;
            this.GTAVSaveButton.Click += new System.EventHandler(this.GTAVSaveButton_Click);
            // 
            // GTAVDetectButton
            // 
            resources.ApplyResources(this.GTAVDetectButton, "GTAVDetectButton");
            this.GTAVDetectButton.Name = "GTAVDetectButton";
            this.GTAVDetectButton.UseVisualStyleBackColor = true;
            this.GTAVDetectButton.Click += new System.EventHandler(this.GTAVDetectButton_Click);
            // 
            // GTAVSelectButton
            // 
            resources.ApplyResources(this.GTAVSelectButton, "GTAVSelectButton");
            this.GTAVSelectButton.Name = "GTAVSelectButton";
            this.GTAVSelectButton.UseVisualStyleBackColor = true;
            this.GTAVSelectButton.Click += new System.EventHandler(this.GTAVSelectButton_Click);
            // 
            // GTAVLocationTextBox
            // 
            resources.ApplyResources(this.GTAVLocationTextBox, "GTAVLocationTextBox");
            this.GTAVLocationTextBox.Name = "GTAVLocationTextBox";
            // 
            // GTAIVTabPage
            // 
            this.GTAIVTabPage.Controls.Add(this.GTAIVLauncherGroupBox);
            this.GTAIVTabPage.Controls.Add(this.GTAIVLocationGroupBox);
            resources.ApplyResources(this.GTAIVTabPage, "GTAIVTabPage");
            this.GTAIVTabPage.Name = "GTAIVTabPage";
            this.GTAIVTabPage.UseVisualStyleBackColor = true;
            // 
            // GTAIVLauncherGroupBox
            // 
            resources.ApplyResources(this.GTAIVLauncherGroupBox, "GTAIVLauncherGroupBox");
            this.GTAIVLauncherGroupBox.Controls.Add(this.GTAIVLauncherSaveButton);
            this.GTAIVLauncherGroupBox.Controls.Add(this.GTAIVIDTextBox);
            this.GTAIVLauncherGroupBox.Controls.Add(this.GTAIVLauncherComboBox);
            this.GTAIVLauncherGroupBox.Name = "GTAIVLauncherGroupBox";
            this.GTAIVLauncherGroupBox.TabStop = false;
            // 
            // GTAIVLauncherSaveButton
            // 
            resources.ApplyResources(this.GTAIVLauncherSaveButton, "GTAIVLauncherSaveButton");
            this.GTAIVLauncherSaveButton.Name = "GTAIVLauncherSaveButton";
            this.GTAIVLauncherSaveButton.UseVisualStyleBackColor = true;
            this.GTAIVLauncherSaveButton.Click += new System.EventHandler(this.GTAIVLauncherSaveButton_Click);
            // 
            // GTAIVIDTextBox
            // 
            resources.ApplyResources(this.GTAIVIDTextBox, "GTAIVIDTextBox");
            this.GTAIVIDTextBox.Name = "GTAIVIDTextBox";
            // 
            // GTAIVLauncherComboBox
            // 
            this.GTAIVLauncherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GTAIVLauncherComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.GTAIVLauncherComboBox, "GTAIVLauncherComboBox");
            this.GTAIVLauncherComboBox.Name = "GTAIVLauncherComboBox";
            this.GTAIVLauncherComboBox.SelectedIndexChanged += new System.EventHandler(this.GTAIVLauncherComboBox_SelectedIndexChanged);
            // 
            // GTAIVLocationGroupBox
            // 
            resources.ApplyResources(this.GTAIVLocationGroupBox, "GTAIVLocationGroupBox");
            this.GTAIVLocationGroupBox.Controls.Add(this.GTAIVSaveButton);
            this.GTAIVLocationGroupBox.Controls.Add(this.GTAIVDetectButton);
            this.GTAIVLocationGroupBox.Controls.Add(this.GTAIVSelectButton);
            this.GTAIVLocationGroupBox.Controls.Add(this.GTAIVLocationTextBox);
            this.GTAIVLocationGroupBox.Name = "GTAIVLocationGroupBox";
            this.GTAIVLocationGroupBox.TabStop = false;
            // 
            // GTAIVSaveButton
            // 
            resources.ApplyResources(this.GTAIVSaveButton, "GTAIVSaveButton");
            this.GTAIVSaveButton.Name = "GTAIVSaveButton";
            this.GTAIVSaveButton.UseVisualStyleBackColor = true;
            this.GTAIVSaveButton.Click += new System.EventHandler(this.GTAIVSaveButton_Click);
            // 
            // GTAIVDetectButton
            // 
            resources.ApplyResources(this.GTAIVDetectButton, "GTAIVDetectButton");
            this.GTAIVDetectButton.Name = "GTAIVDetectButton";
            this.GTAIVDetectButton.UseVisualStyleBackColor = true;
            this.GTAIVDetectButton.Click += new System.EventHandler(this.GTAIVDetectButton_Click);
            // 
            // GTAIVSelectButton
            // 
            resources.ApplyResources(this.GTAIVSelectButton, "GTAIVSelectButton");
            this.GTAIVSelectButton.Name = "GTAIVSelectButton";
            this.GTAIVSelectButton.UseVisualStyleBackColor = true;
            this.GTAIVSelectButton.Click += new System.EventHandler(this.GTAIVSelectButton_Click);
            // 
            // GTAIVLocationTextBox
            // 
            resources.ApplyResources(this.GTAIVLocationTextBox, "GTAIVLocationTextBox");
            this.GTAIVLocationTextBox.Name = "GTAIVLocationTextBox";
            // 
            // FormConfig
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConfigTabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfig";
            this.ConfigTabControl.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.OtherGroupBox.ResumeLayout(false);
            this.LanguageGroupBox.ResumeLayout(false);
            this.RDR2TabPage.ResumeLayout(false);
            this.RDR2LauncherGroupBox.ResumeLayout(false);
            this.RDR2LauncherGroupBox.PerformLayout();
            this.RDR2LocationGroupBox.ResumeLayout(false);
            this.RDR2LocationGroupBox.PerformLayout();
            this.GTAVTabPage.ResumeLayout(false);
            this.GTAVLauncherGroupBox.ResumeLayout(false);
            this.GTAVLauncherGroupBox.PerformLayout();
            this.GTAVLocationGroupBox.ResumeLayout(false);
            this.GTAVLocationGroupBox.PerformLayout();
            this.GTAIVTabPage.ResumeLayout(false);
            this.GTAIVLauncherGroupBox.ResumeLayout(false);
            this.GTAIVLauncherGroupBox.PerformLayout();
            this.GTAIVLocationGroupBox.ResumeLayout(false);
            this.GTAIVLocationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ConfigTabControl;
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.TabPage RDR2TabPage;
        private System.Windows.Forms.GroupBox LanguageGroupBox;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.GroupBox RDR2LocationGroupBox;
        private System.Windows.Forms.Button RDR2LocationSaveButton;
        private System.Windows.Forms.Button RDR2DetectButton;
        private System.Windows.Forms.Button RDR2SelectButton;
        private System.Windows.Forms.TextBox RDR2LocationTextBox;
        private System.Windows.Forms.TabPage GTAVTabPage;
        private System.Windows.Forms.GroupBox GTAVLocationGroupBox;
        private System.Windows.Forms.Button GTAVSaveButton;
        private System.Windows.Forms.Button GTAVDetectButton;
        private System.Windows.Forms.Button GTAVSelectButton;
        private System.Windows.Forms.TextBox GTAVLocationTextBox;
        private System.Windows.Forms.TabPage GTAIVTabPage;
        private System.Windows.Forms.GroupBox GTAIVLocationGroupBox;
        private System.Windows.Forms.Button GTAIVSaveButton;
        private System.Windows.Forms.Button GTAIVDetectButton;
        private System.Windows.Forms.Button GTAIVSelectButton;
        private System.Windows.Forms.TextBox GTAIVLocationTextBox;
        private System.Windows.Forms.GroupBox RDR2LauncherGroupBox;
        private System.Windows.Forms.ComboBox RDR2LauncherComboBox;
        private System.Windows.Forms.TextBox RDR2IDTextBox;
        private System.Windows.Forms.Button RDR2LauncherSaveButton;
        private System.Windows.Forms.GroupBox GTAVLauncherGroupBox;
        private System.Windows.Forms.Button GTAVLauncherSaveButton;
        private System.Windows.Forms.TextBox GTAVIDTextBox;
        private System.Windows.Forms.ComboBox GTAVLauncherComboBox;
        private System.Windows.Forms.GroupBox GTAIVLauncherGroupBox;
        private System.Windows.Forms.Button GTAIVLauncherSaveButton;
        private System.Windows.Forms.TextBox GTAIVIDTextBox;
        private System.Windows.Forms.ComboBox GTAIVLauncherComboBox;
        private System.Windows.Forms.GroupBox OtherGroupBox;
        private System.Windows.Forms.Button DownloadListsButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
    }
}