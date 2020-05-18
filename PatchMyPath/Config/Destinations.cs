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
        /// <summary>
        /// The location where Grand Theft Auto IV should be located.
        /// </summary>
        [JsonProperty("gtaiv", NullValueHandling = NullValueHandling.Ignore)]
        public string GTAIV { get; set; } = "";

        /// <summary>
        /// Gets the target directory for a game.
        /// </summary>
        public string GetDestination(Game game)
        {
            switch (game)
            {
                case Game.RedDeadRedemption2:
                    return RDR2;
                case Game.GrandTheftAutoV:
                    return GTAV;
                case Game.GrandTheftAutoIV:
                    return GTAIV;
                default:
                    return null;
            }
        }
    }
}
