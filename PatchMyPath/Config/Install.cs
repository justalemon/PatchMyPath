using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PatchMyPath.Config
{
    /// <summary>
    /// The type of game installation.
    /// </summary>
    public enum Launch
    {
        /// <summary>
        /// This installation is invalid and can't be used.
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// Launch the game from GTAVLauncher.exe.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Launch the game from GTA5.exe if GTAVLauncherBypass.asi exists.
        /// </summary>
        LauncherBypass = 1,
        /// <summary>
        /// Launch the game from RAGEPluginHook.exe if present.
        /// </summary>
        RagePluginHook = 2,
        /// <summary>
        /// Launch the game from RedHook2\Loader.exe if present.
        /// </summary>
        RedHook2 = 3,
        /// <summary>
        /// Launch the game from ScriptHook\rdr2d.exe if present.
        /// </summary>
        ScriptHookForRDR2 = 4,
    }
    /// <summary>
    /// The type of game that this install contains.
    /// </summary>
    public enum Game
    {
        /// <summary>
        /// None of the game executables are present.
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// Red Dead Redemption 2.
        /// </summary>
        RedDeadRedemption2 = 0,
        /// <summary>
        /// Grand Theft Auto V.
        /// </summary>
        GrandTheftAutoV = 1,
    }

    /// <summary>
    /// Specifies the information for launching a GTA V install.
    /// </summary>
    public class Install
    {
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
                // If there is a RagePluginHook.exe on the folder, this is RPH
                if (File.Exists(Path.Combine(GamePath, "RAGEPluginHook.exe")))
                {
                    return Launch.RagePluginHook;
                }
                // If there is a GTA5.exe and GTAVLauncherBypass.asi but is not from Steam, let the user start via Unknown's Magic Tool
                else if (File.Exists(Path.Combine(GamePath, "GTA5.exe")) && File.Exists(Path.Combine(GamePath, "GTAVLauncherBypass.asi")))
                {
                    return Launch.LauncherBypass;
                }
                // If we got here, there is no alternative way to launch the game other than the main executabke
                else if (File.Exists(Path.Combine(GamePath, "GTAVLauncher.exe")) || File.Exists(Path.Combine(GamePath, "RDR2.exe")))
                {
                    return Launch.Normal;
                }
                // Also, if there is no executable just mark the install as invalid
                else
                {
                    return Launch.Invalid;
                }
            }
        }
        /// <summary>
        /// If the game executables are tampered or not.
        /// </summary>
        [JsonIgnore]
        public bool IsLegal => (Checks.IsFileSignedByRockstar(Path.Combine(GamePath, "GTAVLauncher.exe")) && Checks.IsFileSignedByRockstar(Path.Combine(GamePath, "GTA5.exe"))) || Checks.IsFileSignedByRockstar(Path.Combine(GamePath, "RDR2.exe"));

        public Install(string path)
        {
            GamePath = path;
        }

        public void Start()
        {
            // If the install is invalid, notify the user and return
            if (Type == Launch.Invalid)
            {
                MessageBox.Show("We did some preliminary checks and we found that this install is invalid. Please make sure that all of the game files are present and the executables have not been modified and try again.", "Invalid Install", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("The game version is invalid!\nPlease make sure that the folder contains a copy of RDR2 or GTAV and try again.", "Invalid Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Win32Exception er)
            {
                // Print the respective error message and return
                MessageBox.Show($"An error has ocurred:\n{er.Message}", "Unable to create Symbolic Link", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Finally, launch the game
            LaunchExecutable();
        }

        public void LaunchExecutable()
        {
            // Get the game and install type
            Game game = Game;
            Launch type = Type;

            // If the game is RDR2
            if (game == Game.RedDeadRedemption2)
            {
                // If the user wants Steam and the App ID is not zero, use the Steam URL
                if (Program.Config.Steam.RDR2Use && Program.Config.Steam.RDR2AppID != 0)
                {
                    Process.Start($"steam://rungameid/{Program.Config.Steam.RDR2AppID}");
                }
                // Otherwise, just launch the exe
                else
                {
                    Process.Start(Path.Combine(Program.Config.Destination.RDR2, "RDR2.exe"));
                }
            }
            // If the game is GTA V
            else if (game == Game.GrandTheftAutoV)
            {
                // If the launch type is set to RPH, launch RPH
                if (type == Launch.RagePluginHook)
                {
                    using (Process rph = new Process())
                    {
                        rph.StartInfo.FileName = Path.Combine(Program.Config.Destination.GTAV, "RAGEPluginHook.exe");
                        rph.StartInfo.WorkingDirectory = Program.Config.Destination.GTAV;
                        rph.Start();
                    }
                }
                // If Unknown's Launcher Bypass is enabled and we don't need to use Steam
                else if (type == Launch.LauncherBypass)
                {
                    Process.Start(Path.Combine(Program.Config.Destination.GTAV, "GTA5.exe"));
                }
                // Otherwise, launch the game as normal
                else
                {
                    // If Steam is enabled, use the specified App ID
                    if (Program.Config.Steam.GTAVUse)
                    {
                        Process.Start($"steam://rungameid/{Program.Config.Steam.GTAVAppID}");
                    }
                    // If not, use the Launcher file
                    else
                    {
                        Process.Start(Path.Combine(Program.Config.Destination.GTAV, "GTAVLauncher.exe"));
                    }
                }
            }
            // If we managed to get here, either the game or options are invalid
            else
            {
                MessageBox.Show("We were unable to start the game.\nPlease check that the selected install is valid and try again.", "Invalid Install", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override string ToString()
        {
            return $"{GamePath} [{Game.ToString().SpaceOnUpperCase()}] [{Type}]";
        }
    }
}
