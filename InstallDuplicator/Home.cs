using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallDuplicator
{
    public partial class Home : Form
    {
        /// <summary>
        /// The folders required for the game.
        /// </summary>
        public static string[] RequiredFolders = new string[]
        {
            "update",
            "x64",
        };
        /// <summary>
        /// Files that are required for running the game.
        /// </summary>
        public static string[] RequiredFiles = new string[]
        {
            "GTA5.exe",
            "GTAVLauncher.exe",
            "bink2w64.dll",
            "d3dcompiler_46.dll",
            "d3dcsx_46.dll",
            "GFSDK_ShadowLib.win64.dll",
            "GFSDK_TXAA.win64.dll",
            "GFSDK_TXAA_AlphaResolve.win64.dll",
            "GPUPerfAPIDX11-x64.dll",
            "NvPmApi.Core.win64.dll",
            "common.rpf",
            "x64a.rpf",
            "x64b.rpf",
            "x64c.rpf",
            "x64d.rpf",
            "x64e.rpf",
            "x64f.rpf",
            "x64g.rpf",
            "x64h.rpf",
            "x64i.rpf",
            "x64j.rpf",
            "x64k.rpf",
            "x64l.rpf",
            "x64m.rpf",
            "x64n.rpf",
            "x64o.rpf",
            "x64p.rpf",
            "x64q.rpf",
            "x64r.rpf",
            "x64s.rpf",
            "x64t.rpf",
            "x64u.rpf",
            "x64v.rpf",
            "x64w.rpf",
        };
        /// <summary>
        /// Folders that contain files that are not required by the game.
        /// </summary>
        public static string[] OptionalFolders = new string[]
        {
            "ReadMe",
            "Redistributables",
        };
        /// <summary>
        /// Files that have been added on recent updates and are not mandatory.
        /// </summary>
        public static string[] OptionalFiles = new string[]
        {
            "PlayGTAV.exe",
            "index.bin",
            "version.txt",
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
        }
    }
}
