using Newtonsoft.Json;
using PatchMyPath.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

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
            // Print the program information
            PrintHeader();

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

            // If the install is invalid, notify the user and return
            if (install.Type == InstallType.Invalid)
            {
                Console.WriteLine($"This game install is not valid.{Environment.NewLine}Please ensure that the game executables are in the right place and try again.");
                Console.ReadKey();
                return 6;
            }

            // Kill the RGL service for protecting games from modifications
            while (Process.GetProcessesByName("RockstarService").Length != 0)
            {
                using (ServiceController controller = new ServiceController("Rockstar Game Library Service"))
                {
                    if (controller.Status == ServiceControllerStatus.Running)
                    {
                        controller.Stop();
                    }
                }
            }
            // And all of the processes required by the RGL Launcher, in order
            CloseProcesses(new string[] { "SocialClubHelper", "Launcher", "LauncherPatcher" });

            // If the user uses the Steam version, also kill that
            if (Config.UseSteam && Config.AppID == 271590)
            {
                CloseProcess("Steam");
            }

            // Now, destroy the original game folder if is present
            if (Directory.Exists(Config.Destination))
            {
                Directory.Delete(Config.Destination);
            }

            // Try to create the symbolic link
            try
            {
                Links.Create(Config.Destination, install.GamePath, 3); // 3 means Directory (0x1) and Unprivileged/Dev Mode (0x2)
            }
            catch (Win32Exception er)
            {
                // Print the respective error message
                Console.WriteLine(er.Message);
                // Wait for a key press and exit with a code 5
                Console.ReadKey();
                return 5;
            }

            // Launch the game
            Config.Start(install.Type);

            // If we got here, success!
            return 0;
        }

        /// <summary>
        /// Prints the information header for the program
        /// </summary>
        public static void PrintHeader()
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("====================  PatchMyPath  ====================");
            Console.WriteLine("=======================================================");
            Console.WriteLine();
        }

        public static void CloseProcess(string name)
        {
            // We can't use C# functions for this because of access limitations
            // So start a taskkill process
            Process process = new Process();
            process.StartInfo.FileName = "taskkill.exe";
            process.StartInfo.Arguments = $"/f /im {name}.exe";
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();
        }

        public static void CloseProcesses(IEnumerable<string> processes)
        {
            foreach (string process in processes)
            {
                if (Process.GetProcessesByName(process).Length != 0)
                {
                    CloseProcess(process);
                }
            }
        }
    }
}
