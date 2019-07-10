using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace LyokoAPI.Plugin
{
    public class PluginConfig
    {
        public string FilePath { get; private set; }
        public string Name { get; private set; }
        public Dictionary<string, string> Values = new Dictionary<string, string>();
        public PluginConfig(LyokoAPIPlugin plugin, string nameOrPath)
        {
            if (File.Exists(nameOrPath))
            {
                Load(plugin,nameOrPath);
            }
            else
            {
                Name = nameOrPath;
                FilePath = Path.Combine(plugin.ConfigManager.PluginConfigDirectory,nameOrPath+".yaml");
                Values.Add("config_name",nameOrPath); 
            }
            
        }

        private void Load(LyokoAPIPlugin plugin, string path)
        {
            var values =
                new YamlDotNet.Serialization.Deserializer().Deserialize<Dictionary<string, String>>(
                    new StringReader(path));
            Name = values["config_name"];
            FilePath = Path.Combine(plugin.ConfigManager.PluginConfigDirectory,Name+".yaml");
            Values = values;
        }



        public void Write()
        {
            var serializer = new YamlDotNet.Serialization.Serializer();
            var file = serializer.Serialize(Values);
            File.WriteAllText(FilePath,file);
        }
    }
}