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

namespace PatchMyPath
{
    public partial class Home : Form
    {
        public Home()
        {
            // Initialize the UI components
            InitializeComponent();

            // And reload the list of installs
            RefreshInstalls();
        }

        public void RefreshInstalls()
        {
            // Clear the existing items
            InstallsListBox.Items.Clear();
            // Iterate over the installs
            foreach (Install install in Program.Config.GameInstalls)
            {
                InstallsListBox.Items.Add(install);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void LaunchButton_Click(object sender, EventArgs e)
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
    }
}
