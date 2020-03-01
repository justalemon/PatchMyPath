using Newtonsoft.Json;
using NLog;
using PatchMyPath.Config;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace PatchMyPath
{
    /// <summary>
    /// The type of filesystem entry for the game content.
    /// </summary>
    [Flags]
    public enum EntryType
    {
        File = 1,
        Folder = 2,
        Optional = 4,
        Copy = 8,
    }

    /// <summary>
    /// Manager for the File Lists.
    /// </summary>
    public static class ListManager
    {
        /// <summary>
        /// The logger for the current class.
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// The RestSharp client for requesting the files.
        /// </summary>
        public static readonly RestClient Client = new RestClient("https://raw.githubusercontent.com/justalemon/PatchMyPath/master/PatchMyPath/FileList");
        /// <summary>
        /// The list of files for GTA V and RDR2.
        /// </summary>
        public static readonly Dictionary<Game, Dictionary<string, EntryType>> Lists = new Dictionary<Game, Dictionary<string, EntryType>>();

        /// <summary>
        /// Populates the lists for all games.
        /// </summary>
        /// <param name="force">If we should download the file again instead of loading it from storage.</param>
        public static void Populate(bool force = false)
        {
            // Iterate over the list of games
            foreach (Game game in Enum.GetValues(typeof(Game)).Cast<Game>())
            {
                // And populate every single one of them
                Populate(game, force);
            }
        }
        /// <summary>
        /// Populates the list of files for a specific game.
        /// </summary>
        /// <param name="game">The game to populate.</param>
        /// <param name="force">If we should download the file again instead of loading it from storage.</param>
        public static void Populate(Game game, bool force = false)
        {
            // If this item is for invalid games, return
            if (game == Game.Invalid)
            {
                return;
            }

            // Get the readable name of it
            string name = game.ToString().SpaceOnUpperCase();
            // Create the path for the directory and file
            string directory = Path.Combine("FileList");
            string location = Path.Combine(directory, game.ToString() + ".json");

            // If the file does not exists or we are forced to download it
            if (!File.Exists(location) || force)
            {
                // Create the request
                RestRequest request = new RestRequest($"{game}.json", DataFormat.Json);
                // And fetch the contents
                IRestResponse response = Client.Get(request);

                // If we didn't got code 200, log it and return
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Logger.Error($"Got code {response.StatusCode} when fetching list for {name}!");
                    return;
                }

                // Go ahead and parse the information of the request
                Dictionary<string, EntryType> parsed = JsonConvert.DeserializeObject<Dictionary<string, EntryType>>(response.Content);
                // And save the list of files in the dictionary
                Lists[game] = parsed;
                // If the directory does not exists, create it
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                // Convert the dictionary into a string
                string json = JsonConvert.SerializeObject(parsed);
                // And save it onto the file
                File.WriteAllText(location, json);

                // Finally, log that we have finished
                Logger.Info($"List of Files for {name} was downloaded from GitHub");
            }
            // If the file exists
            else
            {
                // Get the contents of the file
                string text = File.ReadAllText(location);
                // Parse it as JSON
                Dictionary<string, EntryType> data = JsonConvert.DeserializeObject<Dictionary<string, EntryType>>(text);
                // And save it
                Lists[game] = data;

                // Finally, log that we have finished
                Logger.Info($"List of Files for {name} was loaded from file");
            }
        }
    }
}
