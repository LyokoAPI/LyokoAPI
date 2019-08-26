namespace LyokoAPI.API.Compatibility
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