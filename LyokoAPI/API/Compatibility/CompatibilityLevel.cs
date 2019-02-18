namespace LyokoAPI.API
{
    public enum CompatibilityLevel : byte
    {
        None = 0,
        MajorVersion,
        MinorVersion,
        Subversion,
        Full,
    }
}