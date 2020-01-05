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
        protected internal PluginConfig(LyokoAPIPlugin plugin, string path)
        {
            if (File.Exists(path))
            {
                Load(plugin,path);
            }
            else
            {
                Name = path;
                if (!path.Contains(".yaml"))
                {
                    FilePath = path + ".yaml";
                }
                else
                {
                    FilePath = Name;
                }
                Values = new Dictionary<string, string>();
                Values.Add("config_name",path);
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
           FilePath = path;
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