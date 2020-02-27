using NLog;
using NLog.Config;
using NLog.Targets;
using PatchMyPath.Config;
using System;
using System.Collections.Generic;
using System.Globalization;
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

            // Create a new home formulary
            Home form = new Home();

            // Create a new NLog configuration
            LoggingConfiguration config = new LoggingConfiguration();
            // Add the rules for the targets
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, new FileTarget() { FileName = "PatchMyPath.log", MaxArchiveFiles = 5, ArchiveOldFileOnStartup = true });
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, new TextBoxTarget(form.LogTextBox) { Layout = "[${date}] [${level}] ${message}" });
            // And apply the configuration
            LogManager.Configuration = config;

            // Set the culture to the one from the config
            Thread.CurrentThread.CurrentUICulture = Config.Language;
            // And run the application with the form
            Application.Run(form);
            // Finally, return a status code of zero
            return 0;
        }
    }
}
