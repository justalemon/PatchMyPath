using NLog;
using PatchMyPath.Properties;
using PatchMyPath.Tools;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PatchMyPath.Config
{
    /// <summary>
    /// Specifies the information for launching a GTA V install.
    /// </summary>
    public class Install
    {
        /// <summary>
        /// The logger for the current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The path of the new game install.
        /// </summary>
        public string GamePath { get; set; }
        /// <summary>
        /// The game that this install contains.
        /// </summary>
        public Game Game
        {
            get
            {
                // If the respective game executables is present
                if (File.Exists(Path.Combine(GamePath, "RDR2.exe")))
                {
                    return Game.RedDeadRedemption2;
                }
                else if (File.Exists(Path.Combine(GamePath, "GTAIV.exe")) || File.Exists(Path.Combine(GamePath, "LaunchGTAIV.exe")))
                {
                    return Game.GrandTheftAutoIV;
                }
                else if (File.Exists(Path.Combine(GamePath, "GTA5.exe")))
                {
                    return Game.GrandTheftAutoV;
                }
                else
                {
                    return Game.Invalid;
                }
            }
        }
        /// <summary>
        /// The type of game installation.
        /// </summary>
        public Launch Type
        {
            get
            {
                switch (Game)
                {
                    case Game.RedDeadRedemption2:
                        if (File.Exists(Path.Combine(GamePath, "RedHook2", "Loader.exe")))
                        {
                            return Launch.RedHook2;
                        }
                        else if (File.Exists(Path.Combine(GamePath, "ScriptHook", "rdr2d.exe")))
                        {
                            return Launch.ScriptHook;
                        }
                        else if (File.Exists(Path.Combine(GamePath, "RDR2.exe")))
                        {
                            return Launch.Normal;
                        }
                        break;
                    case Game.GrandTheftAutoIV:
                        if (File.Exists(Path.Combine(GamePath, "LaunchGTAIV.exe")) || File.Exists(Path.Combine(GamePath, "GTAIV.exe")))
                        {
                            return Launch.Normal;
                        }
                        break;
                    case Game.GrandTheftAutoV:
                        if (File.Exists(Path.Combine(GamePath, "RAGEPluginHook.exe")))
                        {
                            return Launch.RagePluginHook;
                        }
                        else if (File.Exists(Path.Combine(GamePath, "GTA5.exe")) && File.Exists(Path.Combine(GamePath, "GTAVLauncherBypass.asi")))
                        {
                            return Launch.LauncherBypass;
                        }
                        else if (File.Exists(Path.Combine(GamePath, "GTAVLauncher.exe")) || File.Exists(Path.Combine(GamePath, "PlayGTAV.exe")))
                        {
                            return Launch.Normal;
                        }
                        break;
                }
                return Launch.Invalid;
            }
        }
        /// <summary>
        /// If the game executables are tampered or not.
        /// </summary>
        public bool IsLegal
        {
            get
            {
                switch (Game)
                {
                    case Game.RedDeadRedemption2:
                        return Signatures.IsSignedByRockstar(Path.Combine(GamePath, "RDR2.exe"));
                    case Game.GrandTheftAutoIV:
                        return Signatures.IsSignedByRockstar(Path.Combine(GamePath, "GTAIV.exe")) || Signatures.IsSignedByRockstar(Path.Combine(GamePath, "gta4Browser.exe"));
                    case Game.GrandTheftAutoV:
                        return Signatures.IsSignedByRockstar(Path.Combine(GamePath, "GTA5.exe"));
                    default:
                        return false;
                }
            }
        }

        public Install(string path)
        {
            GamePath = path;
        }

        public void Start()
        {
            // Get the game
            Game game = Game;
            // And start it with the default parameters
            Start(Type, Program.Config.Launchers.GetLauncher(game), game);
        }

        public void Start(Launch type, LauncherType launcher)
        {
            // Launches the game with the specified type and launcher
            Start(type, launcher, Game);
        }

        public void Start(Launch type, LauncherType launcher, Game game)
        {
            // If the install has been tampered, notify the user and return
            if (!IsLegal)
            {
                Logger.Error(Resources.InstallTamperedLog, GamePath);
                MessageBox.Show(Resources.InstallTampered, Resources.InstallTamperedTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // If the type is set to Invalid, notify the user and return
            else if (type == Launch.Invalid)
            {
                Logger.Error(Resources.InstallInvalidLog);
                MessageBox.Show(Resources.InstallInvalid, Resources.InstallInvalidTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // If the game is set to Invalid, notify the user and return
            else if (game == Game.Invalid)
            {
                Logger.Error(Resources.InstallNoExecutableLog);
                MessageBox.Show(Resources.InstallNoExecutable, Resources.InstallNoExecutableTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the correct directory for the game
            string directory = Program.Config.Destination.GetDestination(game);
            // If the target directory is null, the game is invallid
            if (string.IsNullOrWhiteSpace(directory))
            {
                Logger.Error(Resources.InstallWrongGameLog, game, (int)game);
                MessageBox.Show(string.Format(Resources.InstallWrongGame, game.ToString().SpaceOnUpperCase()), Resources.InstallWrongGameTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Terminate the game launcher if required
            if (Program.Config.CloseLaunchers)
            {
                LauncherManager.Stop(launcher);
                if ((game == Game.GrandTheftAutoIV || game == Game.GrandTheftAutoV || game == Game.RedDeadRedemption2) && launcher != LauncherType.RockstarGamesLauncher)
                {
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
                Links.CreateSymbolicLink(directory, GamePath, 3); // 3 means Directory (0x1) and Unprivileged/Dev Mode (0x2)
            }
            // If we failed, print the respective error message and return
            catch (Win32Exception er)
            {
                Logger.Error(Resources.SymbolicLinkErrorLog, directory, GamePath);
                MessageBox.Show(string.Format(Resources.SymbolicLinkError, er.Message), Resources.SymbolicLinkErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // TIME TO LAUNCH THE GAME!

            // If the user wants ScriptHook for Red Dead Redemption 2, launch it as-it and let it do the heavy work
            if (type == Launch.ScriptHook)
            {
                Logger.Info(Resources.StartingScriptHookLog, GamePath);
                Process.Start(Path.Combine(Program.Config.Destination.RDR2, "ScriptHook", "rdr2d.exe"));
                return;
            }
            // For Rage Plugin Hook, launch the executable and let it do it's job
            else if (type == Launch.RagePluginHook)
            {
                Logger.Info(Resources.StartingRPHLog, GamePath);
                using (Process rph = new Process())
                {
                    rph.StartInfo.FileName = Path.Combine(Program.Config.Destination.GTAV, "RAGEPluginHook.exe");
                    rph.StartInfo.WorkingDirectory = Program.Config.Destination.GTAV;
                    rph.Start();
                }
                return;
            }
            // For alloc8or's Launcher Bypass for pre-RGL copies, just use GTA5.exe
            else if (type == Launch.LauncherBypass)
            {
                Logger.Info(Resources.StartingLauncherBypassLog, GamePath);
                Process.Start(Path.Combine(Program.Config.Destination.GTAV, "GTA5.exe"));
                return;
            }

            // If none of the previous options are needed, launch the game like normal
            switch (launcher)
            {
                // For Steam, use the Network Protocol
                case LauncherType.Steam:
                    ulong steam = Program.Config.Launchers.GetSteamAppID(game);
                    Logger.Info(Resources.StartingRDR2SteamLog, GamePath);
                    Process.Start($"steam://rungameid/{steam}");
                    break;
                // For EGS, also use the Network Protocol
                case LauncherType.EpicGamesStore:
                    string epic = Program.Config.Launchers.GetEpicID(game);
                    Logger.Info(Resources.StartingRDR2SteamLog, GamePath, epic);
                    Process.Start($"com.epicgames.launcher://apps/{epic}?action=launch&silent=true");
                    break;
                // For everything else, use the executable directly
                case LauncherType.Executable:
                case LauncherType.RockstarGamesLauncher:
                    StartExecutable(game);
                    break;
            }

            // If the user wants RedHook2, launch it after the game
            if (type == Launch.RedHook2)
            {
                Logger.Info(Resources.StartingRedHookLog, GamePath);
                Process.Start(Path.Combine(Program.Config.Destination.RDR2, "RedHook2", "Loader.exe"));
            }
        }

        /// <summary>
        /// Starts the executable for the specified game.
        /// </summary>
        /// <param name="game">The game to launch.</param>
        private void StartExecutable(Game game)
        {
            switch (game)
            {
                // For RDR2, just use RDR2.exe
                case Game.RedDeadRedemption2:
                    Logger.Info(Resources.StartingRDR2VanillaLog, GamePath);
                    Process.Start(Path.Combine(Program.Config.Destination.RDR2, "RDR2.exe"));
                    break;
                // For GTA IV, use PlayGTAIV.exe (Steam re-release) or LaunchGTAIV.exe (retail and Patch 7 on Steam)
                case Game.GrandTheftAutoIV:
                    if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "PlayGTAIV.exe")))
                    {
                        Process.Start(Path.Combine(Program.Config.Destination.GTAV, "PlayGTAIV.exe"));
                    }
                    else if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "LaunchGTAIV.exe")))
                    {
                        Process.Start(Path.Combine(Program.Config.Destination.GTAV, "LaunchGTAIV.exe"));
                    }
                    break;
                // For GTA V, use GTAVLauncher.exe (R* Warehouse/Launcher) or PlayGTAV.exe (Steam and EGL)
                case Game.GrandTheftAutoV:

                    if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "GTAVLauncher.exe")))
                    {
                        Process.Start(Path.Combine(Program.Config.Destination.GTAV, "GTAVLauncher.exe"));
                    }
                    else if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "PlayGTAV.exe")))
                    {
                        Process.Start(Path.Combine(Program.Config.Destination.GTAV, "PlayGTAV.exe"));
                    }
                    return;
            }
        }

        public override string ToString() => $"{GamePath} [{Game.ToString().SpaceOnUpperCase()}] [{Type}]";
    }
}
