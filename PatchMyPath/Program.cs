using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;
using PatchMyPath.Config;
using PatchMyPath.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PatchMyPath
{
    public static class Program
    {
        /// <summary>
        /// The logger for the current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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

            // Create a new NLog configuration
            LoggingConfiguration config = new LoggingConfiguration();
            // Create a target to write the logging into a file
            FileTarget logfile = new FileTarget("logfile") { FileName = "PatchMyPath.log" };
            // Add the rules for using the targets
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            // And apply the configuration
            LogManager.Configuration = config;

            // Then, is time to handle the program configuration
            try
            {
                // Try to load the configuration
                Logger.Info(Resources.ConfigLoadingLog);
                // Get the contents of the file
                string contents = File.ReadAllText("PatchMyPath.json");
                // And store the parsed config object
                Config = JsonConvert.DeserializeObject<Configuration>(contents, new InstallConverter());
            }
            // If the file was not found
            catch (FileNotFoundException)
            {
                // Log it
                Logger.Warn(Resources.ConfigCreatedLog);
                // And create a new configuration instance and save it
                Config = new Configuration();
                SaveConfig();
            }
            // If the file could not be parsed
            catch (JsonException ex)
            {
                // Log it
                Logger.Error(Resources.ConfigNotParsedLog, ex.Message);
                // Ask the user if he wants to make a new configuration
                DialogResult result = MessageBox.Show(string.Format(Resources.ConfigInvalid, ex.Message), Resources.ConfigInvalidTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // If the answer is no
                if (result == DialogResult.No)
                {
                    Logger.Fatal(Resources.ConfigInvalidLog);
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
            // Log that we are going to save the config
            Logger.Info(Resources.ConfigSavingLog);
            // Serialize the configuration to a JSON string and add a new line at the end
            string output = JsonConvert.SerializeObject(Config, Formatting.Indented, new InstallConverter()) + Environment.NewLine;
            // Then, save that string on PatchMyPath.json
            File.WriteAllText("PatchMyPath.json", output);
            // Yeet, config is saved
            Logger.Info(Resources.ConfigSavedLog);
        }
    }
}
