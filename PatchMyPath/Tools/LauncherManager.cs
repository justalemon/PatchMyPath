using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace PatchMyPath.Tools
{
    public enum LauncherOperationResult
    {
        Unknown = -1,
        Done = 0,
        NotInstalled = 1,
        NotRunning = 2
    }

    /// <summary>
    /// Tools for terminating the launchers.
    /// </summary>
    public static class LauncherManager
    {
        private static readonly Dictionary<LauncherType, string> keys = new Dictionary<LauncherType, string>
        {
            { LauncherType.EpicGamesStore, "{FEF3A9BA-A962-4469-AD62-04839D4BB847}" },
            { LauncherType.Steam, "Steam" },
            { LauncherType.RockstarGamesLauncher, "Rockstar Games Launcher" },
        };
        private static readonly Dictionary<LauncherType, string> exes = new Dictionary<LauncherType, string>
        {
            { LauncherType.EpicGamesStore, "EpicGamesLauncher" },
            { LauncherType.Steam, "Steam" },
            { LauncherType.RockstarGamesLauncher, "Launcher" },  // This can go horribly very quickly
        };

        /// <summary>
        /// Gets the path of the main executable of the launcher.
        /// </summary>
        /// <param name="launcher">The launcher to get.</param>
        /// <returns>A strinng with the path to the main executable, or null.</returns>
        public static string GetExecutablePath(LauncherType launcher)
        {
            // If we don't know the Registry key or executable name, return
            if (!keys.ContainsKey(launcher) || !keys.ContainsKey(launcher))
            {
                return null;
            }

            // Get the registry key with the Steam information
            using (RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            {
                using (RegistryKey subKey = key.OpenSubKey($"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{keys[launcher]}"))
                {
                    if (subKey == null)
                    {
                        return null;
                    }

                    // Then, try to get the path from InstallLocation and UninstallString, in that order
                    string path = null;

                    string install = subKey.GetValue("InstallLocation")?.ToString();
                    if (!string.IsNullOrWhiteSpace(install))
                    {
                        path = install;
                    }
                    if (path == null)
                    {
                        string uninstall = subKey.GetValue("UninstallString").ToString();
                        if (string.IsNullOrWhiteSpace(uninstall))
                        {
                            return null;
                        }
                        path = Path.GetDirectoryName(uninstall);
                    }

                    // From the uninstall value, get the path and make the correct path
                    switch (launcher)
                    {
                        case LauncherType.EpicGamesStore:
                            return Path.Combine(path, "Launcher", "Portal", "Binaries", "Win32", "EpicGamesLauncher.exe");
                        case LauncherType.Steam:
                            return Path.Combine(path, "Steam.exe");
                        case LauncherType.RockstarGamesLauncher:
                            return Path.Combine(path, "LauncherPatcher.exe");
                        default:
                            return null;
                    }
                }
            }
        }

        /// <summary>
        /// Starts the specified launcher.
        /// </summary>
        /// <param name="launcher">The launcher to start.</param>
        /// <returns><see langword="true"/> if the launcher was started correctly, <see langword="false"/> otherwise.</returns>
        public static LauncherOperationResult Start(LauncherType launcher)
        {
            // If we don't know the Registry key or executable name, return
            if (!keys.ContainsKey(launcher) || !keys.ContainsKey(launcher))
            {
                return LauncherOperationResult.Unknown;
            }

            // Get the path of the executable
            string path = GetExecutablePath(launcher);

            // If is invalid, return
            if (string.IsNullOrWhiteSpace(path))
            {
                return LauncherOperationResult.NotInstalled;
            }

            // Otherwise, just start it
            Process.Start(path);
            return LauncherOperationResult.Done;
        }

        /// <summary>
        /// Stops the specified launcher.
        /// </summary>
        /// <param name="launcher">The launcher to stop.</param>
        /// <returns>The result of the stop operation.</returns>
        public static LauncherOperationResult Stop(LauncherType launcher)
        {
            // If there is no executable name, return
            if (!exes.ContainsKey(launcher))
            {
                return LauncherOperationResult.Unknown;
            }

            // Make sure that the launcher is running before stopping it
            Process[] processes = Process.GetProcessesByName(exes[launcher]);
            if (processes.Length == 0)
            {
                return LauncherOperationResult.NotRunning;
            }

            // If we got here, the process is running
            // So ask taskill or the launcher itself to terminate the game(s) and launcher
            switch (launcher)
            {
                case LauncherType.Steam:
                    Process.Start(GetExecutablePath(LauncherType.Steam), "-shutdown");
                    break;
                case LauncherType.RockstarGamesLauncher:
                    Process.Start("taskkill", $"/F /T /IM LauncherPatcher.exe");
                    Process.Start("taskkill", $"/F /T /PID {processes[0].Id}");
                    break;
                default:
                    Process.Start("taskkill", $"/F /T /PID {processes[0].Id}");
                    break;
            }
            WaitUntilClosed(launcher);
            return LauncherOperationResult.Done;
        }

        /// <summary>
        /// Waits until the specified launcher has been closed.
        /// </summary>
        /// <param name="type">The launcher to check.</param>
        public static void WaitUntilClosed(LauncherType launcher)
        {
            // If the launcher is not present, return
            if (!exes.ContainsKey(launcher))
            {
                return;
            }

            // Then, wait until the process has exited
            while (Process.GetProcessesByName(exes[launcher]).Length > 0)
            {
                Thread.Sleep(1);
            }
        }
    }
}
