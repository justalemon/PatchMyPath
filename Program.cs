using Microsoft.Win32;
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
            bool ValidInstall = true;

            string AppVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            Logger.Write(string.Format("----- PatchMyPath {0} is Launching... -----", AppVersion));

            string LocalDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string SavedDir = (string)Registry.GetValue(Properties.Resources.RegKey, Properties.Resources.RegValue, string.Empty);

            List<string> Executables = new List<string>() { Properties.Resources.GameMainExe, Properties.Resources.GameLauncherExe, Properties.Resources.GamePlayExe };

            Logger.Write("Local Path is " + LocalDir);
            Logger.Write("Saved Path is " + SavedDir);
            Logger.Write("Registry Key is " + Properties.Resources.RegKey);

            foreach (var Executable in Executables)
            {
                FileType FileStatus = Checks.CheckGameFile(LocalDir + "\\" + Executable);

                if (FileStatus == FileType.FoundIsGame)
                {
                    Logger.Write(Executable + " was found and is a GTA V executable");
                }
                else if (FileStatus == FileType.FoundNotGame)
                {
                    Logger.Write(Executable + " was found and is NOT a GTA V executable");
                    ValidInstall = false;
                }
                else if (FileStatus == FileType.NotFound)
                {
                    Logger.Write(Executable + " was NOT found");
                    ValidInstall = false;
                }
            }

            if (LocalDir == SavedDir)
            {
                Logger.Write("The Local directory is the same that is saved");
            }
            else if (ValidInstall)
            {
                Registry.SetValue(Properties.Resources.RegKey, Properties.Resources.RegValue, LocalDir);
                Logger.Write("The local directory was set to " + LocalDir);
            }
            else
            {
                Logger.Write("This is not a valid GTA V install");
            }

            Checks.Exit(0);
        }
    }
}
