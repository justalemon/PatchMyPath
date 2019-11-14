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
        /// If the install should be added after finishing with the duplication process.
        /// </summary>
        [JsonProperty("add_after_dupe")]
        public bool AddAfterDupe { get; set; } = true;
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
    }
}
