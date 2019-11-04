using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace PatchMyPath
{
    /// <summary>
    /// The type of game installation.
    /// </summary>
    public enum InstallType
    {
        /// <summary>
        /// This installation is invalid and can't be used.
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// Detect the type of executable to launch.
        /// </summary>
        AutoDetect = 0,
        /// <summary>
        /// Launch the game from GTAVLauncher.exe
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Launch the game from GTA5.exe if GTAVLauncherBypass.asi exists.
        /// </summary>
        LauncherBypass = 2,
        /// <summary>
        /// Launch the game from RAGEPluginHook.exe if present.
        /// </summary>
        RagePluginHook = 3,
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
        /// The type of game installation.
        /// </summary>
        public InstallType Type
        {
            get
            {
                // If there is a RagePluginHook.exe on the folder, this is RPH
                if (File.Exists(Path.Combine(GamePath, "RAGEPluginHook.exe")))
                {
                    return InstallType.RagePluginHook;
                }
                // If there is a GTA5.exe and GTAVLauncherBypass.asi but is not from Steam, let the user start via Unknown's Magic Tool
                else if (File.Exists(Path.Combine(GamePath, "GTA5.exe")) && File.Exists(Path.Combine(GamePath, "GTAVLauncherBypass.asi")) && !Program.Config.UseSteam)
                {
                    return InstallType.LauncherBypass;
                }
                // If we got here, there is no alternative way to launch the game other than 
                else if (File.Exists(Path.Combine(GamePath, "GTAVLauncher.exe")))
                {
                    return InstallType.Normal;
                }
                // Also, if there is no executable just mark the install as invalid
                else
                {
                    return InstallType.Invalid;
                }
            }
        }
        /// <summary>
        /// If the files are legal (aka signed by Rockstar Games).
        /// </summary>
        [JsonIgnore]
        public bool IsLegal => Checks.AreExecutablesSignedByRockstar(this);

        public Install(string path)
        {
            GamePath = path;
        }

        public override string ToString()
        {
            return $"{GamePath} ({Type})";
        }
    }

    /// <summary>
    /// The basic configuration information.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// If the game should be started from Steam instead of the executable.
        /// </summary>
        [JsonProperty("use_steam")]
        public bool UseSteam { get; set; } = false;
        /// <summary>
        /// The Steam AppID used to launch the game.
        /// </summary>
        [JsonProperty("appid")]
        public uint AppID { get; set; } = 271590;
        /// <summary>
        /// Checks the signature of the executable to make sure that is valid.
        /// </summary>
        [JsonProperty("check_sig")]
        public bool CheckSignature { get; set; } = true;
        /// <summary>
        /// The destination folder for the game files.
        /// </summary>
        [JsonProperty("destination", NullValueHandling = NullValueHandling.Ignore)]
        public string Destination { get; set; } = "";
        /// <summary>
        /// The game installs available to the user.
        /// </summary>
        [JsonProperty("installs", NullValueHandling = NullValueHandling.Ignore)]
        public List<Install> GameInstalls { get; set; } = new List<Install>();

        /// <summary>
        /// Starts the game from the Destination folder.
        /// </summary>
        public bool Start(InstallType type)
        {
            // At this point launch the game
            if (type == InstallType.RagePluginHook)
            {
                using (Process rph = new Process())
                {
                    rph.StartInfo.FileName = Path.Combine(Destination, "RAGEPluginHook.exe");
                    rph.StartInfo.WorkingDirectory = Destination;
                    rph.Start();
                }
            }
            else if (type == InstallType.LauncherBypass && !UseSteam)
            {
                Process.Start(Path.Combine(Destination, "GTA5.exe"));
            }
            else if (type == InstallType.Normal || (type == InstallType.LauncherBypass && UseSteam))
            {
                if (UseSteam)
                {
                    Process.Start($"steam://rungameid/{AppID}");
                }
                else
                {
                    Process.Start(Path.Combine(Destination, "GTAVLauncher.exe"));
                }
            }
            else
            {
                Console.WriteLine("Invalid game type, please check your configuration and try again.");
                return false;
            }

            // If we got here, success!
            return true;
        }
    }
}
