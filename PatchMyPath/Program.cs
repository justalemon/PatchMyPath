using Bugsnag;
using Lemon.NLog.WinForms;
using NLog;
using NLog.Config;
using NLog.Targets;
using PatchMyPath.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Configuration = PatchMyPath.Config.Configuration;

namespace PatchMyPath
{
    public static class Program
    {
        /// <summary>
        /// The logger for the current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The Bugsnag client used for reporting exceptions.
        /// </summary>
        public static Client Bugsnag = null;
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
        public static FormHome HomeForm = null;
        /// <summary>
        /// Form that allows the user to configure the application.
        /// </summary>
        public static FormConfig ConfigForm = null;

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

            // If this is the first time that the program has been launched
            if (Config.FirstLaunch)
            {
                // Ask for consent to use Bugsnag (you know, GDPR)
                DialogResult result = MessageBox.Show(Resources.BugsnagConsent, Resources.BugsnagConsentTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // And save the answer
                Config.Bugsnag = result == DialogResult.Yes;

                // Once we are done, save the configuration
                Config.FirstLaunch = false;
                Config.Save();
            }

            // If Bugsnag is enabled, create the client and save it if we need it
            if (Config.Bugsnag)
            {
                Bugsnag = new Client(new Bugsnag.Configuration("05841a867334bebcf5e3a9898c5a5191"));
            }

            // Log that we are creating a new instance of the form
            Logger.Trace(Resources.FormCreatingLog);
            // Create the forms
            HomeForm = new FormHome();
            ConfigForm = new FormConfig();
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
