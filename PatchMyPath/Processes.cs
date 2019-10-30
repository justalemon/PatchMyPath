using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceProcess;

namespace PatchMyPath
{
    /// <summary>
    /// A class used to terminate the GTA V related processes.
    /// </summary>
    public static class Processes
    {
        /// <summary>
        /// Terminates the Rockstar Games Launcher and Steam (if the user has a Steam copy).
        /// </summary>
        public static void TerminateLaunchers()
        {
            // If the Rockstar Games Launcher service is running
            while (Process.GetProcessesByName("RockstarService").Length != 0)
            {
                // Take control of the process
                using (ServiceController controller = new ServiceController("Rockstar Game Library Service"))
                {
                    // And if is running
                    if (controller.Status == ServiceControllerStatus.Running)
                    {
                        // Stop it
                        controller.Stop();
                    }
                }
            }

            // And all of the processes required by the RGL Launcher, in order
            TerminateProcesses(new string[] { "SocialClubHelper", "Launcher", "LauncherPatcher" });
        }

        /// <summary>
        /// Terminates the choosen process.
        /// </summary>
        /// <param name="name">The name of the process to terminate.</param>
        public static void TerminateProcess(string name)
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

        /// <summary>
        /// Terminates a set of processes.
        /// </summary>
        /// <param name="processes">An IEnumerable of strings with the processes names.</param>
        public static void TerminateProcesses(IEnumerable<string> processes)
        {
            // For every process that we have
            foreach (string process in processes)
            {
                // If is running
                if (Process.GetProcessesByName(process).Length != 0)
                {
                    // Kill it
                    TerminateProcess(process);
                }
            }
        }
    }
}
