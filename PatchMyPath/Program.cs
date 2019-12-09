using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;
using PatchMyPath.Config;
using PatchMyPath.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PatchMyPath
{
    public static class Program
    {
        /// <summary>
        /// The list of supported culture languages.
        /// </summary>
        public static readonly List<CultureInfo> Cultures = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("es-419"),
        };
        /// <summary>
        /// The configuration of the program.
        /// </summary>
        public static Configuration Config = Configuration.Load();

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

            // Set the culture to the one from the config
            Thread.CurrentThread.CurrentUICulture = Config.Language;
            // And run the application with the form
            Application.Run(new Home());
            // Finally, return a status code of zero
            return 0;
        }
    }
}
