namespace LyokoAPI.Plugin
{
    public struct Dependency
    {
        public string NugetID { get;}
        public string VersionString { get;  }

        public Dependency(string nugetId, string versionString = null)
        {
            NugetID = nugetId;
            VersionString = versionString;
        }

        public static implicit operator Dependency(string nugetId)
        {
            return new Dependency(nugetId);
        }
        public static implicit operator Dependency(string[] idAndVersionArray)
        {
            return new Dependency(idAndVersionArray[0],idAndVersionArray[1]);
        }
    }
}