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
            string AppVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

            Logger.Write(string.Format("----- PatchMyPath {0} is Launching... -----", AppVersion));

            string LocalDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string SavedDir = (string)Registry.GetValue(Properties.Resources.RegKey, Properties.Resources.RegValue, string.Empty);

            List<string> Executables = new List<string>() { Properties.Resources.GameMainExe, Properties.Resources.GameLauncherExe, Properties.Resources.GamePlayExe };

            Logger.Write("Local Path is " + LocalDir);
            Logger.Write("Saved Path is " + SavedDir);
            Logger.Write("Registry Key is " + Properties.Resources.RegKey);
            
            if (LocalDir == SavedDir)
            {
                Logger.Write("The Local directory is the same that is saved");
                Checks.Exit(0);
            }

            foreach (var Executable in Executables)
            {
                FileType FileStatus = Checks.CheckGameFile(LocalDir + "\\" + Executable);

                if (FileStatus == FileType.FoundIsGame)
                {
                    Logger.Write(Executable + " was found and is a GTA V executable.");
                }
                else if (FileStatus == FileType.FoundNotGame)
                {
                    Logger.Write(Executable + " was found and is NOT a GTA V executable.");
                }
                else if (FileStatus == FileType.NotFound)
                {
                    Logger.Write(Executable + " was NOT found.");
                }
            }

            Checks.Exit(0);
        }
    }
}
