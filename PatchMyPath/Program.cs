using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace PatchMyPath
{
    static class Program
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

            // Try to parse the configuration
            try
            {
                Config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("PatchMyPath.json"));
            }
            // If the file was not found
            catch (FileNotFoundException)
            {
                MessageBox.Show("The Configuration File does not exists!\nPlease check that PatchMyPath.json is present and try again.");
                return 1;
            }
            // If the file could not be parsed
            catch (JsonSerializationException)
            {
                Console.WriteLine("The Configuration file is invalid!\nPlease make sure that the Curly Brackets and Comas are in the correct place.\nIf you know what you are doing: Use a Linter on a Code Editor/IDE.");
                return 2;
            }

            // And run the application with the form
            Application.Run(new Home());
            // Finally, return a status code of zero
            return 0;
        }
    }
}
