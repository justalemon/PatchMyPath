using Bugsnag;
using CommandLine;
using Lemon.NLog.WinForms;
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
        public static int Main(string[] args)
        {
            // Check for valid command line parameters and start a specific install if needed
            ParserResult<LaunchParameters> parserResult = Parser.Default.ParseArguments<LaunchParameters>(args);

            if (parserResult.Tag == ParserResultType.Parsed)
            {
                LaunchParameters parameters = null;
                parserResult.WithParsed(x => parameters = x);

                if (!Directory.Exists(parameters.Launch))
                {
                    MessageBox.Show(string.Format(Resources.CLIDirectoryMissing, parameters.Launch), Resources.CLIDirectoryMissingTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 2;
                }

                Install install = new Install(parameters.Launch);

                if (parameters.Add && !Config.GameInstalls.Contains(install))
                {
                    Config.GameInstalls.Add(install);
                    Config.Save();
                }

                if (!Config.GameInstalls.Contains(install))
                {
                    MessageBox.Show(string.Format(Resources.CLIDirectoryNotAdded, parameters.Launch), Resources.CLIDirectoryNotAddedTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 3;
                }

                FormStartup.Start(install);

                return 0;
            }

            // If there are none, just run the app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentUICulture = Config.Language;

            if (Config.FirstLaunch)
            {
                // Ask for consent to use Bugsnag (you know, GDPR)
                DialogResult result = MessageBox.Show(Resources.BugsnagConsent, Resources.BugsnagConsentTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Config.Bugsnag = result == DialogResult.Yes;

                Config.FirstLaunch = false;
                Config.Save();
            }

            if (Config.Bugsnag)
            {
                Bugsnag = new Client(new Bugsnag.Configuration("05841a867334bebcf5e3a9898c5a5191"));
            }

            Logger.Trace(Resources.FormCreatingLog);

            HomeForm = new FormHome();
            ConfigForm = new FormConfig();

            Logger.Debug(Resources.FormInitEndLog);

            LoggingConfiguration config = new LoggingConfiguration();

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, new FileTarget() { FileName = "PatchMyPath.log", MaxArchiveFiles = 5, ArchiveOldFileOnStartup = true });
            config.AddRule(LogLevel.Info, LogLevel.Fatal, new TextBoxTarget(HomeForm.LogTextBox) { Layout = "[${date}] [${level}] ${message}" });
            config.AddRule(LogLevel.Info, LogLevel.Fatal, new ToolStripStatusLabelTarget(HomeForm.LogToolStripStatusLabel) { Layout = "${message}" });

            LogManager.Configuration = config;

            Application.Run(HomeForm);
            return 0;
        }
    }
}
