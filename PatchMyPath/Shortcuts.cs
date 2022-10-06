using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Windows.Forms;
using PatchMyPath.Config;

namespace PatchMyPath
{
    public class Shortcuts
    {
        /// <summary>
        /// Represents a Windows Shell Link.
        /// </summary>
        [ComImport]
        [Guid("00021401-0000-0000-C000-000000000046")]
        private class ShellLink
        {
        }

        /// <summary>
        /// Exposes methods that create, modify, and resolve Shell links.
        /// </summary>
        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("000214F9-0000-0000-C000-000000000046")]
        private interface IShellLink
        {
            // The order is important, I learned that the hard way

            /// <summary>
            /// Gets the path and file name of the target of a Shell link object.
            /// </summary>
            /// <param name="pszFile">The address of a buffer that receives the path and file name of the target of the Shell link object.</param>
            /// <param name="cchMaxPath">The size, in characters, of the buffer pointed to by the pszFile parameter, including the terminating null character. The maximum path size that can be returned is MAX_PATH. This parameter is commonly set by calling ARRAYSIZE(pszFile). The ARRAYSIZE macro is defined in Winnt.h.</param>
            /// <param name="pfd">A pointer to a WIN32_FIND_DATA structure that receives information about the target of the Shell link object. If this parameter is NULL, then no additional information is returned.</param>
            /// <param name="fFlags">Flags that specify the type of path information to retrieve. This parameter can be a combination of the following values. SLGP_SHORTPATH: Retrieves the standard short (8.3 format) file name. SLGP_UNCPRIORITY: Unsupported; do not use. SLGP_RAWPATH: Retrieves the raw path name. A raw path is something that might not exist and may include environment variables that need to be expanded. SLGP_RELATIVEPRIORITY: Windows Vista and later. Retrieves the path, if possible, of the shortcut's target relative to the path set by a previous call to <see cref="SetRelativePath"/>.</param>
            void GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out IntPtr pfd, int fFlags);
            /// <summary>
            /// Gets the list of item identifiers for the target of a Shell link object.
            /// </summary>
            /// <param name="ppidl">When this method returns, contains the address of a PIDL.</param>
            void GetIDList(out IntPtr ppidl);
            /// <summary>
            /// Sets the pointer to an item identifier list (PIDL) for a Shell link object.
            /// </summary>
            /// <param name="pidl">The object's fully qualified PIDL.</param>
            void SetIDList(IntPtr pidl);
            /// <summary>
            /// Gets the description string for a Shell link object.
            /// </summary>
            /// <param name="pszName">A pointer to the buffer that receives the description string.</param>
            /// <param name="cchMaxName">The maximum number of characters to copy to the buffer pointed to by the pszName parameter.</param>
            void GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
            /// <summary>
            /// Sets the description for a Shell link object. The description can be any application-defined string.
            /// </summary>
            /// <param name="pszName">A pointer to a buffer containing the new description string.</param>
            void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
            /// <summary>
            /// Gets the name of the working directory for a Shell link object.
            /// </summary>
            /// <param name="pszDir">The address of a buffer that receives the name of the working directory.</param>
            /// <param name="cchMaxPath">The maximum number of characters to copy to the buffer pointed to by the pszDir parameter. The name of the working directory is truncated if it is longer than the maximum specified by this parameter.</param>
            void GetWorkingDirectory([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
            /// <summary>
            /// Sets the name of the working directory for a Shell link object.
            /// </summary>
            /// <param name="pszDir">The address of a buffer that contains the name of the new working directory.</param>
            void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
            /// <summary>
            /// Gets the command-line arguments associated with a Shell link object.
            /// </summary>
            /// <param name="pszArgs">A pointer to the buffer that, when this method returns successfully, receives the command-line arguments.</param>
            /// <param name="cchMaxPath">The maximum number of characters that can be copied to the buffer supplied by the pszArgs parameter. In the case of a Unicode string, there is no limitation on maximum string length. In the case of an ANSI string, the maximum length of the returned string varies depending on the version of Windows—MAX_PATH prior to Windows 2000 and INFOTIPSIZE (defined in Commctrl.h) in Windows 2000 and later.</param>
            void GetArguments([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
            /// <summary>
            /// Sets the command-line arguments for a Shell link object.
            /// </summary>
            /// <param name="pszArgs">A pointer to a buffer that contains the new command-line arguments. In the case of a Unicode string, there is no limitation on maximum string length. In the case of an ANSI string, the maximum length of the returned string varies depending on the version of Windows—MAX_PATH prior to Windows 2000 and INFOTIPSIZE (defined in Commctrl.h) in Windows 2000 and later.</param>
            void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
            /// <summary>
            /// Gets the keyboard shortcut (hot key) for a Shell link object.
            /// </summary>
            /// <param name="pwHotkey">The address of the keyboard shortcut. The virtual key code is in the low-order byte, and the modifier flags are in the high-order byte. The modifier flags can be a combination of the following values.</param>
            void GetHotkey(out short pwHotkey);
            /// <summary>
            /// Sets a keyboard shortcut (hot key) for a Shell link object.
            /// </summary>
            /// <param name="wHotkey">The new keyboard shortcut. The virtual key code is in the low-order byte, and the modifier flags are in the high-order byte. The modifier flags can be a combination of the values specified in the description of the IShellLink::GetHotkey method.</param>
            void SetHotkey(short wHotkey);
            /// <summary>
            /// Gets the show command for a Shell link object.
            /// </summary>
            /// <param name="piShowCmd">A pointer to the command. The following commands are supported. SW_SHOWNORMAL:Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time. SW_SHOWMAXIMIZED: Activates the window and displays it as a maximized window. SW_SHOWMINIMIZED: Activates the window and displays it as a minimized window.</param>
            void GetShowCmd(out int piShowCmd);
            /// <summary>
            /// Sets the show command for a Shell link object. The show command sets the initial show state of the window.
            /// </summary>
            /// <param name="iShowCmd">Command. SetShowCmd accepts one of the following ShowWindow commands. SW_SHOWNORMAL: Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time. SW_SHOWMAXIMIZED: Activates the window and displays it as a maximized window. SW_SHOWMINNOACTIVE: Displays the window in its minimized state, leaving the currently active window as active.</param>
            void SetShowCmd(int iShowCmd);
            /// <summary>
            /// Gets the location (path and index) of the icon for a Shell link object.
            /// </summary>
            /// <param name="pszIconPath">The address of a buffer that receives the path of the file containing the icon.</param>
            /// <param name="cchIconPath">The maximum number of characters to copy to the buffer pointed to by the pszIconPath parameter.</param>
            /// <param name="piIcon">The address of a value that receives the index of the icon.</param>
            void GetIconLocation([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
            /// <summary>
            /// Sets the location (path and index) of the icon for a Shell link object.
            /// </summary>
            /// <param name="pszIconPath">The address of a buffer to contain the path of the file containing the icon.</param>
            /// <param name="iIcon">The index of the icon.</param>
            void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
            /// <summary>
            /// Sets the relative path to the Shell link object.
            /// </summary>
            /// <param name="pszPathRel">The address of a buffer that contains the fully-qualified path of the shortcut file, relative to which the shortcut resolution should be performed. It should be a file name, not a folder name.</param>
            /// <param name="dwReserved">Reserved. Set this parameter to zero.</param>
            void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
            /// <summary>
            /// Attempts to find the target of a Shell link, even if it has been moved or renamed.
            /// </summary>
            /// <param name="hwnd">A handle to the window that the Shell will use as the parent for a dialog box. The Shell displays the dialog box if it needs to prompt the user for more information while resolving a Shell link.</param>
            /// <param name="fFlags">Action flags. This parameter can be a combination of the following values. SLR_NO_UI (0x0001): 0x0001. Do not display a dialog box if the link cannot be resolved. When SLR_NO_UI is set, the high-order word of fFlags can be set to a time-out value that specifies the maximum amount of time to be spent resolving the link. The function returns if the link cannot be resolved within the time-out duration. If the high-order word is set to zero, the time-out duration will be set to the default value of 3,000 milliseconds (3 seconds). To specify a value, set the high word of fFlags to the desired time-out duration, in milliseconds. SLR_ANY_MATCH (0x0002): 0x0002. Not used. SLR_UPDATE (0x0004): 0x0004. If the link object has changed, update its path and list of identifiers. If SLR_UPDATE is set, you do not need to call IPersistFile::IsDirty to determine whether the link object has changed. SLR_NOUPDATE (0x0008): 0x0008. Do not update the link information. SLR_NOSEARCH (0x0010): 0x0010. Do not execute the search heuristics. SLR_NOTRACK (0x0020): 0x0020. Do not use distributed link tracking. SLR_NOLINKINFO (0x0040): 0x0040. Disable distributed link tracking. By default, distributed link tracking tracks removable media across multiple devices based on the volume name. It also uses the UNC path to track remote file systems whose drive letter has changed. Setting SLR_NOLINKINFO disables both types of tracking. SLR_INVOKE_MSI (0x0080): 0x0080. Call the Windows Installer. SLR_NO_UI_WITH_MSG_PUMP (0x0101): 0x0101. Windows XP and later. SLR_OFFER_DELETE_WITHOUT_FILE (0x0200): 0x0200. Windows 7 and later. Offer the option to delete the shortcut when this method is unable to resolve it, even if the shortcut is not a shortcut to a file. SLR_KNOWNFOLDER (0x0400): 0x0400. Windows 7 and later. Report as dirty if the target is a known folder and the known folder was redirected. This only works if the original target path was a file system path or ID list and not an aliased known folder ID list. SLR_MACHINE_IN_LOCAL_TARGET (0x0800): 0x0800. Windows 7 and later. Resolve the computer name in UNC targets that point to a local computer. This value is used with SLDF_KEEP_LOCAL_IDLIST_FOR_UNC_TARGET. SLR_UPDATE_MACHINE_AND_SID (0x1000): 0x1000. Windows 7 and later. Update the computer GUID and user SID if necessary.</param>
            void Resolve(IntPtr hwnd, int fFlags);
            /// <summary>
            /// Sets the path and file name for the target of a Shell link object.
            /// </summary>
            /// <param name="pszFile">The address of a buffer that contains the new path.</param>
            void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
        }

        /// <summary>
        /// Creates a Shortcut to launch a specific install.
        /// </summary>
        /// <param name="path">The path to the shortcut (.lnk) file.</param>
        /// <param name="install">The install to launch.</param>
        public static void Create(string path, Install install)
        {
            IShellLink shellLink = (IShellLink)new ShellLink();
            shellLink.SetPath(Application.ExecutablePath);
            shellLink.SetIconLocation(install.Executable, 0);
            shellLink.SetArguments($"--launch \"{install.GamePath}\"");
            shellLink.SetWorkingDirectory(Path.GetDirectoryName(Application.ExecutablePath));

            IPersistFile file = (IPersistFile)shellLink;
            file.Save(path, false);
        }
    }
}
