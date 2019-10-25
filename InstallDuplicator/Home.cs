using PatchMyPath.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InstallDuplicator
{
    public enum Type
    {
        FileRequired = 0,
        FileOptional = 1,
        FolderRequired = 2,
        FolderOptional = 3,
    }

    public partial class Home : Form
    {
        /// <summary>
        /// The files that are part of the game.
        /// </summary>
        public static Dictionary<string, Type> FilesFolders = new Dictionary<string, Type>()
        {
            { "ReadMe", Type.FolderOptional },
            { "Redistributables", Type.FolderOptional },
            { "update", Type.FolderRequired },
            { "x64", Type.FolderRequired },

            { "GTA5.exe", Type.FileRequired },
            { "GTAVLauncher.exe", Type.FileRequired },
            { "PlayGTAV.exe", Type.FileOptional },
            { "bink2w64.dll", Type.FileRequired },
            { "d3dcompiler_46.dll", Type.FileRequired },
            { "d3dcsx_46.dll", Type.FileRequired },
            { "GFSDK_ShadowLib.win64.dll", Type.FileRequired },
            { "GFSDK_TXAA.win64.dll", Type.FileRequired },
            { "GFSDK_TXAA_AlphaResolve.win64.dll", Type.FileRequired },
            { "GPUPerfAPIDX11-x64.dll", Type.FileRequired },
            { "NvPmApi.Core.win64.dll", Type.FileRequired },
            { "index.bin", Type.FileOptional },
            { "common.rpf", Type.FileRequired },
            { "x64a.rpf", Type.FileRequired },
            { "x64b.rpf", Type.FileRequired },
            { "x64c.rpf", Type.FileRequired },
            { "x64d.rpf", Type.FileRequired },
            { "x64e.rpf", Type.FileRequired },
            { "x64f.rpf", Type.FileRequired },
            { "x64g.rpf", Type.FileRequired },
            { "x64h.rpf", Type.FileRequired },
            { "x64i.rpf", Type.FileRequired },
            { "x64j.rpf", Type.FileRequired },
            { "x64k.rpf", Type.FileRequired },
            { "x64l.rpf", Type.FileRequired },
            { "x64m.rpf", Type.FileRequired },
            { "x64n.rpf", Type.FileRequired },
            { "x64o.rpf", Type.FileRequired },
            { "x64p.rpf", Type.FileRequired },
            { "x64q.rpf", Type.FileRequired },
            { "x64r.rpf", Type.FileRequired },
            { "x64s.rpf", Type.FileRequired },
            { "x64t.rpf", Type.FileRequired },
            { "x64u.rpf", Type.FileRequired },
            { "x64v.rpf", Type.FileRequired },
            { "x64w.rpf", Type.FileRequired },
            { "version.txt", Type.FileOptional },
        };

        public Home()
        {
            // Initialize the UI elements
            InitializeComponent();
            // And add some logging text
            LogTextBox.AppendText($"Welcome to the Install Duplicator of PatchMyPath!{Environment.NewLine}");
            LogTextBox.AppendText($"This tool helps with the creation of multiple GTA V folders by reducing the storage space required for them.{Environment.NewLine}");
        }

        private void OriginButton_Click(object sender, EventArgs e)
        {
            // Show the folder browse dialog
            DialogResult result = SelectFolderBrowserDialog.ShowDialog();

            // If the user confirmed the folder selection, save it on the text field
            if (result == DialogResult.OK)
            {
                OriginTextBox.Text = SelectFolderBrowserDialog.SelectedPath;
            }
        }

        private void DestinationButton_Click(object sender, EventArgs e)
        {
            // Show the folder browse dialog
            DialogResult result = SelectFolderBrowserDialog.ShowDialog();

            // If the user confirmed the folder selection, save it on the text field
            if (result == DialogResult.OK)
            {
                DestinationTextBox.Text = SelectFolderBrowserDialog.SelectedPath;
            }
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
                DialogResult result = MessageBox.Show("The Destination folder has files present, do you want to delete them?", "Destination Contains Files", MessageBoxButtons.YesNo);

                // Return if the user said no
                if (result == DialogResult.No)
                {
                    LogTextBox.AppendText($"ERROR: The Destination folder contains files and the user cancelled the removal of them{Environment.NewLine}");
                    return;
                }

                // Enumerate the files and folders
                foreach (string entry in Directory.EnumerateFileSystemEntries(DestinationTextBox.Text, "*", SearchOption.TopDirectoryOnly))
                {
                    // If is a file
                    if (File.Exists(entry))
                    {
                        File.Delete(entry);
                        continue;
                    }
                    // If is a directory
                    if (Directory.Exists(entry))
                    {
                        Directory.Delete(entry);
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
            foreach (KeyValuePair<string, Type> file in FilesFolders)
            {
                // Format the origin and destination
                string origin = Path.Combine(OriginTextBox.Text, file.Key);
                string destination = Path.Combine(DestinationTextBox.Text, file.Key);
                // Check if it exists as a directory or file
                bool fileExists = File.Exists(origin);
                bool directoryExists = Directory.Exists(origin);

                // If the file or directory does not exists
                if ((!fileExists && file.Value == Type.FileRequired) || (!directoryExists && file.Value == Type.FolderRequired))
                {
                    // Notify the user and return
                    LogTextBox.AppendText($"ERROR: The file or folder {file.Key} does not exists and is required!{Environment.NewLine}");
                    return;
                }
                // If it does not exists but is not required
                else if ((!fileExists && file.Value == Type.FileOptional) || (!directoryExists && file.Value == Type.FolderOptional))
                {
                    // Notify and continue
                    LogTextBox.AppendText($"{file.Key} does not exists but is not required, skipping...{Environment.NewLine}");
                    continue;
                }

                // Set the correct flag for the symbolic link
                uint flag = (file.Value == Type.FileOptional || file.Value == Type.FileRequired) ? 2u : 3u;
                // Otherwise, create the symbolic link
                bool success = SymbolicLink.CreateSymbolicLink(destination, origin, flag);

                // If we succeeded, notify the user and continue
                if (success)
                {
                    LogTextBox.AppendText($"Successfully linked {file.Key}!{Environment.NewLine}");
                }
                // Otherwise
                else
                {
                    LogTextBox.AppendText($"ERROR: {SymbolicLink.GetLastErrorMessage()}{Environment.NewLine}");
                    return;
                }
            }
        }
    }
}
