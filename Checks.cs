using System.IO;
using System.Diagnostics;

namespace PatchMyPath
{
    static class Checks
    {
        public static FileType CheckGameFile(string FileLocation)
        {
            bool Exists = File.Exists(FileLocation);
            string Product = string.Empty;
            FileVersionInfo FileInfo;

            if (Exists)
            {
                FileInfo = FileVersionInfo.GetVersionInfo(FileLocation);
                Product = FileInfo.ProductName;
            }

            if (Exists && Product == "Grand Theft Auto V")
                return FileType.FoundIsGame;
            else if (Exists)
                return FileType.FoundNotGame;
            else
                return FileType.NotFound;
        }
    }
}
