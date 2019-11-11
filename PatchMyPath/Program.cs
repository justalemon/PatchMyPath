using Newtonsoft.Json;
using PatchMyPath.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PatchMyPath
{
    public static class Program
    {
        /// <summary>
        /// The configuration of the program.
        /// </summary>
        public static Configuration Config = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static int Main()
        {
            // Enable the visual styles
            Application.EnableVisualStyles();
            // Disable the compatible text rendering
            Application.SetCompatibleTextRenderingDefault(false);

            // Then, is time to handle the program configuration
            try
            {
                // Get the contents of the file
                string contents = File.ReadAllText("PatchMyPath.json");
                // And store the parsed config object
                Config = JsonConvert.DeserializeObject<Configuration>(contents, new InstallConverter());
            }
            // If the file was not found
            catch (FileNotFoundException)
            {
                // Create a new configuration instance and save it
                Config = new Configuration();
                SaveConfig();
            }
            // If the file could not be parsed
            catch (JsonReaderException ex)
            {
                // Ask the user if he wants to make a new configuration
                DialogResult result = MessageBox.Show($"We tried to load the configuration file but is invalid.\nDo you want to create a new configuration file?\nPress No if you want to manually check the file.\n\n({ex.Message})", "Invalid Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // If the answer is no
                if (result == DialogResult.No)
                {
                    return 1;
                }

                // Otherwise, create a new configuration and save it
                Config = new Configuration();
                SaveConfig();
            }

            // And run the application with the form
            Application.Run(new Home());
            // Finally, return a status code of zero
            return 0;
        }

        /// <summary>
        /// Saves the current configuration.
        /// </summary>
        public static void SaveConfig()
        {
            // Serialize the configuration to a JSON string and add a new line at the end
            string output = JsonConvert.SerializeObject(Config, Formatting.Indented, new InstallConverter()) + Environment.NewLine;
            // Then, save that string on PatchMyPath.json
            File.WriteAllText("PatchMyPath.json", output);
        }
    }
}
