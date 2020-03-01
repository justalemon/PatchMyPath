using NLog;
using PatchMyPath.Config;
using PatchMyPath.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PatchMyPath
{
    public partial class Home : Form
    {
        #region Properties

        /// <summary>
        /// The logger for the current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Sets the locked status of some of the UI elements.
        /// </summary>
        public bool Locked
        {
            set
            {
                LaunchToolStripMenuItem.Enabled = !value;
                RemoveToolStripMenuItem.Enabled = !value;
            }
        }

        #endregion

        #region Constructor

        public Home()
        {
            // Initialize the UI components
            InitializeComponent();
            // And lock the UI elements
            Locked = true;

            // Iterate over the launcher types
            foreach (string value in Enum.GetNames(typeof(LauncherType)))
            {
                // Add the item into the combo box
                RDR2ComboBox.Items.Add(value.SpaceOnUpperCase());
                GTAVComboBox.Items.Add(value.SpaceOnUpperCase());
            }
            
            // Iterate over the games supported
            foreach (string value in Enum.GetNames(typeof(Game)))
            {
                // If the name is not invalid
                if (value != Game.Invalid.ToString())
                {
                    // Add the item into the combo box
                    GameComboBox.Items.Add(value.SpaceOnUpperCase());
                }
            }

            // Add the supported languages into the ComboBox
            foreach (CultureInfo culture in Program.Cultures)
            {
                LanguageComboBox.Items.Add(culture.NativeName);
            }
            // And select the correct one
            LanguageComboBox.SelectedIndex = LanguageComboBox.FindStringExact(Program.Config.Language.NativeName);
        }

        #endregion

        #region Tools

        public void RefreshInstalls()
        {
            // Clear the existing items
            InstallsListBox.Items.Clear();
            // Iterate over the installs
            foreach (Install install in Program.Config.GameInstalls)
            {
                // And add them onto the ListBox
                InstallsListBox.Items.Add(install);
            }
            // Finally, update the locked status on the items
            Locked = true;
            // And log that we have finished
            Logger.Debug(Resources.FormRefreshedLog);
        }
        public void LoadSettings()
        {
            // Just load the settings from the program configuration
            AutoAddCheckBox.Checked = Program.Config.AddAfterDupe;

            RDR2LocationTextBox.Text = Program.Config.Destination.RDR2;
            GTAVLocationTextBox.Text = Program.Config.Destination.GTAV;
            RDR2ComboBox.SelectedIndex = (int)Program.Config.Launchers.RDR2Use;
            GTAVComboBox.SelectedIndex = (int)Program.Config.Launchers.GTAVUse;

            // And log that we have finished
            Logger.Debug(Resources.FormSettingsLoadLog);
        }

        #endregion

        #region Strip Items

        private void LaunchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If there is no item selected, return
            if (InstallsListBox.SelectedItem == null)
            {
                return;
            }

            // Cast the install, start it
            Install install = (Install)InstallsListBox.SelectedItem;
            install.Start();
            // And log that we are launching it
            Logger.Info(Resources.FormLaunchingLog, install.GamePath);
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the folder browser dialog
            DialogResult result = FolderBrowser.ShowDialog();

            // If the user didn't confirmed the directory selection, return
            if (result != DialogResult.OK)
            {
                return;
            }

            // Then, create a new install object with this and add it into the text box
            Install install = new Install(FolderBrowser.SelectedPath);
            // Add the new install
            Program.Config.GameInstalls.Add(install);
            // Notify that a new install was added
            Logger.Info(Resources.FormInstallAddedLog, install.GamePath);
            // Save the settings
            Program.Config.Save();
            // And refresh the ListBox
            RefreshInstalls();
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If there is no item selected, return
            if (InstallsListBox.SelectedItem == null)
            {
                return;
            }

            // Then, cast the install
            Install install = (Install)InstallsListBox.SelectedItem;
            // Remove it from the list
            Program.Config.GameInstalls.Remove((Install)InstallsListBox.SelectedItem);
            // Log the removal
            Logger.Info(Resources.FormInstallRemovedLog, install.GamePath);
            // Save the configuration
            Program.Config.Save();
            // And update the listbox
            RefreshInstalls();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Just refresh the list of installs
            RefreshInstalls();
        }

        #endregion

        #region Duplicator Tool

        private void OriginSelectButton_Click(object sender, EventArgs e)
        {
            // Show the folder browse dialog
            DialogResult result = FolderBrowser.ShowDialog();

            // If the user confirmed the folder selection, save it on the text field
            if (result == DialogResult.OK)
            {
                OriginTextBox.Text = FolderBrowser.SelectedPath;
            }
        }

        private void DestinationSelectButton_Click(object sender, EventArgs e)
        {
            // Show the folder browse dialog
            DialogResult result = FolderBrowser.ShowDialog();

            // If the user confirmed the folder selection, save it on the text field
            if (result == DialogResult.OK)
            {
                DestinationTextBox.Text = FolderBrowser.SelectedPath;
            }
        }

        private void AutoAddCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the checkbox status on the settings
            Program.Config.AddAfterDupe = AutoAddCheckBox.Checked;
            Program.Config.Save();
        }

        private void DuplicateButton_Click(object sender, EventArgs e)
        {
            // If there is no game selected, notify the user and return
            if (GameComboBox.SelectedItem == null)
            {
                MessageBox.Show(Resources.DuplicatorNoGame, Resources.DuplicatorNoGameTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(Resources.DuplicatorNoGameLog);
                return;
            }

            // If the origin or destination text box is empty or white spaces, notify the user and return
            if (string.IsNullOrWhiteSpace(OriginTextBox.Text) || string.IsNullOrWhiteSpace(DestinationTextBox.Text))
            {
                MessageBox.Show(Resources.DuplicatorNoPath, Resources.DuplicatorNoPathTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(Resources.DuplicatorNoPathLog);
                return;
            }

            // If the origin folder does not exists, notify the user and return
            if (!Directory.Exists(OriginTextBox.Text))
            {
                MessageBox.Show(Resources.DuplicatorOriginMissing, Resources.DuplicatorOriginMissingTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error(Resources.DuplicatorOriginMissingLog, OriginTextBox.Text);
                return;
            }

            // Cast the selected game
            Game game = (Game)GameComboBox.SelectedIndex;
            // If there are no entries for this game, return
            if (!ListManager.Lists.ContainsKey(game))
            {
                return;
            }
            // Otherwise, select the correct set of entries
            Dictionary<string, EntryType> entries = ListManager.Lists[game];

            // If the destination folder exists and is not empty
            if (Directory.Exists(DestinationTextBox.Text) && Directory.EnumerateFileSystemEntries(DestinationTextBox.Text).Any())
            {
                // Log this little problem
                Logger.Warn(Resources.DuplicatorHasFilesLog);
                // And ask the user if he wants to wipe the folder
                DialogResult result = MessageBox.Show(Resources.DuplicatorHasFiles, Resources.DuplicatorHasFilesTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Return if the user said no, log it and return
                if (result == DialogResult.No)
                {
                    Logger.Error(Resources.DuplicatorStoppedLog);
                    return;
                }

                // Enumerate the files and folders
                foreach (KeyValuePair<string, EntryType> entry in entries)
                {
                    // Combine them into a path
                    string path = Path.Combine(DestinationTextBox.Text, entry.Key);

                    // If is a file and exists
                    if (File.Exists(path))
                    {
                        Logger.Info(Resources.DuplicatorFileDeletedLog, path);
                        File.Delete(path);
                        continue;
                    }
                    // If is a directory and exists
                    if (Directory.Exists(path))
                    {
                        Logger.Info(Resources.DuplicatorDirectoryDeletedLog, path);
                        Directory.Delete(path);
                        continue;
                    }
                }
            }

            // If the destination folder does not exists, create it
            if (!Directory.Exists(DestinationTextBox.Text))
            {
                Logger.Info(Resources.DuplicatorCreatingDirectoryLog, DestinationTextBox.Text);
                Directory.CreateDirectory(DestinationTextBox.Text);
            }

            // Reset the progress bar to zero (just in case)
            DuplicationProgressBar.Value = 0;
            // Set the max progress to the number of items on the list
            DuplicationProgressBar.Maximum = entries.Count;

            // Iterate over the dictionary of game files and folders
            foreach (KeyValuePair<string, EntryType> entry in entries)
            {
                // Format the origin and destination
                string origin = Path.Combine(OriginTextBox.Text, entry.Key);
                string destination = Path.Combine(DestinationTextBox.Text, entry.Key);
                // Check if it exists as a directory or file
                bool fileExists = File.Exists(origin);
                bool directoryExists = Directory.Exists(origin);

                // If the entry is a file and it does not exists
                if (entry.Value.HasFlag(EntryType.File) && !fileExists)
                {
                    // If is optional, notify and continue
                    if (entry.Value.HasFlag(EntryType.Optional))
                    {
                        // Notify and continue
                        Logger.Warn(Resources.DuplicatorOptionalMissingLog, "File", entry.Key);
                        continue;
                    }
                    // If is required, notify and return
                    else
                    {
                        MessageBox.Show(string.Format(Resources.DuplicatorRequiredMissing, "file", entry.Key), string.Format(Resources.DuplicatorRequiredMissingTitle, "file"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Error(Resources.DuplicatorRequiredMissingLog, "File", entry.Key);
                        return;
                    }
                }
                // If the entry is a file and it does not exists
                else if (entry.Value.HasFlag(EntryType.Folder) && !directoryExists)
                {
                    // If is optional, notify and continue
                    if (entry.Value.HasFlag(EntryType.Optional))
                    {
                        Logger.Warn(Resources.DuplicatorOptionalMissingLog, "Directory", entry.Key);
                        continue;
                    }
                    // If is required, notify and return
                    else
                    {
                        MessageBox.Show(string.Format(Resources.DuplicatorRequiredMissing, "directory", entry.Key), string.Format(Resources.DuplicatorRequiredMissingTitle, "directory"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Error(Resources.DuplicatorRequiredMissingLog, "Directory", entry.Key);
                        return;
                    }
                }

                // If we got here, try to create the respective type
                try
                {
                    // If this is a file and we need to copy it
                    if (fileExists && entry.Value.HasFlag(EntryType.Copy))
                    {
                        File.Copy(origin, destination);
                        Logger.Debug(Resources.DuplicatorCopiedLog, origin, destination);
                    }
                    // If the symbolic link option is selected or this is a directory
                    else if (SymbolicRadioButton.Checked || entry.Value.HasFlag(EntryType.Folder))
                    {
                        Links.CreateSymbolicLink(destination, origin, entry.Value.HasFlag(EntryType.File) ? 2u : 3u);
                        string whatIs = entry.Value.HasFlag(EntryType.File) ? "File" : "Directory";
                        Logger.Debug(Resources.DuplicatorSymbolicLog, whatIs, origin, destination);
                    }
                    // Otherwise
                    else
                    {
                        Links.CreateHardLink(origin, destination);
                        Logger.Debug(Resources.DuplicatorHardLog, origin, destination);
                    }
                }
                // If we failed with a windows native error, notify the user and return
                catch (Win32Exception er)
                {
                    MessageBox.Show(string.Format(Resources.DuplicatorNativeError, er.Message), Resources.DuplicatorNativeErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Increase the progress count by one
                DuplicationProgressBar.Value += 1;
            }

            // Log that we finished the duplication
            Logger.Info(Resources.DuplicatorCompletedLog, OriginTextBox.Text, DestinationTextBox.Text);

            // If the user wants to automatically add the install, do it
            if (AutoAddCheckBox.Checked)
            {
                Program.Config.GameInstalls.Add(new Install(DestinationTextBox.Text));
                Logger.Info(Resources.DuplicatorAddedLog, DestinationTextBox.Text);
                RefreshInstalls();
            }

            // Reset the progress of the bar
            DuplicationProgressBar.Value = 0;

            // Finally, notify the user that the install is ready
            MessageBox.Show(Resources.DuplicatorCompleted, Resources.DuplicatorCompletedTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Settings - Language

        private void LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If there is nothing selected, return
            if (LanguageComboBox.SelectedItem == null)
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
                    if (Visible)
                    {
                        MessageBox.Show(Resources.SettingsLanguageChanged, Resources.SettingsLanguageChangedTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    // And return
                    return;
                }
            }
        }

        #endregion

        #region Settings - GTA V

        private void GTAVLocationSelectButton_Click(object sender, EventArgs e)
        {
            // Show the folder browse dialog
            DialogResult result = FolderBrowser.ShowDialog();

            // If the user confirmed the folder selection, save it on the text field
            if (result == DialogResult.OK)
            {
                GTAVLocationTextBox.Text = FolderBrowser.SelectedPath;
            }
        }

        private void GTAVLocationDetectButton_Click(object sender, EventArgs e)
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

        private void GTAVLocationSaveButton_Click(object sender, EventArgs e)
        {
            // Get the original paths for both locations
            string providedPath = GTAVLocationTextBox.Text.TrimEnd('\\');
            string realPath = Links.GetRealPath(GTAVLocationTextBox.Text).TrimEnd('\\');

            // If the selected folder matches the real folder, this might be the original game folder
            if (providedPath == realPath)
            {
                // Ask the user if he wants to rename it
                DialogResult result = MessageBox.Show(Resources.SettingsPathRename, Resources.SettingsPathRenameTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If he does, do it
                if (result == DialogResult.Yes)
                {
                    string newPath = providedPath + " - Clean";
                    Logger.Info(Resources.SettingsPathRenameLog, providedPath, newPath);
                    Directory.Move(providedPath, newPath);
                    Links.CreateSymbolicLink(providedPath, newPath, 3);
                }
            }
            
            // Log it
            Logger.Info(Resources.SettingsPathSetLog, Resources.GameGTAV, providedPath);
            // Replace the existing TextBox value
            GTAVLocationTextBox.Text = providedPath;
            // And save the location
            Program.Config.Destination.GTAV = providedPath;
            Program.Config.Save();
        }

        #endregion

        #region Settings - RDR 2

        private void RDR2LocationSelectButton_Click(object sender, EventArgs e)
        {
            // Show the folder browse dialog
            DialogResult result = FolderBrowser.ShowDialog();

            // If the user confirmed the folder selection, save it on the text field
            if (result == DialogResult.OK)
            {
                RDR2LocationTextBox.Text = FolderBrowser.SelectedPath;
            }
        }

        private void RDR2LocationDetectButton_Click(object sender, EventArgs e)
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

        private void RDR2LocationSaveButton_Click(object sender, EventArgs e)
        {
            // Get the original paths for both locations
            string providedPath = RDR2LocationTextBox.Text.TrimEnd('\\');
            string realPath = Links.GetRealPath(RDR2LocationTextBox.Text).TrimEnd('\\');

            // If the selected folder matches the real folder, this might be the original game folder
            if (providedPath == realPath)
            {
                // Ask the user if he wants to rename it
                DialogResult result = MessageBox.Show(Resources.SettingsPathRename, Resources.SettingsPathRenameTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If he does, do it
                if (result == DialogResult.Yes)
                {
                    string newPath = providedPath + " - Clean";
                    Logger.Info(Resources.SettingsPathRenameLog, providedPath, newPath);
                    Directory.Move(providedPath, newPath);
                    Links.CreateSymbolicLink(providedPath, newPath, 3);
                }
            }

            // Log it
            Logger.Info(Resources.SettingsPathSetLog, Resources.GameGTAV, providedPath);
            // Replace the existing TextBox value
            RDR2LocationTextBox.Text = providedPath;
            // And save the location
            Program.Config.Destination.RDR2 = providedPath;
            Program.Config.Save();
        }

        #endregion

        #region Settings - Launcher

        private void RDR2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cast the selected index to an enum and set the appropiate ID
            switch ((LauncherType)RDR2ComboBox.SelectedIndex)
            {
                case LauncherType.Executable:
                case LauncherType.RockstarGamesLauncher:
                    IDRDR2TextBox.Text = string.Empty;
                    IDRDR2TextBox.Enabled = false;
                    break;
                case LauncherType.Steam:
                    IDRDR2TextBox.Text = Program.Config.Launchers.RDR2SteamID.ToString();
                    IDRDR2TextBox.Enabled = true;
                    break;
                case LauncherType.EpicGamesStore:
                    IDRDR2TextBox.Text = Program.Config.Launchers.RDR2EpicID;
                    IDRDR2TextBox.Enabled = true;
                    break;
            }
        }

        private void SteamRDR2Button_Click(object sender, EventArgs e)
        {
            // Cast the choosen type to an enum
            LauncherType type = (LauncherType)RDR2ComboBox.SelectedIndex;

            // If the type is set to steam
            if (type == LauncherType.Steam)
            {
                // Try to parse the number as an uint
                // If we failed, notify the user and return
                if (!ulong.TryParse(IDRDR2TextBox.Text, out ulong output))
                {
                    MessageBox.Show(string.Format(Resources.SettingsInvalidID, IDRDR2TextBox.Text, ulong.MaxValue));
                    return;
                }
                // If we managed to parse the number, save it
                Program.Config.Launchers.RDR2SteamID = output;
            }
            // If the type is set to Epic Games
            else if (type == LauncherType.EpicGamesStore)
            {
                // Just save the string
                // If we managed to parse the number, save it
                Program.Config.Launchers.RDR2EpicID = IDRDR2TextBox.Text;
            }

            // Finally, save the selected launcher type
            Program.Config.Launchers.RDR2Use = type;
            Program.Config.Save();
        }

        private void GTAVComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cast the selected index to an enum and set the appropiate ID
            switch ((LauncherType)GTAVComboBox.SelectedIndex)
            {
                case LauncherType.Executable:
                case LauncherType.RockstarGamesLauncher:
                    IDGTAVTextBox.Text = string.Empty;
                    IDGTAVTextBox.Enabled = false;
                    break;
                case LauncherType.Steam:
                    IDGTAVTextBox.Text = Program.Config.Launchers.GTAVSteamID.ToString();
                    IDGTAVTextBox.Enabled = true;
                    break;
                case LauncherType.EpicGamesStore:
                    IDGTAVTextBox.Text = Program.Config.Launchers.GTAVEpicID;
                    IDGTAVTextBox.Enabled = true;
                    break;
            }
        }

        private void SteamGTAVButton_Click(object sender, EventArgs e)
        {
            // Cast the choosen type to an enum
            LauncherType type = (LauncherType)GTAVComboBox.SelectedIndex;

            // If the type is set to steam
            if (type == LauncherType.Steam)
            {
                // Try to parse the number as an uint
                // If we failed, notify the user and return
                if (!ulong.TryParse(IDGTAVTextBox.Text, out ulong output))
                {
                    MessageBox.Show(string.Format(Resources.SettingsInvalidID, IDGTAVTextBox.Text, ulong.MaxValue));
                    return;
                }
                // If we managed to parse the number, save it
                Program.Config.Launchers.GTAVSteamID = output;
            }
            // If the type is set to Epic Games
            else if (type == LauncherType.EpicGamesStore)
            {
                // Just save the string
                // If we managed to parse the number, save it
                Program.Config.Launchers.GTAVEpicID = IDGTAVTextBox.Text;
            }

            // Finally, save the selected launcher type
            Program.Config.Launchers.GTAVUse = type;
            Program.Config.Save();
        }

        #endregion

        #region Other

        private void Home_Load(object sender, EventArgs e)
        {
            // Fill the text with the licenses
            LicensesRichTextBox.Rtf = Resources.Licenses;
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            // Populate the lists of files (download if they don't exist)
            ListManager.Populate();
            // Reload the list of installs
            RefreshInstalls();
            // Load the settings
            LoadSettings();
        }

        private void InstallsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If there is no selected item, lock the UI elements
            Locked = InstallsListBox.SelectedItem == null;
        }

        private void DownloadFileListsButton_Click(object sender, EventArgs e)
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
