using Newtonsoft.Json;
using NLog;
using PatchMyPath.Properties;
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
                        return Checks.IsFileSignedByRockstar(Path.Combine(GamePath, "RDR2.exe"));
                    case Game.GrandTheftAutoIV:
                        return Checks.IsFileSignedByRockstar(Path.Combine(GamePath, "GTAIV.exe")) || Checks.IsFileSignedByRockstar(Path.Combine(GamePath, "gta4Browser.exe"));
                    case Game.GrandTheftAutoV:
                        return Checks.IsFileSignedByRockstar(Path.Combine(GamePath, "GTA5.exe"));
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
            // If the install has been tampered, notify the user and return
            if (!IsLegal)
            {
                Logger.Error(Resources.InstallTamperedLog, GamePath);
                MessageBox.Show(Resources.InstallTampered, Resources.InstallTamperedTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // If the type is set to Invalid, notify the user and return
            else if (Type == Launch.Invalid)
            {
                Logger.Error(Resources.InstallInvalidLog);
                MessageBox.Show(Resources.InstallInvalid, Resources.InstallInvalidTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // If the game is set to Invalid, notify the user and return
            else if (Game == Game.Invalid)
            {
                Logger.Error(Resources.InstallNoExecutableLog);
                MessageBox.Show(Resources.InstallNoExecutable, Resources.InstallNoExecutableTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the correct directory for the game
            string directory;
            if (Game == Game.RedDeadRedemption2)
            {
                directory = Program.Config.Destination.RDR2;
            }
            else if (Game == Game.GrandTheftAutoV)
            {
                directory = Program.Config.Destination.GTAV;
            }
            else
            {
                Logger.Error(Resources.InstallWrongGameLog, Game, (int)Game);
                MessageBox.Show(Resources.InstallWrongGame, Resources.InstallWrongGameTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

            // Finally, launch the game
            switch (Game)
            {
                // If this is RDR2
                case Game.RedDeadRedemption2:
                    LaunchRDR2();
                    break;
                // If this is GTA V
                case Game.GrandTheftAutoV:
                    LaunchGTAV();
                    break;
            }
        }

        /// <summary>
        /// Launches Red Dead Redemption 2.
        /// </summary>
        public void LaunchRDR2()
        {
            // Get the launch type
            Launch type = Type;

            // If the user wants ScriptHook for Red Dead Redemption 2, launch it as-it and let it do the heavy work
            if (type == Launch.ScriptHook)
            {
                Logger.Info(Resources.StartingScriptHookLog, GamePath);
                Process.Start(Path.Combine(Program.Config.Destination.RDR2, "ScriptHook", "rdr2d.exe"));
                return;
            }

            // Launch the game with the correct manager
            switch (Program.Config.Launchers.RDR2Use)
            {
                // For Steam, use the Network Protocol
                case LauncherType.Steam:
                    Logger.Info(Resources.StartingRDR2SteamLog, GamePath);
                    Process.Start($"steam://rungameid/{Program.Config.Launchers.RDR2SteamID}");
                    break;
                // For EGS, also use the Network Protocol
                case LauncherType.EpicGamesStore:
                    Logger.Info(Resources.StartingRDR2SteamLog, GamePath);
                    Process.Start($"com.epicgames.launcher://apps/{Program.Config.Launchers.RDR2EpicID}?action=launch&silent=true");
                    break;
                // For everything else, use the executable directly
                default:
                    Logger.Info(Resources.StartingRDR2VanillaLog, GamePath);
                    Process.Start(Path.Combine(Program.Config.Destination.RDR2, "RDR2.exe"));
                    break;
            }

            // If the user wants RedHook2, launch it after the game executable
            if (type == Launch.RedHook2)
            {
                Logger.Info(Resources.StartingRedHookLog, GamePath);
                Process.Start(Path.Combine(Program.Config.Destination.RDR2, "RedHook2", "Loader.exe"));
            }
        }

        /// <summary>
        /// Launches Grand Theft Auto V.
        /// </summary>
        public void LaunchGTAV()
        {
            // For special types, launch them directly
            switch (Type)
            {
                // For RPH, launch the executable from the same directory as the game
                case Launch.RagePluginHook:
                    Logger.Info(Resources.StartingRPHLog, GamePath);
                    using (Process rph = new Process())
                    {
                        rph.StartInfo.FileName = Path.Combine(Program.Config.Destination.GTAV, "RAGEPluginHook.exe");
                        rph.StartInfo.WorkingDirectory = Program.Config.Destination.GTAV;
                        rph.Start();
                    }
                    return;
                // For Unknown's Launcher Bypass, use GTA5.exe Directly
                case Launch.LauncherBypass:
                    Logger.Info(Resources.StartingLauncherBypassLog, GamePath);
                    Process.Start(Path.Combine(Program.Config.Destination.GTAV, "GTA5.exe"));
                    return;
            }

            // Launch the game with the correct manager
            switch (Program.Config.Launchers.GTAVUse)
            {
                // For Steam, use the Network Protocol
                case LauncherType.Steam:
                    Logger.Info(Resources.StartingGTAVSteamLog, GamePath);
                    Process.Start($"steam://rungameid/{Program.Config.Launchers.GTAVSteamID}");
                    break;
                // For EGS, also use the Network Protocol
                case LauncherType.EpicGamesStore:
                    Logger.Info(Resources.StartingGTAVSteamLog, GamePath);
                    Process.Start($"com.epicgames.launcher://apps/{Program.Config.Launchers.GTAVEpicID}?action=launch&silent=true");
                    break;
                // For everything else, use either GTAVLauncher.exe or PlayGTAV.exe
                default:
                    Logger.Info(Resources.StartingGTAVVanillaLog, GamePath);
                    if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "GTAVLauncher.exe")))
                    {
                        Process.Start(Path.Combine(Program.Config.Destination.GTAV, "GTAVLauncher.exe"));
                    }
                    else if (File.Exists(Path.Combine(Program.Config.Destination.GTAV, "PlayGTAV.exe")))
                    {
                        Process.Start(Path.Combine(Program.Config.Destination.GTAV, "PlayGTAV.exe"));
                    }
                    break;
            }
        }

        public override string ToString() => $"{GamePath} [{Game.ToString().SpaceOnUpperCase()}] [{Type}]";
    }
}
