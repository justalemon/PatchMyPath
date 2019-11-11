using System.Collections.Generic;

namespace PatchMyPath
{
    /// <summary>
    /// The type of filesystem entry for the game content.
    /// </summary>
    public enum EntryType
    {
        FileRequired = 0,
        FileOptional = 1,
        FolderRequired = 2,
        FolderOptional = 3,
    }

    /// <summary>
    /// The sets of files for Grand Theft Auto V and Red Dead Redemption 2.
    /// </summary>
    public static class Files
    {
        /// <summary>
        /// The filesystem entries for Grand Theft Auto V.
        /// </summary>
        public static readonly Dictionary<string, EntryType> GTAV = new Dictionary<string, EntryType>()
        {
            { "ReadMe", EntryType.FolderOptional },
            { "Redistributables", EntryType.FolderOptional },
            { "update", EntryType.FolderRequired },
            { "x64", EntryType.FolderRequired },

            { "GTA5.exe", EntryType.FileRequired },
            { "GTAVLanguageSelect.exe", EntryType.FileOptional },
            { "GTAVLauncher.exe", EntryType.FileRequired },
            { "PlayGTAV.exe", EntryType.FileOptional },
            { "bink2w64.dll", EntryType.FileRequired },
            { "d3dcompiler_46.dll", EntryType.FileRequired },
            { "d3dcsx_46.dll", EntryType.FileRequired },
            { "GFSDK_ShadowLib.win64.dll", EntryType.FileRequired },
            { "GFSDK_TXAA.win64.dll", EntryType.FileRequired },
            { "GFSDK_TXAA_AlphaResolve.win64.dll", EntryType.FileRequired },
            { "GPUPerfAPIDX11-x64.dll", EntryType.FileRequired },
            { "NvPmApi.Core.win64.dll", EntryType.FileRequired },
            { "index.bin", EntryType.FileOptional },
            { "common.rpf", EntryType.FileRequired },
            { "x64a.rpf", EntryType.FileRequired },
            { "x64b.rpf", EntryType.FileRequired },
            { "x64c.rpf", EntryType.FileRequired },
            { "x64d.rpf", EntryType.FileRequired },
            { "x64e.rpf", EntryType.FileRequired },
            { "x64f.rpf", EntryType.FileRequired },
            { "x64g.rpf", EntryType.FileRequired },
            { "x64h.rpf", EntryType.FileRequired },
            { "x64i.rpf", EntryType.FileRequired },
            { "x64j.rpf", EntryType.FileRequired },
            { "x64k.rpf", EntryType.FileRequired },
            { "x64l.rpf", EntryType.FileRequired },
            { "x64m.rpf", EntryType.FileRequired },
            { "x64n.rpf", EntryType.FileRequired },
            { "x64o.rpf", EntryType.FileRequired },
            { "x64p.rpf", EntryType.FileRequired },
            { "x64q.rpf", EntryType.FileRequired },
            { "x64r.rpf", EntryType.FileRequired },
            { "x64s.rpf", EntryType.FileRequired },
            { "x64t.rpf", EntryType.FileRequired },
            { "x64u.rpf", EntryType.FileRequired },
            { "x64v.rpf", EntryType.FileRequired },
            { "x64w.rpf", EntryType.FileRequired },
            { "version.txt", EntryType.FileOptional },
        };
        /// <summary>
        /// The filesystem entries for Red Dead Redemption 2.
        /// </summary>
        public static readonly Dictionary<string, EntryType> RDR2 = new Dictionary<string, EntryType>()
        {
            { "Redistributables", EntryType.FolderOptional },
            { "x64", EntryType.FolderRequired },

            { "RDR2.exe", EntryType.FileRequired },
            { "amd_ags_x64.dll", EntryType.FileRequired },
            { "bink2w64.dll", EntryType.FileRequired },
            { "dxilconv7.dll", EntryType.FileRequired },
            { "oo2core_5_win64.dll", EntryType.FileRequired },
            { "vulkan-1.dll", EntryType.FileRequired },
            { "index.bin", EntryType.FileOptional },
            { "anim_0.rpf", EntryType.FileRequired },
            { "appdata0_update.rpf", EntryType.FileRequired },
            { "common_0.rpf", EntryType.FileRequired },
            { "data_0.rpf", EntryType.FileRequired },
            { "hd_0.rpf", EntryType.FileRequired },
            { "levels_0.rpf", EntryType.FileRequired },
            { "levels_1.rpf", EntryType.FileRequired },
            { "levels_2.rpf", EntryType.FileRequired },
            { "levels_3.rpf", EntryType.FileRequired },
            { "levels_4.rpf", EntryType.FileRequired },
            { "levels_5.rpf", EntryType.FileRequired },
            { "levels_6.rpf", EntryType.FileRequired },
            { "levels_7.rpf", EntryType.FileRequired },
            { "movies_0.rpf", EntryType.FileRequired },
            { "packs_0.rpf", EntryType.FileRequired },
            { "packs_1.rpf", EntryType.FileRequired },
            { "rowpack_0.rpf", EntryType.FileRequired },
            { "shaders_x64.rpf", EntryType.FileRequired },
            { "textures_0.rpf", EntryType.FileRequired },
            { "textures_1.rpf", EntryType.FileRequired },
            { "update.rpf", EntryType.FileRequired },
        };
    }
}
