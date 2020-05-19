using NLog;
using PatchMyPath.Config;
using PatchMyPath.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PatchMyPath
{
    public partial class FormHome : Form
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

        public FormHome()
        {
            // Initialize the UI components
            InitializeComponent();
            // And lock the UI elements
            Locked = true;

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

        public void AddInstall(Install install)
        {
            // Add the new install onto the configuration
            Program.Config.GameInstalls.Add(install);
            // Notify that a new install was added
            Logger.Info(Resources.FormInstallAddedLog, install.GamePath);
            // Save the settings
            Program.Config.Save();
            // And refresh the ListBox
            RefreshInstalls();
        }

        public void LoadSettings()
        {
            // Just load the settings from the program configuration
            AutoAddCheckBox.Checked = Program.Config.AddAfterDupe;
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

            // Otherwise, add the install
            AddInstall(new Install(FolderBrowser.SelectedPath));
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

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open the settings form as a dialog
            Program.ConfigForm.ShowDialog();
        }

        #endregion

        #region Context Menu Items

        private void ExecutableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InstallsListBox.SelectedItem is Install install)
            {
                install.Start(Launch.Normal, LauncherType.Executable);
            }
        }

        private void RGLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InstallsListBox.SelectedItem is Install install)
            {
                install.Start(Launch.Normal, LauncherType.RockstarGamesLauncher);
            }
        }

        private void SteamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InstallsListBox.SelectedItem is Install install)
            {
                install.Start(Launch.Normal, LauncherType.Steam);
            }
        }

        private void EGLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InstallsListBox.SelectedItem is Install install)
            {
                install.Start(Launch.Normal, LauncherType.EpicGamesStore);
            }
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
                AddInstall(new Install(DestinationTextBox.Text));
            }

            // Reset the progress of the bar
            DuplicationProgressBar.Value = 0;

            // Finally, notify the user that the install is ready
            MessageBox.Show(Resources.DuplicatorCompleted, Resources.DuplicatorCompletedTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void InstallContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // If there are no items selected, cancel the opening of the menu
            if (InstallsListBox.SelectedItem == null)
            {
                e.Cancel = true;
            }
        }

        #endregion
    }
}
