﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PatchMyPath.Config
{
    /// <summary>
    /// The basic configuration information.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The language of the program.
        /// </summary>
        [JsonProperty("language")]
        public CultureInfo Language { get; set; } = Program.Cultures.Where(p => Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == p.TwoLetterISOLanguageName).FirstOrDefault() ?? Program.Cultures[0];
        /// <summary>
        /// If the install should be added after finishing with the duplication process.
        /// </summary>
        [JsonProperty("add_after_dupe")]
        public bool AddAfterDupe { get; set; } = true;
        /// <summary>
        /// The settings for the usage of Steam for launching the game.
        /// </summary> 
        [JsonProperty("steam")]
        public Steam Steam { get; set; } = new Steam();
        /// <summary>
        /// The settings for using specific launchers to start the games.
        /// </summary>
        [JsonProperty("launchers")]
        public Launchers Launchers { get; set; } = new Launchers();
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
