using System;
using System.Runtime.InteropServices;

namespace PatchMyPath.Tools
{
    /// <summary>
    /// Functions used to Create symbolic links.
    /// </summary>
    public static class SymbolicLink
    {
        /// <summary>
        /// Creates a symbolic link. (https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createsymboliclinka)
        /// </summary>
        /// <param name="lpSymlinkFileName">The symbolic link to be created.</param>
        /// <param name="lpTargetFileName">The name of the target for the symbolic link to be created.</param>
        /// <param name="dwFlags">Indicates whether the link target, lpTargetFileName, is a directory.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, uint dwFlags);

        /// <summary>
        /// Creates a symbolic link.
        /// </summary>
        public static void Create(string symlink, string target, uint flag)
        {
            // Try to create a symbolic link
            // If we failed, raise a native win32 exception with the current error code
            if (!CreateSymbolicLink(symlink, target, flag))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public static string GetLastErrorMessage()
        {
            // Get the last error code
            int code = Marshal.GetLastWin32Error();

            // Check it and return the correct error message
            switch (code)
            {
                case 2:
                    return $"We don't have access to create the symbolic link!{Environment.NewLine}Please run the program as administrator or enable the Windows 10 Developer Mode.";
                default:
                    return $"Error while creating the Symbolic Link! Got code {code}!";
            }
        }
    }
}
