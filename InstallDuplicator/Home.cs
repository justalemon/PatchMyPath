using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
