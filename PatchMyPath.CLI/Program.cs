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
        public static int Main(string[] args)
        {
            // Now, destroy the original game folder if is present
            if (Directory.Exists(Config.Destination))
            {
                Directory.Delete(Config.Destination);
            }

            // Try to create the symbolic link
            try
            {
                Links.CreateSymbolicLink(Config.Destination, install.GamePath, 3); // 3 means Directory (0x1) and Unprivileged/Dev Mode (0x2)
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
    }
}
