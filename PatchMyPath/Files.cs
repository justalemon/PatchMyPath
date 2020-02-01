using System;
using System.Collections.Generic;

namespace PatchMyPath
{
    /// <summary>
    /// The type of filesystem entry for the game content.
    /// </summary>
    [Flags]
    public enum EntryType
    {
        File = 1,
        Folder = 2,
        Optional = 4,
        Copy = 8,
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
            { "ReadMe", EntryType.Folder | EntryType.Optional },
            { "Redistributables", EntryType.Folder | EntryType.Optional },
            { "update", EntryType.Folder },
            { "x64", EntryType.Folder },

            { "GTA5.exe", EntryType.File | EntryType.Copy },
            { "GTAVLanguageSelect.exe", EntryType.File | EntryType.Optional | EntryType.Copy },
            { "GTAVLauncher.exe", EntryType.File | EntryType.Copy },
            { "PlayGTAV.exe", EntryType.File | EntryType.Optional | EntryType.Optional },
            { "bink2w64.dll", EntryType.File },
            { "d3dcompiler_46.dll", EntryType.File },
            { "d3dcsx_46.dll", EntryType.File },
            { "GFSDK_ShadowLib.win64.dll", EntryType.File },
            { "GFSDK_TXAA.win64.dll", EntryType.File },
            { "GFSDK_TXAA_AlphaResolve.win64.dll", EntryType.File },
            { "GPUPerfAPIDX11-x64.dll", EntryType.File | EntryType.Optional },
            { "NvPmApi.Core.win64.dll", EntryType.File },
            { "steam_api64.dll", EntryType.File | EntryType.Optional },
            { "index.bin", EntryType.File | EntryType.Optional },
            { "common.rpf", EntryType.File },
            { "x64a.rpf", EntryType.File },
            { "x64b.rpf", EntryType.File },
            { "x64c.rpf", EntryType.File },
            { "x64d.rpf", EntryType.File },
            { "x64e.rpf", EntryType.File },
            { "x64f.rpf", EntryType.File },
            { "x64g.rpf", EntryType.File },
            { "x64h.rpf", EntryType.File },
            { "x64i.rpf", EntryType.File },
            { "x64j.rpf", EntryType.File },
            { "x64k.rpf", EntryType.File },
            { "x64l.rpf", EntryType.File },
            { "x64m.rpf", EntryType.File },
            { "x64n.rpf", EntryType.File },
            { "x64o.rpf", EntryType.File },
            { "x64p.rpf", EntryType.File },
            { "x64q.rpf", EntryType.File },
            { "x64r.rpf", EntryType.File },
            { "x64s.rpf", EntryType.File },
            { "x64t.rpf", EntryType.File },
            { "x64u.rpf", EntryType.File },
            { "x64v.rpf", EntryType.File },
            { "x64w.rpf", EntryType.File },
            { "version.txt", EntryType.File | EntryType.Optional },
        };
        /// <summary>
        /// The filesystem entries for Red Dead Redemption 2.
        /// </summary>
        public static readonly Dictionary<string, EntryType> RDR2 = new Dictionary<string, EntryType>()
        {
            { ".egstore", EntryType.Folder | EntryType.Optional },
            { "12on7", EntryType.Folder },
            { "Redistributables", EntryType.Folder | EntryType.Optional },
            { "x64", EntryType.Folder },

            { "PlayRDR2.exe", EntryType.File | EntryType.Copy | EntryType.Optional },
            { "RDR2.exe", EntryType.File | EntryType.Copy },
            { "amd_ags_x64.dll", EntryType.File },
            { "bink2w64.dll", EntryType.File },
            { "dxilconv7.dll", EntryType.File },
            { "oo2core_5_win64.dll", EntryType.File },
            { "vulkan-1.dll", EntryType.File | EntryType.Optional },
            { "index.bin", EntryType.File | EntryType.Optional },
            { "anim_0.rpf", EntryType.File },
            { "appdata0_update.rpf", EntryType.File },
            { "common_0.rpf", EntryType.File },
            { "data_0.rpf", EntryType.File },
            { "hd_0.rpf", EntryType.File },
            { "levels_0.rpf", EntryType.File },
            { "levels_1.rpf", EntryType.File },
            { "levels_2.rpf", EntryType.File },
            { "levels_3.rpf", EntryType.File },
            { "levels_4.rpf", EntryType.File },
            { "levels_5.rpf", EntryType.File },
            { "levels_6.rpf", EntryType.File },
            { "levels_7.rpf", EntryType.File },
            { "movies_0.rpf", EntryType.File },
            { "packs_0.rpf", EntryType.File },
            { "packs_1.rpf", EntryType.File },
            { "rowpack_0.rpf", EntryType.File },
            { "shaders_x64.rpf", EntryType.File },
            { "textures_0.rpf", EntryType.File },
            { "textures_1.rpf", EntryType.File },
            { "update.rpf", EntryType.File },
        };
    }
}
