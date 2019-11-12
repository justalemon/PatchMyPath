using Newtonsoft.Json;

namespace PatchMyPath.Config
{
    /// <summary>
    /// Class that stores the destinations of RDR 2 and GTA V.
    /// </summary>
    public class Destinations
    {
        /// <summary>
        /// The location where Red Dead Redemption 2 should be located.
        /// </summary>
        [JsonProperty("rdr2", NullValueHandling = NullValueHandling.Ignore)]
        public string RDR2 { get; set; } = "";
        /// <summary>
        /// The location where Grand Theft Auto V should be located.
        /// </summary>
        [JsonProperty("gtav", NullValueHandling = NullValueHandling.Ignore)]
        public string GTAV { get; set; } = "";
    }
}
