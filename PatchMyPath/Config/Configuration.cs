using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PatchMyPath.Config
{
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
        [JsonProperty("app_id")]
        public uint AppID { get; set; } = 271590;
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
            else if (type == InstallType.NormalGTAV || (type == InstallType.LauncherBypass && UseSteam))
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
