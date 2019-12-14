using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace LyokoAPI.Plugin
{
    public class PluginConfig
    {
        public string FilePath { get; private set; }
        public string Name { get; private set; }
        public Dictionary<string, string> Values;
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
                Values = new Dictionary<string, string>();
                Values.Add("config_name",nameOrPath);
            }

        }

        private void Load(LyokoAPIPlugin plugin, string path)
        {
           /* var values =
                new YamlDotNet.Serialization.Deserializer().Deserialize<Dictionary<string, String>>(
                    new StringReader(path));
            */
           var input = new StringReader(File.ReadAllText(path));
           var deserializer = new DeserializerBuilder().Build();
           var values = deserializer.Deserialize<Dictionary<string,string>>(input);
           Name = values["config_name"];
           FilePath = Path.Combine(plugin.ConfigManager.PluginConfigDirectory,Name+".yaml");
           Values = values;
        }



        public void Write()
        {
            var serializer = new YamlDotNet.Serialization.Serializer();
            var file = serializer.Serialize(Values);
            File.Delete(FilePath);
            File.WriteAllText(new FileInfo(FilePath).FullName, file);
        }
    }
}