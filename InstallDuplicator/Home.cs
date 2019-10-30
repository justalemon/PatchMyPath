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
        }

        private void DuplicateButton_Click(object sender, EventArgs e)
        {
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
