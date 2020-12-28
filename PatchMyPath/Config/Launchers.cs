using Newtonsoft.Json;

namespace PatchMyPath.Config
{
    /// <summary>
    /// THe configuration for using specific game launchers with RDR2 and GTA V.
    /// </summary>
    public class LaunchersConfig
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
        [JsonProperty("gtaiv_use")]
        public LauncherType GTAIVUse { get; set; } = LauncherType.Executable;
        /// <summary>
        /// The Steam appid that will be used to launch Grand Theft Auto IV.
        /// </summary>
        [JsonProperty("gtaiv_steam_id")]
        public ulong GTAIVSteamID { get; set; } = 12210;
        /// <summary>
        /// The EGS Identifier to use for launching Grand Theft Auto IV.
        /// </summary>
        [JsonProperty("gtaiv_epic_id")]
        public string GTAIVEpicID { get; set; } = "";

        /// <summary>
        /// The type of Launcher that Grand Theft Auto San Andreas should use.
        /// </summary>
        [JsonProperty("gtasa_use")]
        public LauncherType GTASAUse { get; set; } = LauncherType.Executable;
        /// <summary>
        /// The Steam appid that will be used to launch Grand Theft Auto San Andreas.
        /// </summary>
        [JsonProperty("gtasa_steam_id")]
        public ulong GTASASteamID { get; set; } = 12120;
        /// <summary>
        /// The EGS Identifier to use for launching Grand Theft Auto San Andreas.
        /// </summary>
        [JsonProperty("gtasa_epic_id")]
        public string GTASAEpicID { get; set; } = "";

        /// <summary>
        /// Gets the launcher used by a specific game.
        /// </summary>
        public LauncherType GetLauncher(Game game)
        {
            switch (game)
            {
                case Game.RedDeadRedemption2:
                    return RDR2Use;
                case Game.GrandTheftAutoIV:
                    return GTAIVUse;
                case Game.GrandTheftAutoV:
                    return GTAVUse;
                case Game.GrandTheftAutoSanAndreas:
                    return GTASAUse;
                default:
                    return (LauncherType)(-1);
            }
        }
        /// <summary>
        /// Gets the Steam App ID for the specified game.
        /// </summary>
        public ulong GetSteamAppID(Game game)
        {
            switch (game)
            {
                case Game.RedDeadRedemption2:
                    return RDR2SteamID;
                case Game.GrandTheftAutoIV:
                    return GTAIVSteamID;
                case Game.GrandTheftAutoV:
                    return GTAVSteamID;
                case Game.GrandTheftAutoSanAndreas:
                    return GTASASteamID;
                default:
                    return 0u;
            }
        }
        /// <summary>
        /// Gets the Epic Games ID for the specified game.
        /// </summary>
        public string GetEpicID(Game game)
        {
            switch (game)
            {
                case Game.RedDeadRedemption2:
                    return RDR2EpicID;
                case Game.GrandTheftAutoIV:
                    return GTAIVEpicID;
                case Game.GrandTheftAutoV:
                    return GTAVEpicID;
                case Game.GrandTheftAutoSanAndreas:
                    return GTASAEpicID;
                default:
                    return null;
            }
        }
    }
}
