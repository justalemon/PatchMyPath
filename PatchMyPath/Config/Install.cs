using Newtonsoft.Json;
using System.IO;
using System.Text;

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
                else if (File.Exists(Path.Combine(GamePath, "GTA5.exe")) && File.Exists(Path.Combine(GamePath, "GTAVLauncherBypass.asi")) && !Program.Config.Steam.GTAVUse)
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

        public override string ToString()
        {
            return $"{GamePath} [{Game.ToString().SpaceOnUpperCase()}] [{Type}]";
        }
    }
}
