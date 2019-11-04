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
        /// Gets a string from a Registry Key.
        /// </summary>
        private static string GetStringFromRegistry(string subkey, string value, bool removeQuotes = false)
        {
            // Start by trying to open the game uninstall information
            RegistryKey openedKey = Registry.LocalMachine.OpenSubKey(subkey);
            // If we failed to open the key, return
            if (openedKey == null)
            {
                return null;
            }

            // Then, try to get the value requested
            object returnedValue = openedKey.GetValue(value);
            // Also here, if null return
            if (returnedValue == null)
            {
                return null;
            }

            // Create a string builder to do some manipulations
            StringBuilder builder = new StringBuilder(returnedValue.ToString());

            // If the user wants to remove the double quotes, do it
            if (removeQuotes)
            {
                builder.Replace("\"", "");
            }

            // Finally, return the string that we got
            return builder.ToString();
        }

        /// <summary>
        /// Gets the GTA V install location from the InstallShield Uninstall information.
        /// </summary>
        public static string GetUninstallPath()
        {
            return Path.GetDirectoryName(GetStringFromRegistry(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{5EFC6C07-6B87-43FC-9524-F9E967241741}", "DisplayIcon", true));
        }
    }
}
