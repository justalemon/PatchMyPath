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
        }
        public void LoadSettings()
        {
            // Just load the settings from the program configuration
            RDR2LocationTextBox.Text = Program.Config.Destination.RDR2;
            GTAVLocationTextBox.Text = Program.Config.Destination.GTAV;
            SteamRDR2CheckBox.Checked = Program.Config.Steam.RDR2Use;
            SteamGTAVCheckBox.Checked = Program.Config.Steam.GTAVUse;
            IDRDR2TextBox.Text = Program.Config.Steam.RDR2AppID.ToString();
            IDGTAVTextBox.Text = Program.Config.Steam.GTAVAppID.ToString();
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

            // Cast the install
            Install install = (Install)InstallsListBox.SelectedItem;
            // And boot the game
            install.Start();
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

            // If the origin or destination text box is empty or white spaces, notify the user and return
            if (string.IsNullOrWhiteSpace(OriginTextBox.Text) || string.IsNullOrWhiteSpace(DestinationTextBox.Text))
            {
                MessageBox.Show("Looks like one of the folders has not been selected.\nPlease check that there is an Origin and Destination folder selected and try again.", "Directory not Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If the origin folder does not exists, notify the user and return
            if (!Directory.Exists(OriginTextBox.Text))
            {
                MessageBox.Show($"The Origin folder does not exists!\nPlease ensure that the selected folder is present and try again.", "Origin Folder is Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Ask the user if he wants to wipe the folder
                DialogResult result = MessageBox.Show("The Destination folder contains files and/or folders\nDo you want to search for game files and delete them if they are present?", "Destination Contains Files and/or Folders", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Return if the user said no
                if (result == DialogResult.No)
                {
                    MessageBox.Show($"The Destination folder contains files and you cancelled the removal of game files.", "Cancelled Removal of Game Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        LogTextBox.AppendText($"Warning: The file {entry.Key} does not exists but is not required, skipping...{Environment.NewLine}");
                        continue;
                    }
                    // If is required, notify and return
                    else
                    {
                        MessageBox.Show($"The file {entry.Key} does not exists and is required!\nThe process has been stopped!", "Unable to find Required File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogTextBox.AppendText($"Error: The file {entry.Key} does not exists and is required{Environment.NewLine}");
                        return;
                    }
                }
                // If the entry is a file and it does not exists
                else if (entry.Value.HasFlag(EntryType.Folder) && !directoryExists)
                {
                    // If is optional, notify and continue
                    if (entry.Value.HasFlag(EntryType.Optional))
                    {
                        LogTextBox.AppendText($"Warning: The folder {entry.Key} does not exists but is not required, skipping...{Environment.NewLine}");
                        continue;
                    }
                    // If is required, notify and return
                    else
                    {
                        MessageBox.Show($"The folder {entry.Key} does not exists and is required!\nThe process has been stopped!", "Unable to find Required Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogTextBox.AppendText($"Error: The folder {entry.Key} does not exists and is required{Environment.NewLine}");
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
                    }
                    // If the symbolic link option is selected or this is a directory
                    else if (SymbolicRadioButton.Checked || entry.Value.HasFlag(EntryType.Folder))
                    {
                        Links.CreateSymbolicLink(destination, origin, entry.Value.HasFlag(EntryType.File) ? 2u : 3u);
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
                // And return
                return;
            }
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
                    Directory.Move(GTAVLocationTextBox.Text, GTAVLocationTextBox.Text + " - Clean");
                    Links.CreateSymbolicLink(GTAVLocationTextBox.Text, GTAVLocationTextBox.Text + " - Clean", 3);
                }
            }

            // Then save the location
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
                    Directory.Move(RDR2LocationTextBox.Text, RDR2LocationTextBox.Text + " - Clean");
                    Links.CreateSymbolicLink(RDR2LocationTextBox.Text, RDR2LocationTextBox.Text + " - Clean", 3);
                }
            }

            // Then save the location
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
