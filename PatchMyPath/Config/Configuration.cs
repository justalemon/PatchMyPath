using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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
        public void Start(Install install)
        {
            // Get the game and install type
            Game game = install.Game;
            Launch type = install.Type;

            // If the game is RDR2, we can only launch the game directly from the exe
            if (game == Game.RedDeadRedemption2)
            {
                Process.Start(Path.Combine(Destination, "RDR2.exe"));
            }
            // GTA V on the other hand, has a lot
            else if (game == Game.GrandTheftAutoV)
            {
                // If the launch type is set to RPH, launch RPH
                if (type == Launch.RagePluginHook)
                {
                    using (Process rph = new Process())
                    {
                        rph.StartInfo.FileName = Path.Combine(Destination, "RAGEPluginHook.exe");
                        rph.StartInfo.WorkingDirectory = Destination;
                        rph.Start();
                    }
                }
                // If Unknown's Launcher Bypass is enabled and we don't need to use Steam
                else if (type == Launch.LauncherBypass && !UseSteam)
                {
                    Process.Start(Path.Combine(Destination, "GTA5.exe"));
                }
                // Otherwise, launch the game as normal
                else if (type == Launch.Normal || (type == Launch.LauncherBypass && UseSteam))
                {
                    // If Steam is enabled, use the specified App ID
                    if (UseSteam)
                    {
                        Process.Start($"steam://rungameid/{AppID}");
                    }
                    // If not, use the Launcher file
                    else
                    {
                        Process.Start(Path.Combine(Destination, "GTAVLauncher.exe"));
                    }
                }
            }
            // If we managed to get here, either the game or options are invalid
            else
            {
                MessageBox.Show("We were unable to start the game.\nPlease check that the selected install is valid and try again.", "Invalid Install", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
