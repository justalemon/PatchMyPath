using Newtonsoft.Json;

namespace PatchMyPath.Config
{
    /// <summary>
    /// The type of launcher for the game.
    /// </summary>
    public enum LauncherType
    {
        Executable = 0,
        RockstarGamesLauncher = 1,
        Steam = 2,
        EpicGamesStore = 3
    }

    /// <summary>
    /// THe configuration for using specific game launchers with RDR2 and GTA V.
    /// </summary>
    public class Launchers
    {
        /// <summary>
        /// What launch system should Red Dead Redemption 2 use to start the game.
        /// </summary>
        [JsonProperty("rdr2_use")]
        public LauncherType RDR2Use { get; set; } = LauncherType.Executable;
        /// <summary>
        /// The Steam AppID to use for launching Red Dead Redemption 2.
        /// </summary>
        [JsonProperty("rdr2_steam_id")]
        public ulong RDR2SteamID { get; set; } = 1174180;
        /// <summary>
        /// The EGS Identifier to use for launching Red Dead Redemption 2.
        /// </summary>
        [JsonProperty("rdr2_epic_id")]
        public string RDR2EpicID { get; set; } = "Heather";

        /// <summary>
        /// If Grand Theft Auto V should use Steam to launch the game.
        /// </summary>
        [JsonProperty("gtav_use")]
        public LauncherType GTAVUse { get; set; } = LauncherType.Executable;
        /// <summary>
        /// What launch system should Grand Theft Auto V use to start the game.
        /// </summary>
        [JsonProperty("gtav_steam_id")]
        public ulong GTAVSteamID { get; set; } = 271590;
        /// <summary>
        /// The EGS Identifier to use for launching Grand Theft Auto V.
        /// </summary>
        [JsonProperty("gtav_epic_id")]
        public string GTAVEpicID { get; set; } = "9d2d0eb64d5c44529cece33fe2a46482";
    }
}
