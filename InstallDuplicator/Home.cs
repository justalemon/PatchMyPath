using PatchMyPath.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InstallDuplicator
{
    public partial class Home : Form
    {
        public Home()
        {
            // Initialize the UI elements
            InitializeComponent();
            // And add some logging text
            LogTextBox.AppendText($"Welcome to the Install Duplicator of PatchMyPath!{Environment.NewLine}");
            LogTextBox.AppendText($"This tool helps with the creation of multiple GTA V folders by reducing the storage space required for them.{Environment.NewLine}");
        }

        private void DuplicateButton_Click(object sender, EventArgs e)
        {
            // If the origin folder does not exists, return
            if (!Directory.Exists(OriginTextBox.Text))
            {
                LogTextBox.AppendText($"ERROR: The Origin folder does not exists!{Environment.NewLine}");
                return;
            }

            // If the destination folder exists and is not empty
            if (Directory.Exists(DestinationTextBox.Text) && Directory.EnumerateFileSystemEntries(DestinationTextBox.Text).Any())
            {
                // Ask the user if he wants to wipe the folder
                DialogResult result = MessageBox.Show("The Destination folder contains files and/or folders\nDo you want to search for game files and delete them if they are present?", "Destination Contains Files", MessageBoxButtons.YesNo);

                // Return if the user said no
                if (result == DialogResult.No)
                {
                    LogTextBox.AppendText($"ERROR: The Destination folder contains files and the user cancelled the removal of game files{Environment.NewLine}");
                    return;
                }

                // Enumerate the files and folders
                foreach (KeyValuePair<string, EntryType> entry in FilesFolders)
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

            // If the destination folder does not exists
            if (!Directory.Exists(DestinationTextBox.Text))
            {
                // Create it
                Directory.CreateDirectory(DestinationTextBox.Text);
            }

            // Iterate over the required files
            foreach (KeyValuePair<string, EntryType> file in FilesFolders)
            {
                // Format the origin and destination
                string origin = Path.Combine(OriginTextBox.Text, file.Key);
                string destination = Path.Combine(DestinationTextBox.Text, file.Key);
                // Check if it exists as a directory or file
                bool fileExists = File.Exists(origin);
                bool directoryExists = Directory.Exists(origin);

                // If the file or directory does not exists
                if ((!fileExists && file.Value == EntryType.FileRequired) || (!directoryExists && file.Value == EntryType.FolderRequired))
                {
                    // Notify the user and return
                    LogTextBox.AppendText($"ERROR: The file or folder {file.Key} does not exists and is required!{Environment.NewLine}");
                    return;
                }
                // If it does not exists but is not required
                else if ((!fileExists && file.Value == EntryType.FileOptional) || (!directoryExists && file.Value == EntryType.FolderOptional))
                {
                    // Notify and continue
                    LogTextBox.AppendText($"{file.Key} does not exists but is not required, skipping...{Environment.NewLine}");
                    continue;
                }

                // Set the correct flag for the symbolic link
                uint flag = (file.Value == EntryType.FileOptional || file.Value == EntryType.FileRequired) ? 2u : 3u;
                // Otherwise, try to create the respective type
                try
                {
                    // If the symbolic link option is selected or this is a directory
                    if (SymbolicRadioButton.Checked || flag == 3u)
                    {
                        Links.CreateSymbolicLink(destination, origin, flag);
                        LogTextBox.AppendText($"Successfully created symbolic link for {file.Key}!{Environment.NewLine}");
                    }
                    // Otherwise
                    else
                    {
                        Links.CreateHardLink(origin, destination);
                        LogTextBox.AppendText($"Successfully created hard link for {file.Key}!{Environment.NewLine}");
                    }
                }
                // If we failed with a windows native error, notify the user and return
                catch (Win32Exception er)
                {
                    LogTextBox.AppendText($"ERROR: {er.Message}{Environment.NewLine}");
                    return;
                }
            }

            // Finally, notify the user that we completed the process and ask him if he wants to open the folder
            DialogResult shouldOpen = MessageBox.Show("The duplication process has been completed!\nDo you want to open the new GTA V Folder?", "Duplication Complete", MessageBoxButtons.YesNo);
            // If he does, open it up on the explorer
            if (shouldOpen == DialogResult.Yes)
            {
                Process.Start(DestinationTextBox.Text);
            }
        }
    }
}
