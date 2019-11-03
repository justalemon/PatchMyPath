using Microsoft.Win32;
using System.IO;
using System.Text;

namespace PatchMyPath
{
    /// <summary>
    /// Set of function for getting various game paths.
    /// </summary>
    public static class Paths
    {
        /// <summary>
        /// Gets the GTA V install location from the InstallShield Uninstall information.
        /// </summary>
        public static string GetUninstallPath()
        {
            // Start by trying to open the game uninstall information
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{5EFC6C07-6B87-43FC-9524-F9E967241741}");
            // If we failed to open the key, return
            if (key == null)
            {
                return null;
            }

            // Then, try to get the DisplayIcon value
            // We do this because GTA5.exe is used as the icon
            object icon = key.GetValue("DisplayIcon");
            // Also here, if null return
            if (icon == null)
            {
                return null;
            }

            // Create a string builder to remove invalid characters
            StringBuilder builder = new StringBuilder(icon.ToString());
            // Remove the first and last character (Double Quotes)
            builder.Remove(0, 1);
            builder.Remove(builder.Length - 1, 1);
            // If the path is valid, return it

            return Path.GetDirectoryName(builder.ToString());
        }
    }
}
