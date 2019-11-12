using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchMyPath.Config
{
    /// <summary>
    /// Configuration settings for the Steam launch system.
    /// </summary>
    public class Steam
    {
        /// <summary>
        /// If Red Dead Redemption 2 should use Steam to launch the game.
        /// </summary>
        [JsonProperty("rdr2_use")]
        public bool RDR2Use { get; set; } = false;
        /// <summary>
        /// The Steam AppID to use for launching Red Dead Redemption 2.
        /// </summary>
        [JsonProperty("rdr2_appid")]
        public uint RDR2AppID { get; set; } = 0;
        /// <summary>
        /// If Grand Theft Auto V should use Steam to launch the game.
        /// </summary>
        [JsonProperty("gtav_use")]
        public bool GTAVUse { get; set; } = false;
        /// <summary>
        /// The Steam AppID to use for launching Grand Theft Auto V.
        /// </summary>
        [JsonProperty("gtav_appid")]
        public uint GTAVAppID { get; set; } = 271590;
    }
}
