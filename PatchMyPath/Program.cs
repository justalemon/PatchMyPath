using Newtonsoft.Json;
using System;
using System.IO;

namespace PatchMyPath
{
    public class Program
    {
        /// <summary>
        /// The configuration of the program.
        /// </summary>
        public static Configuration Config = null;

        public static int Main(string[] args)
        {
            // Try to parse the configuration
            try
            {
                Config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("PatchMyPath.json"));
            }
            // If the file was not found
            catch (FileNotFoundException)
            {
                Console.WriteLine("The Configuration File does not exists!");
                Console.WriteLine("Please check that PatchMyPath.json is present and try again.");
                return 1;
            }
            // If the file could not be parsed
            catch (JsonSerializationException)
            {
                Console.WriteLine("The Configuration file is invalid!");
                Console.WriteLine("Please make sure that the Curly Brackets and Comas are in the correct place.");
                Console.WriteLine("If you know what you are doing: Use a Linter on a Code Editor/IDE.");
                return 2;
            }

            Console.WriteLine("Hello World!");
            return 0;
        }
    }
}
