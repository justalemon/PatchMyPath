using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatchMyPath
{
    /// <summary>
    /// The type of game installation.
    /// </summary>
    public enum InstallType
    {
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
        public string Path { get; set; }
        /// <summary>
        /// The type of game installation.
        /// </summary>
        public InstallType Type { get; set; }
    }

    /// <summary>
    /// The basic configuration information.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// If the game should be started from Steam instead of the executable.
        /// </summary>
        [JsonProperty("steam")]
        public bool Steam { get; set; }
        /// <summary>
        /// The destination folder for the game files.
        /// </summary>
        [JsonProperty("destination")]
        public string Destination { get; set; }
        /// <summary>
        /// The game installs available to the user.
        /// </summary>
        [JsonProperty("installs")]
        public List<Install> GameInstalls { get; set; }
    }
}
