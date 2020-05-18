using Newtonsoft.Json;

namespace PatchMyPath.Config
{
    /// <summary>
    /// THe configuration for using specific game launchers with RDR2 and GTA V.
    /// </summary>
    public class Launchers
    {
        /// <summary>
        /// The type of Launcher that Red Dead Redemption 2 should use.
        /// </summary>
        [JsonProperty("rdr2_use")]
        public LauncherType RDR2Use { get; set; } = LauncherType.Executable;
        /// <summary>
        /// The Steam appid that will be used to launch Red Dead Redemption 2.
        /// </summary>
        [JsonProperty("rdr2_steam_id")]
        public ulong RDR2SteamID { get; set; } = 1174180;
        /// <summary>
        /// The EGS Identifier to use for launching Red Dead Redemption 2.
        /// </summary>
        [JsonProperty("rdr2_epic_id")]
        public string RDR2EpicID { get; set; } = "Heather";

        /// <summary>
        /// The type of Launcher that Grand Theft Auto IV should use.
        /// </summary>
        [JsonProperty("gtav_use")]
        public LauncherType GTAVUse { get; set; } = LauncherType.Executable;
        /// <summary>
        /// The Steam appid that will be used to launch Grand Theft Auto V.
        /// </summary>
        [JsonProperty("gtav_steam_id")]
        public ulong GTAVSteamID { get; set; } = 271590;
        /// <summary>
        /// The EGS Identifier to use for launching Grand Theft Auto V.
        /// </summary>
        [JsonProperty("gtav_epic_id")]
        public string GTAVEpicID { get; set; } = "9d2d0eb64d5c44529cece33fe2a46482";

        /// <summary>
        /// The type of Launcher that Grand Theft Auto IV should use.
        /// </summary>
        [JsonProperty("gtav_use")]
        public LauncherType GTAIVUse { get; set; } = LauncherType.Executable;
        /// <summary>
        /// The Steam appid that will be used to launch Grand Theft Auto IV.
        /// </summary>
        [JsonProperty("gtav_steam_id")]
        public ulong GTAIVSteamID { get; set; } = 271590;
        /// <summary>
        /// The EGS Identifier to use for launching Grand Theft Auto IV.
        /// </summary>
        [JsonProperty("gtav_epic_id")]
        public string GTAIVEpicID { get; set; } = "";
    }
}
