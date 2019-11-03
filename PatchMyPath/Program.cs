using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

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

    public static class Program
    {
        /// <summary>
        /// The filesystem entries that are part of the game.
        /// </summary>
        public static readonly Dictionary<string, EntryType> FilesFolders = new Dictionary<string, EntryType>()
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
        /// The configuration of the program.
        /// </summary>
        public static Configuration Config = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static int Main()
        {
            // Enable the visual styles
            Application.EnableVisualStyles();
            // Disable the compatible text rendering
            Application.SetCompatibleTextRenderingDefault(false);

            // Try to parse the configuration
            try
            {
                Config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("PatchMyPath.json"), new InstallConverter());
            }
            // If the file was not found
            catch (FileNotFoundException)
            {
                MessageBox.Show("The Configuration File does not exists!\nPlease check that PatchMyPath.json is present and try again.");
                return 1;
            }
            // If the file could not be parsed
            catch (JsonSerializationException)
            {
                Console.WriteLine("The Configuration file is invalid!\nPlease make sure that the Curly Brackets and Comas are in the correct place.\nIf you know what you are doing: Use a Linter on a Code Editor/IDE.");
                return 2;
            }

            // And run the application with the form
            Application.Run(new Home());
            // Finally, return a status code of zero
            return 0;
        }

        /// <summary>
        /// Saves the current configuration.
        /// </summary>
        public static void SaveConfig()
        {
            // Serialize the configuration to a JSON string and add a new line at the end
            string output = JsonConvert.SerializeObject(Config, Formatting.Indented, new InstallConverter()) + Environment.NewLine;
            // Then, save that string on PatchMyPath.json
            File.WriteAllText("PatchMyPath.json", output);
        }
    }
}
