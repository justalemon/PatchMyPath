using System;

namespace PatchMyPath
{
    /// <summary>
    /// The type of filesystem entry for the game content.
    /// </summary>
    [Flags]
    public enum EntryType
    {
        Ignore = 0,
        File = 1,
        Folder = 2,
        Optional = 4,
        Copy = 8,
    }
}
