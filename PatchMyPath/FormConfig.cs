using NLog;
using PatchMyPath.Config;
using PatchMyPath.Properties;
using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PatchMyPath
{
    /// <summary>
    /// Form for configuring the application.
    /// </summary>
    public partial class FormConfig : Form
    {
        #region Fields

        /// <summary>
        /// The logger for the current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructor

        public FormConfig()
        {
            // Create the WinForms components
            InitializeComponent();

            // Iterate over the launcher types
            foreach (string value in Enum.GetNames(typeof(LauncherType)))
            {
                // And add the item into the combo box
                string name = value.SpaceOnUpperCase();
                RDR2LauncherComboBox.Items.Add(name);
                GTAVLauncherComboBox.Items.Add(name);
                GTAIVLauncherComboBox.Items.Add(name);
            }

            // Add the supported languages into the ComboBox
            foreach (CultureInfo culture in Program.Cultures)
            {
                LanguageComboBox.Items.Add(culture.NativeName);
            }
            // And select the correct one
            LanguageComboBox.SelectedIndex = LanguageComboBox.FindStringExact(Program.Config.Language.NativeName);

            // Populate the launchers used by the games
            RDR2LocationTextBox.Text = Program.Config.Destination.RDR2;
            GTAVLocationTextBox.Text = Program.Config.Destination.GTAV;
            GTAIVLocationTextBox.Text = Program.Config.Destination.GTAIV;
            RDR2LauncherComboBox.SelectedIndex = (int)Program.Config.Launchers.RDR2Use;
            GTAVLauncherComboBox.SelectedIndex = (int)Program.Config.Launchers.GTAVUse;
            GTAIVLauncherComboBox.SelectedIndex = (int)Program.Config.Launchers.GTAIVUse;

            // Finally, log that we have finished the population of settings
            Logger.Debug(Resources.FormSettingsLoadLog);
        }

        #endregion

        #region Language

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If there is nothing selected or the form is not visible, return
            if (LanguageComboBox.SelectedItem == null || !Visible)
            {
                return;
            }

            // Iterate over the supported languages
            foreach (CultureInfo culture in Program.Cultures)
            {
                // If the name matches
                if (culture.NativeName == LanguageComboBox.SelectedItem.ToString())
                {
                    // Set the culture on the configuration and save it
                    Program.Config.Language = culture;
                    Program.Config.Save();
                    // If the form is visible, show a message about the change
                    MessageBox.Show(Resources.SettingsLanguageChanged, Resources.SettingsLanguageChangedTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // And return
                    return;
                }
            }
        }

        #endregion

        #region Select

        private void RDR2SelectButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                RDR2LocationTextBox.Text = FolderBrowser.SelectedPath;
            }
        }

        private void GTAVSelectButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                GTAVLocationTextBox.Text = FolderBrowser.SelectedPath;
            }
        }

        private void GTAIVSelectButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                GTAIVLocationTextBox.Text = FolderBrowser.SelectedPath;
            }
        }

        #endregion

        #region Detect

        private void RDR2DetectButton_Click(object sender, EventArgs e)
        {
            // Try to get the path from the Uninstall Information
            string uninstall = Paths.RDR2.UninstallLocation;
            // If is not null
            if (uninstall != null)
            {
                // Set the text
                RDR2LocationTextBox.Text = uninstall;
                // Notify the user
                MessageBox.Show(Resources.SettingsPathUninstall, Resources.SettingsPathUninstallTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Log it
                Logger.Info(string.Format(Resources.SettingsPathFoundLog, Resources.GameRDR2, uninstall), uninstall);
                // And return
                return;
            }

            // If we got here, we were unable to fetch the default folder
            MessageBox.Show(Resources.SettingsPathNotFound, Resources.SettingsPathNotFoundTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GTAVDetectButton_Click(object sender, EventArgs e)
        {
            // Try to get the path from the Uninstall Information
            string uninstall = Paths.GTAV.UninstallLocation;
            // If is not null
            if (uninstall != null)
            {
                // Set the text
                GTAVLocationTextBox.Text = uninstall;
                // Notify the user
                MessageBox.Show(Resources.SettingsPathUninstall, Resources.SettingsPathUninstallTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Log it
                Logger.Info(string.Format(Resources.SettingsPathFoundLog, Resources.GameGTAV, uninstall), uninstall);
                // And return
                return;
            }

            // If we got here, try with the legacy Rockstar Warehouse location
            string warehouse = Paths.GTAV.WarehouseLocation;
            // If is not null
            if (warehouse != null)
            {
                // Set the text
                GTAVLocationTextBox.Text = warehouse;
                // Notify the user
                MessageBox.Show(Resources.SettingsPathWarehouse, Resources.SettingsPathWarehouseTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Log it
                Logger.Info(string.Format(Resources.SettingsPathFoundLog, Resources.GameGTAV, uninstall), warehouse);
                // And return
                return;
            }

            // If we got here, we were unable to fetch the default folder
            MessageBox.Show(Resources.SettingsPathNotFound, Resources.SettingsPathNotFoundTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GTAIVDetectButton_Click(object sender, EventArgs e)
        {
            // If we got here, we were unable to fetch the default folder
            MessageBox.Show(Resources.SettingsPathNotFound, Resources.SettingsPathNotFoundTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Save

        private bool EnsureCorrectFolder(string og, out string provided)
        {
            // Get the original paths for both locations
            provided = og.TrimEnd('\\');
            string real;
            try
            {
                real = Links.GetRealPath(og).TrimEnd('\\');
            }
            catch (Win32Exception)
            {
                real = provided;
            }

            // If the selected folder matches the real folder and it exists, this might be the original game folder
            if (provided == real && Directory.Exists(real))
            {
                // Ask the user if he wants to rename it
                DialogResult result = MessageBox.Show(Resources.SettingsPathRename, Resources.SettingsPathRenameTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If he does, do it
                if (result == DialogResult.Yes)
                {
                    string newPath = provided + " - Clean";
                    Logger.Info(Resources.SettingsPathRenameLog, provided, newPath);
                    try
                    {
                        Directory.Move(provided, newPath);
                        Links.CreateSymbolicLink(provided, newPath, 3);
                        Program.HomeForm.AddInstall(new Install(newPath));
                        return true;
                    }
                    catch (IOException)
                    {
                        MessageBox.Show(string.Format(Resources.SettingsAccessDenied, provided), Resources.SettingsAccessDeniedTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Error(string.Format(Resources.SettingsAccessDeniedLog, provided));
                        return false;
                    }
                }
            }
            return true;
        }

        private void RDR2LocationSaveButton_Click(object sender, EventArgs e)
        {
            if (EnsureCorrectFolder(RDR2LocationTextBox.Text, out string provided))
            {
                Logger.Info(Resources.SettingsPathSetLog, Resources.GameRDR2, provided);
                Program.Config.Destination.RDR2 = provided;
                Program.Config.Save();
            }
        }

        private void GTAVSaveButton_Click(object sender, EventArgs e)
        {
            if (EnsureCorrectFolder(GTAVLocationTextBox.Text, out string provided))
            {
                Logger.Info(Resources.SettingsPathSetLog, Resources.GameGTAV, provided);
                Program.Config.Destination.GTAV = provided;
                Program.Config.Save();
            }
        }

        private void GTAIVSaveButton_Click(object sender, EventArgs e)
        {
            if (EnsureCorrectFolder(GTAIVLocationTextBox.Text, out string provided))
            {
                Logger.Info(Resources.SettingsPathSetLog, Resources.GameGTAIV, provided);
                Program.Config.Destination.GTAIV = provided;
                Program.Config.Save();
            }
        }

        #endregion

        #region Launcher Selector

        private void RDR2LauncherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((LauncherType)RDR2LauncherComboBox.SelectedIndex)
            {
                case LauncherType.Executable:
                case LauncherType.RockstarGamesLauncher:
                    RDR2IDTextBox.Text = string.Empty;
                    RDR2IDTextBox.Enabled = false;
                    break;
                case LauncherType.Steam:
                    RDR2IDTextBox.Text = Program.Config.Launchers.RDR2SteamID.ToString();
                    RDR2IDTextBox.Enabled = true;
                    break;
                case LauncherType.EpicGamesStore:
                    RDR2IDTextBox.Text = Program.Config.Launchers.RDR2EpicID;
                    RDR2IDTextBox.Enabled = true;
                    break;
            }
        }

        private void GTAVLauncherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((LauncherType)GTAVLauncherComboBox.SelectedIndex)
            {
                case LauncherType.Executable:
                case LauncherType.RockstarGamesLauncher:
                    GTAVIDTextBox.Text = string.Empty;
                    GTAVIDTextBox.Enabled = false;
                    break;
                case LauncherType.Steam:
                    GTAVIDTextBox.Text = Program.Config.Launchers.GTAVSteamID.ToString();
                    GTAVIDTextBox.Enabled = true;
                    break;
                case LauncherType.EpicGamesStore:
                    GTAVIDTextBox.Text = Program.Config.Launchers.GTAVEpicID;
                    GTAVIDTextBox.Enabled = true;
                    break;
            }
        }

        private void GTAIVLauncherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((LauncherType)GTAIVLauncherComboBox.SelectedIndex)
            {
                case LauncherType.Executable:
                case LauncherType.RockstarGamesLauncher:
                    GTAIVIDTextBox.Text = string.Empty;
                    GTAIVIDTextBox.Enabled = false;
                    break;
                case LauncherType.Steam:
                    GTAIVIDTextBox.Text = Program.Config.Launchers.GTAIVSteamID.ToString();
                    GTAIVIDTextBox.Enabled = true;
                    break;
                case LauncherType.EpicGamesStore:
                    GTAIVIDTextBox.Text = Program.Config.Launchers.GTAIVEpicID;
                    GTAIVIDTextBox.Enabled = true;
                    break;
            }
        }

        #endregion

        #region Save

        private void RDR2LauncherSaveButton_Click(object sender, EventArgs e)
        {

            // Handle the requirements of specific launchers
            switch ((LauncherType)RDR2LauncherComboBox.SelectedIndex)
            {
                // For Steam, parse the appid
                case LauncherType.Steam:
                    {
                        if (!ulong.TryParse(RDR2IDTextBox.Text, out ulong output))
                        {
                            MessageBox.Show(string.Format(Resources.SettingsInvalidID, RDR2IDTextBox.Text, ulong.MaxValue));
                            return;
                        }
                        Program.Config.Launchers.RDR2SteamID = output;
                        break;
                    }
                // For EGS, the ID is a random string so just save it
                case LauncherType.EpicGamesStore:
                    Program.Config.Launchers.RDR2EpicID = RDR2IDTextBox.Text;
                    break;
            }

            // Finally, save the selected launcher type
            Program.Config.Launchers.RDR2Use = (LauncherType)RDR2LauncherComboBox.SelectedIndex;
            Program.Config.Save();
        }

        private void GTAVLauncherSaveButton_Click(object sender, EventArgs e)
        {
            // Handle the requirements of specific launchers
            switch ((LauncherType)GTAVLauncherComboBox.SelectedIndex)
            {
                // For Steam, parse the appid
                case LauncherType.Steam:
                    {
                        if (!ulong.TryParse(GTAVIDTextBox.Text, out ulong output))
                        {
                            MessageBox.Show(string.Format(Resources.SettingsInvalidID, GTAVIDTextBox.Text, ulong.MaxValue));
                            return;
                        }
                        Program.Config.Launchers.GTAVSteamID = output;
                        break;
                    }
                // For EGS, the ID is a random string so just save it
                case LauncherType.EpicGamesStore:
                    Program.Config.Launchers.GTAVEpicID = GTAVIDTextBox.Text;
                    break;
            }

            // Finally, save the selected launcher type
            Program.Config.Launchers.GTAVUse = (LauncherType)GTAVLauncherComboBox.SelectedIndex;
            Program.Config.Save();
        }

        private void GTAIVLauncherSaveButton_Click(object sender, EventArgs e)
        {
            // Handle the requirements of specific launchers
            switch ((LauncherType)GTAIVLauncherComboBox.SelectedIndex)
            {
                // For Steam, parse the appid
                case LauncherType.Steam:
                    {
                        if (!ulong.TryParse(GTAIVIDTextBox.Text, out ulong output))
                        {
                            MessageBox.Show(string.Format(Resources.SettingsInvalidID, GTAIVIDTextBox.Text, ulong.MaxValue));
                            return;
                        }
                        Program.Config.Launchers.GTAIVSteamID = output;
                        break;
                    }
                // For EGS, the ID is a random string so just save it
                case LauncherType.EpicGamesStore:
                    Program.Config.Launchers.GTAIVEpicID = GTAIVIDTextBox.Text;
                    break;
            }

            // Finally, save the selected launcher type
            Program.Config.Launchers.GTAIVUse = (LauncherType)GTAIVLauncherComboBox.SelectedIndex;
            Program.Config.Save();
        }

        #endregion

        #region Download Lists

        private void DownloadListsButton_Click(object sender, EventArgs e)
        {
            // Ask the user if he is sure about this
            DialogResult result = MessageBox.Show(Resources.SettingsOtherDownload, Resources.SettingsOtherDownloadTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // If he does, force the redownload of the files
            if (result == DialogResult.Yes)
            {
                ListManager.Populate(true);
            }
        }

        #endregion
    }
}
