using NLog;
using PatchMyPath.Config;
using PatchMyPath.Properties;
using PatchMyPath.Tools;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PatchMyPath
{
    /// <summary>
    /// Form used to start the installs.
    /// </summary>
    public partial class FormStartup : Form
    {
        #region Fields

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static Thread thread = null;
        internal Launch launch = 0;
        internal LauncherType type = 0;
        internal bool ok = false;

        #endregion

        #region Constructor

        private FormStartup(Install install, Launch launch, LauncherType type)
        {
            // Initialize the UI elements
            InitializeComponent();
            // Log the operation
            logger.Info(Resources.FormLaunchingLog, install.GamePath);
            // And set some basic options
            this.launch = launch;
            this.type = type;
            thread = new Thread(() => ThreadWork(install));
            Text = "Starting " + install.Game.ToString().SpaceOnUpperCase();
        }

        #endregion

        #region Functions

        public static bool Start(Install install) => Start(install, install.Type);
        public static bool Start(Install install, Launch launch) => Start(install, launch, Program.Config.Launchers.GetLauncher(install.Game));
        public static bool Start(Install install, Launch launch, LauncherType type)
        {
            FormStartup form = new FormStartup(install, launch, type);
            form.ShowDialog();
            return form.ok;
        }

        private void ThreadWork(Install install)
        {
            Work(install);
            Invoke(new Action(() => Close()));
        }
        private void Work(Install install)
        {
            // Get the game and launcher of the install
            Game game = install.Game;

            // If the install has been tampered, notify the user and return
            if (!install.IsLegal)
            {
                logger.Error(Resources.InstallTamperedLog, install.GamePath);
                MessageBox.Show(Resources.InstallTampered, Resources.InstallTamperedTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // If the type is set to Invalid, notify the user and return
            else if (launch == Launch.Invalid)
            {
                logger.Error(Resources.InstallInvalidLog);
                MessageBox.Show(Resources.InstallInvalid, Resources.InstallInvalidTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // If the game is set to Invalid, notify the user and return
            else if (game == Game.Invalid)
            {
                logger.Error(Resources.InstallNoExecutableLog);
                MessageBox.Show(Resources.InstallNoExecutable, Resources.InstallNoExecutableTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Get the correct directory for the game
            string directory = Program.Config.Destination.GetDestination(game);
            // If the target directory is null, the game is invallid
            if (string.IsNullOrWhiteSpace(directory))
            {
                logger.Error(Resources.InstallWrongGameLog, game, (int)game);
                MessageBox.Show(string.Format(Resources.InstallWrongGame, game.ToString().SpaceOnUpperCase()), Resources.InstallWrongGameTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Don't manipulate the path or launcher if we have the correct path set up already
            if (!Directory.Exists(directory) || Path.GetFullPath(Links.GetRealPath(directory)) != Path.GetFullPath(install.GamePath))
            {
                // Terminate the game launcher if required
                if (Program.Config.CloseLaunchers)
                {
                    Invoke(new Action(() => CurrentOperation.Text = "Stopping " + type.ToString().SpaceOnUpperCase()));
                    LauncherManager.Stop(type);

                    if ((game == Game.GrandTheftAutoIV || game == Game.GrandTheftAutoV || game == Game.RedDeadRedemption2) && type != LauncherType.RockstarGamesLauncher)
                    {
                        Invoke(new Action(() => CurrentOperation.Text = "Stopping " + LauncherType.RockstarGamesLauncher.ToString().SpaceOnUpperCase()));
                        LauncherManager.Stop(LauncherType.RockstarGamesLauncher);
                    }
                }

                // Now, destroy the original game folder if is present
                if (Directory.Exists(directory))
                {
                    Directory.Delete(directory);
                }

                // Try to create the symbolic link
                try
                {
                    Links.CreateSymbolicLink(directory, install.GamePath, 3); // 3 means Directory (0x1) and Unprivileged/Dev Mode (0x2)
                }
                // If we failed, print the respective error message and return
                catch (Win32Exception er)
                {
                    logger.Error(Resources.SymbolicLinkErrorLog, directory, install.GamePath);
                    MessageBox.Show(string.Format(Resources.SymbolicLinkError, er.Message), Resources.SymbolicLinkErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // TIME TO LAUNCH THE GAME!
            Invoke(new Action(() => CurrentOperation.Text = "Launching " + game.ToString().SpaceOnUpperCase()));

            // For Rage Plugin Hook, launch the executable and let it do it's job
            if (launch == Launch.RagePluginHook)
            {
                logger.Info(Resources.StartingRPHLog, install.GamePath);
                using (Process rph = new Process())
                {
                    rph.StartInfo.FileName = Path.Combine(Program.Config.Destination.GTAV, "RAGEPluginHook.exe");
                    rph.StartInfo.WorkingDirectory = Program.Config.Destination.GTAV;
                    rph.Start();
                }
                return;
            }
            // For alloc8or's Launcher Bypass for pre-RGL copies, just use GTA5.exe
            else if (launch == Launch.LauncherBypass && (type == LauncherType.RockstarGamesLauncher || type == LauncherType.Executable))
            {
                logger.Info(Resources.StartingLauncherBypassLog, install.GamePath);
                Process.Start(Path.Combine(Program.Config.Destination.GTAV, "GTA5.exe"));
                return;
            }

            // If none of the previous options are needed, launch the game like normal
            switch (type)
            {
                // For Steam, use the Network Protocol
                case LauncherType.Steam:
                    ulong steam = Program.Config.Launchers.GetSteamAppID(game);
                    logger.Info(Resources.StartingRDR2SteamLog, install.GamePath);
                    Process.Start($"steam://rungameid/{steam}");
                    break;
                // For EGS, also use the Network Protocol
                case LauncherType.EpicGamesStore:
                    string epic = Program.Config.Launchers.GetEpicID(game);
                    logger.Info(Resources.StartingRDR2SteamLog, install.GamePath, epic);
                    Process.Start($"com.epicgames.launcher://apps/{epic}?action=launch&silent=true");
                    break;
                // For everything else, use the executable directly
                case LauncherType.Executable:
                case LauncherType.RockstarGamesLauncher:
                    Process.Start(install.Executable);
                    break;
            }
        }

        #endregion

        #region Events

        private void FormStartup_Shown(object sender, EventArgs e) => thread.Start();

        #endregion
    }
}
