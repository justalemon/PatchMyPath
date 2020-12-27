using Newtonsoft.Json;
using NLog;
using PatchMyPath.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace PatchMyPath.Config
{
    /// <summary>
    /// The basic configuration information.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The logger for the current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// If this is the first time that the program has been started.
        /// </summary>
        [JsonProperty("first_launch")]
        public bool FirstLaunch { get; set; } = true;
        /// <summary>
        /// If we have consent to report exceptions via Bugsnag.
        /// </summary>
        [JsonProperty("bugsnag")]
        public bool Bugsnag { get; set; } = false;
        /// <summary>
        /// The language of the program.
        /// </summary>
        [JsonProperty("language")]
        public CultureInfo Language { get; set; } = Program.Cultures.Where(p => Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == p.TwoLetterISOLanguageName).FirstOrDefault() ?? Program.Cultures[0];
        /// <summary>
        /// If the install should be added after finishing with the duplication process.
        /// </summary>
        [JsonProperty("add_after_dupe")]
        public bool AddAfterDupe { get; set; } = true;
        /// <summary>
        /// If the game launchers should be closed before changing the game's path.
        /// </summary>
        [JsonProperty("close_launchers")]
        public bool CloseLaunchers { get; set; } = true;
        /// <summary>
        /// The settings for the usage of Steam for launching the game.
        /// </summary>
        [Obsolete("Use Configuration.Launchers instead.")]
        [JsonProperty("steam")]
        public Steam Steam { get; set; } = null;
        /// <summary>
        /// The settings for using specific launchers to start the games.
        /// </summary>
        [JsonProperty("launchers")]
        public LaunchersConfig Launchers { get; set; } = new LaunchersConfig();
        /// <summary>
        /// The destination folder for the game files.
        /// </summary>
        [JsonProperty("destination")]
        public Destinations Destination { get; set; } = new Destinations();
        /// <summary>
        /// The game installs available to the user.
        /// </summary>
        [JsonProperty("installs", NullValueHandling = NullValueHandling.Ignore)]
        public List<Install> GameInstalls { get; set; } = new List<Install>();

        private static string GetConfigLocation()
        {
            // Get the assembly that is calling 
            Assembly assembly = Assembly.GetCallingAssembly();
            // Get the location of the DLL that is using this function
            string location = new Uri(Path.GetDirectoryName(assembly.CodeBase)).LocalPath;
            // Then, make the path based on the assembly name and path and return it
            return Path.Combine(location, $"{assembly.GetName().Name}.json");
        }
        public static Configuration Load()
        {
            // Store the configuration here just in case
            Configuration config;

            // Then, is time to handle the program configuration
            try
            {
                // Try to load the configuration
                Logger.Info(Resources.ConfigLoadingLog);
                // Get the location of the configuration
                string path = GetConfigLocation();
                // Get the contents of the file
                string contents = File.ReadAllText(path);
                // And store the parsed config object
                config = JsonConvert.DeserializeObject<Configuration>(contents, new InstallConverter(), new CultureConverter());
            }
            // If the file was not found
            catch (FileNotFoundException)
            {
                // Log it
                Logger.Warn(Resources.ConfigCreatedLog);
                // Create a new configuration instance and save it
                config = new Configuration();
                config.Save();
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
                    Environment.Exit(1);
                }

                // Otherwise, create a new configuration and save it
                config = new Configuration();
                config.Save();
            }

            // If an upgrade was required and it was done, save the configuration
            if (config.Upgrade())
            {
                config.Save();
            }
            return config;
        }
        public static Configuration Regenerate()
        {
            // Create a new configuration object
            Configuration config = new Configuration();
            // Save it
            config.Save();
            // And return it
            return config;
        }
        public bool Upgrade()
        {
            // Save the status of the upgrade
            bool done = false;

            // If the configuration has a Steam object
            #pragma warning disable CS0618
            if (Steam != null)
            {
                // Save the parameters into the new classes
                Launchers.RDR2Use = Steam.RDR2Use ? LauncherType.Steam : LauncherType.Executable;
                Launchers.RDR2SteamID = Steam.RDR2AppID;
                Launchers.GTAVUse = Steam.GTAVUse ? LauncherType.Steam : LauncherType.Executable;
                Launchers.GTAVSteamID = Steam.GTAVAppID;
                // Set steam to null
                Steam = null;
                // And save that an upgrade was done
                done = true;
            }
            #pragma warning restore CS0618

            // Finally, return the upgrade status
            return done;
        }
        public void Save()
        {
            // Get the output of the serialization
            string output = JsonConvert.SerializeObject(this, Formatting.Indented, new InstallConverter(), new CultureConverter()) + Environment.NewLine;
            // And dump the contents of the file
            File.WriteAllText(GetConfigLocation(), output);
        }
    }
}
