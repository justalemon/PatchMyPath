namespace PatchMyPath
{
    public enum InstallType : int
    {
        Clean = 1,
        Modded = 2,
        Fast = 3
    }

    public enum FileType : int
    {
        FoundNotGame = 1,
        FoundIsGame = 2,
        NotFound = 3
    }
}
