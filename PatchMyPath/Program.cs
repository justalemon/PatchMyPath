using Lemon.NLog.WinForms;
using NLog;
using NLog.Config;
using NLog.Targets;
using PatchMyPath.Config;
using PatchMyPath.Properties;
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
        /// The logger for the current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
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
        /// The form used for the main operations.
        /// </summary>
        public static Home HomeForm = null;

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

            // Set the culture to the one from the config
            Thread.CurrentThread.CurrentUICulture = Config.Language;
            // Log that we are creating a new instance of the form
            Logger.Trace(Resources.FormCreatingLog);
            // An a new home formulary
            HomeForm = new Home();
            // Log that we have loaded everything
            Logger.Debug(Resources.FormInitEndLog);

            // Create a new NLog configuration
            LoggingConfiguration config = new LoggingConfiguration();
            // Add the rules for the targets
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, new FileTarget() { FileName = "PatchMyPath.log", MaxArchiveFiles = 5, ArchiveOldFileOnStartup = true });
            config.AddRule(LogLevel.Info, LogLevel.Fatal, new TextBoxTarget(HomeForm.LogTextBox) { Layout = "[${date}] [${level}] ${message}" });
            config.AddRule(LogLevel.Info, LogLevel.Fatal, new ToolStripStatusLabelTarget(HomeForm.LogToolStripStatusLabel) { Layout = "${message}" });
            // And apply the configuration
            LogManager.Configuration = config;

            // And run the application with the form
            Application.Run(HomeForm);
            // Finally, return a status code of zero
            return 0;
        }
    }
}
