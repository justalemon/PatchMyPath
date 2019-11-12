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
        /// The settings for the usage of Steam for launching the game..
        /// </summary>
        [JsonProperty("steam")]
        public Steam Steam { get; set; } = new Steam();
        /// <summary>
        /// The destination folder for the game files.
        /// </summary>
        [JsonProperty("destination")]
        public Destinations Destination { get; set; } = new Destinations();
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
                Process.Start(Path.Combine(Destination.RDR2, "RDR2.exe"));
            }
            // GTA V on the other hand, has a lot
            else if (game == Game.GrandTheftAutoV)
            {
                // If the launch type is set to RPH, launch RPH
                if (type == Launch.RagePluginHook)
                {
                    using (Process rph = new Process())
                    {
                        rph.StartInfo.FileName = Path.Combine(Destination.GTAV, "RAGEPluginHook.exe");
                        rph.StartInfo.WorkingDirectory = Destination.GTAV;
                        rph.Start();
                    }
                }
                // If Unknown's Launcher Bypass is enabled and we don't need to use Steam
                else if (type == Launch.LauncherBypass && !Steam.GTAVUse)
                {
                    Process.Start(Path.Combine(Destination.GTAV, "GTA5.exe"));
                }
                // Otherwise, launch the game as normal
                else if (type == Launch.Normal || (type == Launch.LauncherBypass && Steam.GTAVUse))
                {
                    // If Steam is enabled, use the specified App ID
                    if (Steam.GTAVUse)
                    {
                        Process.Start($"steam://rungameid/{Steam.GTAVAppID}");
                    }
                    // If not, use the Launcher file
                    else
                    {
                        Process.Start(Path.Combine(Destination.GTAV, "GTAVLauncher.exe"));
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
