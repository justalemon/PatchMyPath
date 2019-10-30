using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }
    }
}
