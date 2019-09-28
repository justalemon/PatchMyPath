using Microsoft.Win32;
using Newtonsoft.Json;
using PatchMyPath.Properties;
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

            // Print all of the available installs
            for (int i = 0; i < Config.GameInstalls.Count; i++)
            {
                Console.WriteLine($"{i}: {Config.GameInstalls[i].Path}");
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

            // If we got here, success!
            return 0;
        }

        public static bool IsDevModeEnabled()
        {
            // Open the registry key for reading
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(Resources.DeveloperKey))
            {
                // If the key exists
                if (key != null)
                {
                    // Read the value of AllowDevelopmentWithoutDevLicense
                    int output = (int)key.GetValue(Resources.DeveloperValue);

                    // Then, convert the boolean to zero
                    return Convert.ToBoolean(output);
                }
            }

            // If we got here, the dev mode is not enabled
            return false;
        }
    }
}
