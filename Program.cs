using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace PatchMyPath
{
    class Program
    {
        static void Main(string[] args)
        {

            string LocalDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string SavedDir = (string)Registry.GetValue(RegKey, RegValue, string.Empty);

            bool ValidDir = true;
            int ExitCode = 0;

            List<string> Executables = new List<string>() {"GTA5.exe", "GTAVLauncher.exe", "PlayGTAV.exe"};

            Console.WriteLine("Local Path is " + LocalDir);
            Console.WriteLine("Saved Path is " + LocalDir);
            Console.WriteLine("Registry Key is " + RegKey);
            Console.WriteLine();
            
                foreach (var Executable in Executables)
                {
                    if (!File.Exists(LocalDir + "\\" + Executable))
                    {
                        Console.WriteLine(Executable + " was not found.");
                        ValidDir = false;
                    }
                    else
                    {
                        Console.WriteLine(Executable + " was found.");
                    }
                }

            Console.WriteLine();
            
            if (LocalDir == SavedDir)
            {
                Console.WriteLine("The directory is the same.");
                ExitCode = 0;
            }
            else if (ValidDir)
            {
                Registry.SetValue(RegKey, RegValue, LocalDir);
                Console.WriteLine("GTA V Dir was set to: " + LocalDir);
                Console.WriteLine();
                Console.WriteLine("Starting Grand Theft Auto V...");
                Process.Start(LocalDir + "\\PlayGTAV.exe");
            }
            else
            {
                Console.WriteLine("The Directory is not valid and cannot be set.");
            }
            #if DEBUG
                Console.ReadLine();
            #endif

            Environment.Exit(ExitCode);
        }
    }
}
