namespace LyokoAPI.Plugin
{
    public class PluginDependency
    {
        public string Id { get; set; }
        public bool PreRelease { get; set; }
        public string Version { get; set; }

        public PluginDependency(string id,  string version, bool preRelease = false)
        {
            Id = id;
            PreRelease = preRelease;
            Version = version;
        }
    }
}