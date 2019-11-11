using Microsoft.Win32;
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
            // Reload the list of installs
            RefreshInstalls();
            // And lock the UI elements
            Locked = true;
            // Load the settings
            LoadSettings();
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
        }
        public void LoadSettings()
        {
            // Just load the settings from the program configuration
            LocationTextBox.Text = Program.Config.Destination;
            UseSteamCheckBox.Checked = Program.Config.UseSteam;
            AppIDTextBox.Text = Program.Config.AppID.ToString();
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

            // Store the install on a variable for now
            Install install = (Install)InstallsListBox.SelectedItem;

            // If the install is invalid, notify the user and return
            if (install.Type == InstallType.Invalid)
            {
                MessageBox.Show("We did some preliminary checks and we found that this install is invalid. Please make sure that all of the game files are present and the executables have not been modified and try again.", "Invalid Install", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Now, destroy the original game folder if is present
            if (Directory.Exists(Program.Config.Destination))
            {
                Directory.Delete(Program.Config.Destination);
            }

            // Try to create the symbolic link
            try
            {
                Links.CreateSymbolicLink(Program.Config.Destination, install.GamePath, 3); // 3 means Directory (0x1) and Unprivileged/Dev Mode (0x2)
            }
            catch (Win32Exception er)
            {
                // Print the respective error message and return
                MessageBox.Show($"An error has ocurred:\n{er.Message}", "Unable to create Symbolic Link", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Finally, launch the game
            Program.Config.Start(install.Type);
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
            // Add the new install and save it
            Program.Config.GameInstalls.Add(install);
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

            // Then, delete the item and save the configuration
            Program.Config.GameInstalls.Remove((Install)InstallsListBox.SelectedItem);
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

        private void DuplicateButton_Click(object sender, EventArgs e)
        {
            // If there is no game selected, notify the user and return
            if (GameComboBox.SelectedItem == null)
            {
                MessageBox.Show($"There is no game selected.\nPlease select the type of game at the top and try again.", "No Game Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If the origin folder does not exists, notify the user and return
            if (!Directory.Exists(OriginTextBox.Text))
            {
                MessageBox.Show($"The Origin folder does not exists!\nPlease ensure that the selected folder is present and try again.", "Origin Folder is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If the destination folder exists and is not empty
            if (Directory.Exists(DestinationTextBox.Text) && Directory.EnumerateFileSystemEntries(DestinationTextBox.Text).Any())
            {
                // Ask the user if he wants to wipe the folder
                DialogResult result = MessageBox.Show("The Destination folder contains files and/or folders\nDo you want to search for game files and delete them if they are present?", "Destination Contains Files and/or Folders", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Return if the user said no
                if (result == DialogResult.No)
                {
                    MessageBox.Show($"The Destination folder contains files and you cancelled the removal of game files.", "Cancelled Removal of Game Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Enumerate the files and folders
                foreach (KeyValuePair<string, EntryType> entry in Files.GTAV)
                {
                    // Combine them into a path
                    string path = Path.Combine(DestinationTextBox.Text, entry.Key);

                    // If is a file and exists
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                        continue;
                    }
                    // If is a directory and exists
                    if (Directory.Exists(path))
                    {
                        Directory.Delete(path);
                        continue;
                    }
                }
            }

            // If the destination folder does not exists, create it
            if (!Directory.Exists(DestinationTextBox.Text))
            {
                Directory.CreateDirectory(DestinationTextBox.Text);
            }

            // Iterate over the dictionary of game files and folders
            foreach (KeyValuePair<string, EntryType> entry in Files.GTAV)
            {
                // Format the origin and destination
                string origin = Path.Combine(OriginTextBox.Text, entry.Key);
                string destination = Path.Combine(DestinationTextBox.Text, entry.Key);
                // Check if it exists as a directory or file
                bool fileExists = File.Exists(origin);
                bool directoryExists = Directory.Exists(origin);

                // If the file or directory does not exists
                if ((!fileExists && entry.Value == EntryType.FileRequired) || (!directoryExists && entry.Value == EntryType.FolderRequired))
                {
                    // Notify the user and return
                    MessageBox.Show($"The file or folder {entry.Key} does not exists and is required!\nThe process has been stopped!", "Unable to find Required File/Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogTextBox.AppendText($"Process Stopped: The file or folder {entry.Key} does not exists and is required{Environment.NewLine}");
                    return;
                }
                // If it does not exists but is not required
                else if ((!fileExists && entry.Value == EntryType.FileOptional) || (!directoryExists && entry.Value == EntryType.FolderOptional))
                {
                    // Notify and continue
                    LogTextBox.AppendText($"Warning: The file or folder {entry.Key} does not exists but is not required, skipping...{Environment.NewLine}");
                    continue;
                }

                // Set the correct flag for the symbolic link
                uint flag = (entry.Value == EntryType.FileOptional || entry.Value == EntryType.FileRequired) ? 2u : 3u;
                // Otherwise, try to create the respective type
                try
                {
                    // If the symbolic link option is selected or this is a directory
                    if (SymbolicRadioButton.Checked || flag == 3u)
                    {
                        Links.CreateSymbolicLink(destination, origin, flag);
                        LogTextBox.AppendText($"Successfully created symbolic link for {entry.Key}!{Environment.NewLine}");
                    }
                    // Otherwise
                    else
                    {
                        Links.CreateHardLink(origin, destination);
                        LogTextBox.AppendText($"Successfully created hard link for {entry.Key}!{Environment.NewLine}");
                    }
                }
                // If we failed with a windows native error, notify the user and return
                catch (Win32Exception er)
                {
                    MessageBox.Show($"Got an Error while creating the Symbolic or Hard link\n\n{er.Message}\n\nThe process has been stopped.", "Error while creating Symbolic/Hard Link", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        #endregion

        #region Settings

        private void LocationSelectButton_Click(object sender, EventArgs e)
        {
            // Show the folder browse dialog
            DialogResult result = FolderBrowser.ShowDialog();

            // If the user confirmed the folder selection, save it on the text field
            if (result == DialogResult.OK)
            {
                LocationTextBox.Text = FolderBrowser.SelectedPath;
            }
        }

        private void LocationDetectButton_Click(object sender, EventArgs e)
        {
            // Try to get the path from the Uninstall Information
            string uninstall = Paths.GetUninstallPath();
            // If is not null
            if (uninstall != null)
            {
                // Set the text
                LocationTextBox.Text = uninstall;
                // Notify the user
                MessageBox.Show("Found the Vanilla Location on the Uninstall Information!", "Install Location Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // And return
                return;
            }

            // If we got here, try with the legacy Rockstar Warehouse location
            string warehouse = Paths.GetRockstarLauncherPath();
            // If is not null
            if (warehouse != null)
            {
                // Set the text
                LocationTextBox.Text = warehouse;
                // Notify the user
                MessageBox.Show("Found the Vanilla Location on the Legacy Rockstar Warehouse Information!", "Install Location Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // And return
                return;
            }
        }

        private void LocationSaveButton_Click(object sender, EventArgs e)
        {
            // Just save the location, nothing more
            Program.Config.Destination = LocationTextBox.Text;
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
