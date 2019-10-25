using Newtonsoft.Json;
using PatchMyPath.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;

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
        [JsonProperty("path")]
        public string GamePath { get; set; }
        /// <summary>
        /// The type of game installation.
        /// </summary>
        [JsonProperty("type")]
        public InstallType Type { get; set; }
        /// <summary>
        /// If the files are legal (aka signed by Rockstar Games).
        /// </summary>
        public bool IsLegal
        {
            get
            {
                // Create the path of the 
                string launcherPath = Path.Combine(GamePath, "GTAVLauncher.exe");
                string executablePath = Path.Combine(GamePath, "GTA5.exe");

                // If one of the files can't be found, is not valid
                if (!File.Exists(launcherPath) || !File.Exists(executablePath))
                {
                    return false;
                }

                // Get the real paths for the launcher and executable
                string realLauncher = SymbolicLink.GetRealPath(launcherPath);
                string realExecutable = SymbolicLink.GetRealPath(executablePath);
                // Get the certificate that signed both of them
                X509Certificate launcherCert = X509Certificate.CreateFromSignedFile(realLauncher);
                X509Certificate executableCert = X509Certificate.CreateFromSignedFile(realExecutable);

                // If one of those don't have a valid signature, return false
                if (launcherCert == null || executableCert == null)
                {
                    return false;
                }

                // Get the hashes of both files
                string launcherHash = launcherCert.GetCertHashString();
                string executableHash = executableCert.GetCertHashString();

                // If the signature is by Rockstar Games
                // (This is done to avoid self-signed files)
                if (launcherHash == "AA0D31A9C8C1EBD9E18EC1D8D3F98B3523178AD8" &&
                    executableHash == "AA0D31A9C8C1EBD9E18EC1D8D3F98B3523178AD8")
                {
                    return true;
                }
                // Otherwise, return false
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Updates the Install.Type based on the contents of the game install.
        /// </summary>
        public void UpdateType(bool isSteamLaunched)
        {
            // If there is a RagePluginHook.exe on the folder, this is RPH
            if (File.Exists(Path.Combine(GamePath, "RAGEPluginHook.exe")))
            {
                Type = InstallType.RagePluginHook;
            }
            // If there is a GTA5.exe and GTAVLauncherBypass.asi but is not from Steam, let the user start via Unknown's Magic Tool
            else if (File.Exists(Path.Combine(GamePath, "GTA5.exe")) && File.Exists(Path.Combine(GamePath, "GTAVLauncherBypass.asi")) && !isSteamLaunched)
            {
                Type = InstallType.LauncherBypass;
            }
            // If we got here, there is no alternative way to launch the game other than 
            else if (File.Exists(Path.Combine(GamePath, "GTAVLauncher.exe")))
            {
                Type = InstallType.Normal;
            }
            // Also, if there is no executable just mark the install as invalid
            else
            {
                Type = InstallType.Invalid;
            }
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
        public bool UseSteam { get; set; }
        /// <summary>
        /// The Steam AppID used to launch the game.
        /// </summary>
        [JsonProperty("appid")]
        public uint AppID { get; set; }
        /// <summary>
        /// Checks the signature of the executable to make sure that is valid.
        /// </summary>
        [JsonProperty("check_sig")]
        public bool CheckSignature { get; set; }
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

        /// <summary>
        /// Starts the game from the Destination folder.
        /// </summary>
        public bool Start(InstallType type)
        {
            // At this point launch the game
            if (type == InstallType.RagePluginHook)
            {
                Process.Start(Path.Combine(Destination, "RAGEPluginHook.exe"));
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
