using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InstallDuplicator
{
    public partial class Home : Form
    {
        /// <summary>
        /// The folders that are part of the game.
        /// </summary>
        public static Dictionary<string, bool> Folders = new Dictionary<string, bool>()
        {
            { "ReadMe", false },
            { "Redistributables", false },
            { "update", true },
            { "x64", true },
        };
        /// <summary>
        /// The files that are part of the game.
        /// </summary>
        public static Dictionary<string, bool> Files = new Dictionary<string, bool>()
        {
            { "GTA5.exe", true },
            { "GTAVLauncher.exe", true },
            { "PlayGTAV.exe", false },
            { "bink2w64.dll", true },
            { "d3dcompiler_46.dll", true },
            { "d3dcsx_46.dll", true },
            { "GFSDK_ShadowLib.win64.dll", true },
            { "GFSDK_TXAA.win64.dll", true },
            { "GFSDK_TXAA_AlphaResolve.win64.dll", true },
            { "GPUPerfAPIDX11-x64.dll", true },
            { "NvPmApi.Core.win64.dll", true },
            { "index.bin", false },
            { "common.rpf", true },
            { "x64a.rpf", true },
            { "x64b.rpf", true },
            { "x64c.rpf", true },
            { "x64d.rpf", true },
            { "x64e.rpf", true },
            { "x64f.rpf", true },
            { "x64g.rpf", true },
            { "x64h.rpf", true },
            { "x64i.rpf", true },
            { "x64j.rpf", true },
            { "x64k.rpf", true },
            { "x64l.rpf", true },
            { "x64m.rpf", true },
            { "x64n.rpf", true },
            { "x64o.rpf", true },
            { "x64p.rpf", true },
            { "x64q.rpf", true },
            { "x64r.rpf", true },
            { "x64s.rpf", true },
            { "x64t.rpf", true },
            { "x64u.rpf", true },
            { "x64v.rpf", true },
            { "x64w.rpf", true },
            { "version.txt", false },
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

                // Delete the directory and wait for it to be created again
                Directory.Delete(DestinationTextBox.Text, true);
            }

            // Check if the destination folder exists
            bool exists = Directory.Exists(DestinationTextBox.Text);
            // If it does not
            if (!exists)
            {
                // Create it
                Directory.CreateDirectory(DestinationTextBox.Text);
            }

            // Iterate over the required files
            foreach (KeyValuePair<string, bool> file in Files)
            {
                // Format the path
                string path = Path.Combine(OriginTextBox.Text, file.Key);
                // If it does not exists
                if (!File.Exists(path) && file.Value)
                {
                    // Notify the user and return
                    LogTextBox.AppendText($"ERROR: The required file {path} does not exists!{Environment.NewLine}");
                    return;
                }
            }
            // Iterate over the required directories
            foreach (KeyValuePair<string, bool> folder in Folders)
            {
                // Format it
                string path = Path.Combine(OriginTextBox.Text, folder.Key);
                // If it does not exists
                if (!Directory.Exists(path) && folder.Value)
                {
                    // Notify the user and return
                    LogTextBox.AppendText($"ERROR: The required folder {path} does not exists!{Environment.NewLine}");
                    return;
                }
            }
        }
    }
}
