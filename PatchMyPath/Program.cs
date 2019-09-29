using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PatchMyPath
{
    public class Program
    {
        /// <summary>
        /// Creates a symbolic link. (https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createsymboliclinka)
        /// </summary>
        /// <param name="lpSymlinkFileName">The symbolic link to be created.</param>
        /// <param name="lpTargetFileName">The name of the target for the symbolic link to be created.</param>
        /// <param name="dwFlags">Indicates whether the link target, lpTargetFileName, is a directory.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport("kernel32.dll")]
        public static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, uint dwFlags);

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

            // Now, tell the user to select a GTA V install
            Console.WriteLine("The following game installs are available:");
            Console.WriteLine();

            // Iterate over the number of game installs
            for (int i = 0; i < Config.GameInstalls.Count; i++)
            {
                // Save the install
                Install selected = Config.GameInstalls[i];

                // If the install is set to auto detect, update the type
                if (selected.Type == InstallType.AutoDetect)
                {
                    selected.UpdateType(Config.UseSteam);
                }

                // And print it on the console
                Console.WriteLine($"{i}: {selected.GamePath} [Valid: {selected.IsLegal}] [Type: {selected.Type}]");
            }

            // And request the user to input a number
            Console.WriteLine();
            Console.Write("What install do you want to use? ");
            string input = Console.ReadLine();
            Console.WriteLine();

            // If we were unable to parse the user input
            if (!int.TryParse(input, out int output))
            {
                Console.WriteLine($"'{input}' is not a valid number! Exiting...");
                return 3;
            }

            // If the index is over the limit
            if (output > Config.GameInstalls.Count - 1)
            {
                Console.WriteLine($"'{output}' is outside of the range 0-{Config.GameInstalls.Count - 1}! Exiting...");
                return 4;
            }

            // At this point we have a valid install number
            // So save it here for later
            Install install = Config.GameInstalls[output];

            // Now, destroy the original game folder if is present
            if (Directory.Exists(Config.Destination))
            {
                Directory.Delete(Config.Destination);
            }

            // Then, create a symbolic link between the game and the executable
            // If we didn't succeeded, notify the user and exit
            if (!CreateSymbolicLink(Config.Destination, install.GamePath, 3)) // 3 means Directory (0x1) and Unprivileged/Dev Mode (0x2)
            {
                Console.WriteLine($"Error while creating the Symbolic Link! Exiting...");
                return 5;
            }

            // If we got here, success!
            return 0;
        }
    }
}
