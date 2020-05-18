using System;

namespace PatchMyPath
{
    /// <summary>
    /// The type of game installation.
    /// </summary>
    public enum Launch
    {
        /// <summary>
        /// This installation is invalid and can't be used.
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// Launch the game from GTAVLauncher.exe.
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Launch the game from GTA5.exe if GTAVLauncherBypass.asi exists.
        /// </summary>
        LauncherBypass = 1,
        /// <summary>
        /// Launch the game from RAGEPluginHook.exe if present.
        /// </summary>
        RagePluginHook = 2,
        /// <summary>
        /// Launch the game from RedHook2\Loader.exe if present.
        /// </summary>
        RedHook2 = 3,
        /// <summary>
        /// Launch the game from ScriptHook\rdr2d.exe if present.
        /// </summary>
        ScriptHook = 4,
    }

    /// <summary>
    /// The type of game that this install contains.
    /// </summary>
    public enum Game
    {
        /// <summary>
        /// None of the game executables are present.
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// Red Dead Redemption 2.
        /// </summary>
        RedDeadRedemption2 = 0,
        /// <summary>
        /// Grand Theft Auto V.
        /// </summary>
        GrandTheftAutoV = 1,
    }

    /// <summary>
    /// The type of launcher for the game.
    /// </summary>
    public enum LauncherType
    {
        /// <summary>
        /// Game uses the executables directly.
        /// </summary>
        Executable = 0,
        /// <summary>
        /// Game uses the Rockstar Games Launcher,
        /// </summary>
        RockstarGamesLauncher = 1,
        /// <summary>
        /// Game uses Steam.
        /// </summary>
        Steam = 2,
        /// <summary>
        /// Games uses the Epic Games Store.
        /// </summary>
        EpicGamesStore = 3
    }

    /// <summary>
    /// The type of filesystem entry for the game content.
    /// </summary>
    [Flags]
    public enum EntryType
    {
        /// <summary>
        /// Entry is a file.
        /// </summary>
        File = 1,
        /// <summary>
        /// Entry is a directory.
        /// </summary>
        Folder = 2,
        /// <summary>
        /// Entry is not mandatory for the game to work.
        /// </summary>
        Optional = 4,
        /// <summary>
        /// File needs to be copied for backwards compatibility.
        /// </summary>
        Copy = 8,
    }
}
