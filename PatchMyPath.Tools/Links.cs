using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace PatchMyPath.Tools
{
    /// <summary>
    /// Functions used to Create symbolic links.
    /// </summary>
    public static class Links
    {
        /// <summary>
        /// Creates a symbolic link. (https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createsymboliclinkw)
        /// </summary>
        /// <param name="lpSymlinkFileName">The symbolic link to be created.</param>
        /// <param name="lpTargetFileName">The name of the target for the symbolic link to be created.</param>
        /// <param name="dwFlags">Indicates whether the link target, lpTargetFileName, is a directory.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool CreateSymbolicLinkW(string lpSymlinkFileName, string lpTargetFileName, uint dwFlags);
        /// <summary>
        /// Establishes a hard link between an existing file and a new file. (https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-createhardlinkw)
        /// </summary>
        /// <param name="lpFileName">The name of the new file.</param>
        /// <param name="lpExistingFileName">The name of the existing file.</param>
        /// <param name="lpSecurityAttributes">Reserved; must be NULL. (For C#, IntPtr.Zero)</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool CreateHardLinkW(string lpFileName, string lpExistingFileName, IntPtr lpSecurityAttributes);

        /// <summary>
        /// Creates or opens a file or I/O device. (https://docs.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-createfilew)
        /// </summary>
        /// <param name="lpFileName">The name of the file or device to be created or opened.</param>
        /// <param name="dwDesiredAccess">The requested access to the file or device, which can be summarized as read, write, both or neither zero).</param>
        /// <param name="dwShareMode">The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none.</param>
        /// <param name="lpSecurityAttributes">A pointer to a SECURITY_ATTRIBUTES structure that contains two separate but related data members./param>
        /// <param name="dwCreationDisposition">An action to take on a file or device that exists or does not exist.</param>
        /// <param name="dwFlagsAndAttributes">The file or device attributes and flags.</param>
        /// <param name="hTemplateFile">A valid handle to a template file with the GENERIC_READ access right.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern SafeFileHandle CreateFileW(string lpFileName, int dwDesiredAccess, int dwShareMode, IntPtr lpSecurityAttributes, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);
        /// <summary>
        /// Retrieves the final path for the specified file.
        /// </summary>
        /// <param name="hFile">A handle to a file or directory.</param>
        /// <param name="lpszFilePath">A pointer to a buffer that receives the path of hFile.</param>
        /// <param name="cchFilePath">The size of lpszFilePath, in TCHARs. This value does not include a NULL termination character.</param>
        /// <param name="dwFlags">The type of result to return.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int GetFinalPathNameByHandleW([In]IntPtr hFile, [Out]StringBuilder lpszFilePath, [In]int cchFilePath, [In]int dwFlags);

        /// <summary>
        /// Creates a symbolic link.
        /// </summary>
        public static void CreateSymbolicLink(string symlink, string target, uint flag)
        {
            // Try to create a symbolic link
            // If we failed, raise a native win32 exception with the current error code
            if (!CreateSymbolicLinkW(symlink, target, flag))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
        /// <summary>
        /// Creates a hard link.
        /// </summary>
        public static void CreateHardLink(string original, string created)
        {
            // Try to create a hard link
            // If we failed, raise a native win32 exception with the current error code
            if (!CreateHardLinkW(created, original, IntPtr.Zero))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        /// <summary>
        /// Gets the real path of any file or directory.
        /// </summary>
        /// <param name="path">The path that you want to get.</param>
        /// <returns>The real path of the file, bypassing symbolic links and junctions.</returns>
        public static string GetRealPath(string path)
        {
            // Try to open/create the file and get the handle
            SafeFileHandle handle = CreateFileW(path, 0, 2, IntPtr.Zero, 3, 0x02000000, IntPtr.Zero);
            // If the file is invalid, raise a windows native exception
            if (handle.IsInvalid)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            // Create a string builder with the capacity of 512 characters
            StringBuilder output = new StringBuilder(512);
            // Request the final path name and get the result code
            int result = GetFinalPathNameByHandleW(handle.DangerousGetHandle(), output, output.Capacity, 0);

            // If the result code is under zero, throw a native exception
            if (result < 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            // If there is a Windows 10 path extension, remove "\\?\" from the path
            if (output.Length >= 4 && output[0] == '\\' && output[1] == '\\' && output[2] == '?' && output[3] == '\\')
            {
                return output.ToString().Substring(4);
            }
            // Otherwise, return the normal path
            return output.ToString();
        }
    }
}
