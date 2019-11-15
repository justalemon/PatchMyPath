using Microsoft.Win32;
using NLog;
using PatchMyPath.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
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
                Logger.Debug("UI Locked status set to {0}", value);
            }
        }

        #endregion

        #region Constructor

        public Home()
        {
            // Log that we are creating a new instance of the form
            Logger.Debug("Creating a new instance of the Home Form");

            // Initialize the UI components
            InitializeComponent();
            // Reload the list of installs
            RefreshInstalls();
            // And lock the UI elements
            Locked = true;
            // Load the settings
            LoadSettings();

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

            // Log that we have loaded everything
            Logger.Debug("Finished initialization of the Home Form");
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
            Logger.Info("The list of installs has been refreshed");
        }
        public void LoadSettings()
        {
            // Just load the settings from the program configuration
            AutoAddCheckBox.Checked = Program.Config.AddAfterDupe;

            RDR2LocationTextBox.Text = Program.Config.Destination.RDR2;
            GTAVLocationTextBox.Text = Program.Config.Destination.GTAV;
            SteamRDR2CheckBox.Checked = Program.Config.Steam.RDR2Use;
            SteamGTAVCheckBox.Checked = Program.Config.Steam.GTAVUse;
            IDRDR2TextBox.Text = Program.Config.Steam.RDR2AppID.ToString();
            IDGTAVTextBox.Text = Program.Config.Steam.GTAVAppID.ToString();

            // And log that we have finished
            Logger.Info("Settings loaded from Configuration into UI Controls");
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
            Logger.Info("Launching {0}", install.GamePath);
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
            Logger.Info("Install {0} was added", install.GamePath);
            // Save the settings
            Program.SaveConfig();
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
            Logger.Info("Install {0} was removed", install.GamePath);
            // Save the configuration
            Program.SaveConfig();
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
            Program.SaveConfig();
        }

        private void DuplicateButton_Click(object sender, EventArgs e)
        {
            // If there is no game selected, notify the user and return
            if (GameComboBox.SelectedItem == null)
            {
                MessageBox.Show($"There is no game selected.\nPlease select the type of game at the top and try again.", "No Game Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error("User attempted to use the duplicator, but no game was selected");
                return;
            }

            // If the origin or destination text box is empty or white spaces, notify the user and return
            if (string.IsNullOrWhiteSpace(OriginTextBox.Text) || string.IsNullOrWhiteSpace(DestinationTextBox.Text))
            {
                MessageBox.Show("Looks like one of the folders has not been selected.\nPlease check that there is an Origin and Destination folder selected and try again.", "Directory not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error("User attempted to use the duplicator, but one of the folders is not selected");
                return;
            }

            // If the origin folder does not exists, notify the user and return
            if (!Directory.Exists(OriginTextBox.Text))
            {
                MessageBox.Show($"The Origin folder does not exists!\nPlease ensure that the selected folder is present and try again.", "Origin Folder is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error("Folder {0} can't be used for duplication: Does not exists", OriginTextBox.Text);
                return;
            }

            // Cast the selected game
            Game game = (Game)GameComboBox.SelectedIndex;
            // And select the correct list of files
            Dictionary<string, EntryType> entries;
            switch (game)
            {
                case Game.GrandTheftAutoV:
                    entries = Files.GTAV;
                    break;
                case Game.RedDeadRedemption2:
                    entries = Files.RDR2;
                    break;
                default:
                    return;
            }

            // If the destination folder exists and is not empty
            if (Directory.Exists(DestinationTextBox.Text) && Directory.EnumerateFileSystemEntries(DestinationTextBox.Text).Any())
            {
                // Log this little problem
                Logger.Warn("Folder {0} contains files, asking user if wants to continue...");
                // And ask the user if he wants to wipe the folder
                DialogResult result = MessageBox.Show("The Destination folder contains files and/or folders.\nExisting game files will be removed and replaced with links. Installed modifications will not be touched.\n\nDo you want to continue?", "Destination Contains Files and/or Folders", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Return if the user said no, log it and return
                if (result == DialogResult.No)
                {
                    Logger.Error("User stopped the duplication process");
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
                        Logger.Info("Game file {0} was deleted", path);
                        File.Delete(path);
                        continue;
                    }
                    // If is a directory and exists
                    if (Directory.Exists(path))
                    {
                        Logger.Info("Game directory {0} was deleted", path);
                        Directory.Delete(path);
                        continue;
                    }
                }
            }

            // If the destination folder does not exists, create it
            if (!Directory.Exists(DestinationTextBox.Text))
            {
                Logger.Info("Destination {0} does not exists, creating...", DestinationTextBox.Text);
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
                        Logger.Warn("File {0} does not exists but is marked as optional, skipping...", entry.Key);
                        continue;
                    }
                    // If is required, notify and return
                    else
                    {
                        MessageBox.Show($"The file {entry.Key} does not exists and is required!\nThe process has been stopped!", "Unable to find Required File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Error("File {0} does not exists and is required, duplication process stopped", entry.Key);
                        return;
                    }
                }
                // If the entry is a file and it does not exists
                else if (entry.Value.HasFlag(EntryType.Folder) && !directoryExists)
                {
                    // If is optional, notify and continue
                    if (entry.Value.HasFlag(EntryType.Optional))
                    {
                        Logger.Warn("Directory {0} does not exists but is marked as optional, skipping...", entry.Key);
                        continue;
                    }
                    // If is required, notify and return
                    else
                    {
                        MessageBox.Show($"The folder {entry.Key} does not exists and is required!\nThe process has been stopped!", "Unable to find Required Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Error("Directory {0} does not exists and is required, duplication process stopped", entry.Key);
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
                        Logger.Debug("File {0} was copied to {1}", origin, destination);
                    }
                    // If the symbolic link option is selected or this is a directory
                    else if (SymbolicRadioButton.Checked || entry.Value.HasFlag(EntryType.Folder))
                    {
                        Links.CreateSymbolicLink(destination, origin, entry.Value.HasFlag(EntryType.File) ? 2u : 3u);
                        string whatIs = entry.Value.HasFlag(EntryType.File) ? "File" : "Directory";
                        Logger.Debug("{0} symbolic link was created from {1} to {2}", whatIs, origin, destination);
                    }
                    // Otherwise
                    else
                    {
                        Links.CreateHardLink(origin, destination);
                        LogTextBox.AppendText($"Successfully created hard link for {entry.Key}!{Environment.NewLine}");
                        Logger.Debug("File hard link was created from {0} to {1}", origin, destination);
                    }
                }
                // If we failed with a windows native error, notify the user and return
                catch (Win32Exception er)
                {
                    MessageBox.Show($"Error: {er.Message}\nThe process has been stopped.", "Error while creating Symbolic/Hard Link", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Increase the progress count by one
                DuplicationProgressBar.Value += 1;
            }

            // Log that we finished the duplication
            Logger.Info("Duplication from {0} to {1} completed", OriginTextBox.Text, DestinationTextBox.Text);

            // If the user wants to automatically add the install, do it
            if (AutoAddCheckBox.Checked)
            {
                Program.Config.GameInstalls.Add(new Install(DestinationTextBox.Text));
                Logger.Info("Duplicated install {0} got added into the list", DestinationTextBox.Text);
                RefreshInstalls();
            }

            // Reset the progress of the bar
            DuplicationProgressBar.Value = 0;

            // Finally, notify the user that the install is ready
            MessageBox.Show("Success! The install has been duplicated successfully.", "Duplication Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Found the Vanilla Location on the Uninstall Information!", "Install Location Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Log it
                Logger.Info("Grand Theft Auto V was found at {0}", uninstall);
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
                MessageBox.Show("Found the Vanilla Location on the Legacy Rockstar Warehouse Information!", "Install Location Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Log it
                Logger.Info("Grand Theft Auto V was found at {0}", warehouse);
                // And return
                return;
            }

            // If we got here, we were unable to fetch the default folder
            MessageBox.Show("We were unable to detect the original location. \nPlease make sure that the game was installed from RGL, Steam or EGL and try again.", "Unable to find location", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GTAVLocationSaveButton_Click(object sender, EventArgs e)
        {
            // If the selected folder matches the real folder, this might be the original game folder
            if (GTAVLocationTextBox.Text == Links.GetRealPath(GTAVLocationTextBox.Text))
            {
                // Ask the user if he wants to rename it
                DialogResult result = MessageBox.Show("Looks like this is the original game folder.\nDo you want to rename it? (To prevent the game from being deleted/overwritten)", "Original Folder Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If he does, do it
                if (result == DialogResult.Yes)
                {
                    string path = GTAVLocationTextBox.Text + " - Clean";

                    Logger.Info("{0} is being renamed to {1} for saving", GTAVLocationTextBox.Text, path);

                    Directory.Move(GTAVLocationTextBox.Text, path);
                    Links.CreateSymbolicLink(GTAVLocationTextBox.Text, path, 3);
                }
            }
            
            // Log it
            Logger.Info("Grand Theft Auto V location set to {0}", GTAVLocationTextBox.Text);
            // And save the location
            Program.Config.Destination.GTAV = GTAVLocationTextBox.Text;
            Program.SaveConfig();
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
                MessageBox.Show("Found the Vanilla Location on the Uninstall Information!", "Install Location Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Log it
                Logger.Info("Red Dead Redemption 2 was found at {0}", uninstall);
                // And return
                return;
            }

            // If we got here, we were unable to fetch the default folder
            MessageBox.Show("We were unable to detect the original location. \nPlease make sure that the game was installed from RGL, Steam or EGL and try again.", "Unable to find location", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RDR2LocationSaveButton_Click(object sender, EventArgs e)
        {
            // If the selected folder matches the real folder, this might be the original game folder
            if (RDR2LocationTextBox.Text == Links.GetRealPath(RDR2LocationTextBox.Text))
            {
                // Ask the user if he wants to rename it
                DialogResult result = MessageBox.Show("Looks like this is the original game folder.\nDo you want to rename it? (To prevent the game from being deleted/overwritten)", "Original Folder Detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If he does, do it
                if (result == DialogResult.Yes)
                {
                    string path = RDR2LocationTextBox.Text + " - Clean";

                    Logger.Info("{0} is being renamed to {1} for saving", RDR2LocationTextBox.Text, path);

                    Directory.Move(RDR2LocationTextBox.Text, path);
                    Links.CreateSymbolicLink(RDR2LocationTextBox.Text, path, 3);
                }
            }

            // Log it
            Logger.Info("Red Dead Redemption 2 location set to {0}", RDR2LocationTextBox.Text);
            // And save the location
            Program.Config.Destination.RDR2 = RDR2LocationTextBox.Text;
            Program.SaveConfig();
        }

        #endregion

        #region Settings - Steam

        private void SteamRDR2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the checkbox status
            Program.Config.Steam.RDR2Use = SteamRDR2CheckBox.Checked;
            Program.SaveConfig();
        }

        private void SteamRDR2Button_Click(object sender, EventArgs e)
        {
            // Save the App ID as an uint
            Program.Config.Steam.RDR2AppID = ulong.Parse(IDRDR2TextBox.Text);
            Program.SaveConfig();
        }

        private void SteamGTAVCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Save the checkbox status
            Program.Config.Steam.GTAVUse = SteamGTAVCheckBox.Checked;
            Program.SaveConfig();
        }

        private void SteamGTAVButton_Click(object sender, EventArgs e)
        {
            // Save the App ID as an uint
            Program.Config.Steam.GTAVAppID = ulong.Parse(IDGTAVTextBox.Text);
            Program.SaveConfig();
        }

        #endregion

        #region Other

        private void InstallsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If there is no selected item, lock the UI elements
            Locked = InstallsListBox.SelectedItem == null;
        }

        #endregion
    }
}
