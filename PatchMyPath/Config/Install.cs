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

        /// <summary>
        /// Starts the executable for the specified game.
        /// </summary>
        /// <param name="game">The game to launch.</param>
        public void StartExecutable(Game game)
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
