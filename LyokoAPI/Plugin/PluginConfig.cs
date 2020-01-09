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
        public Dictionary<string, string> Values { get; private  set; } = new Dictionary<string, string>();

        public String this[string key]
        {
            get => Values.ContainsKey(key) ? Values[key] : null;
            set => Values[key] = value;
        }
        protected internal PluginConfig(LyokoAPIPlugin plugin, string path)
        {
            if (File.Exists(path))
            {
                Load(plugin,path);
            }
            else
            {
                var file = File.Create(path);
                file.Close();
                Name = Path.GetFileNameWithoutExtension(path);
                FilePath = path;
                Values = new Dictionary<string, string>();
                Values.Add("config_name",Name);
            }

        }

        private void Load(LyokoAPIPlugin plugin, string path)
        {
           /* var values =
                new YamlDotNet.Serialization.Deserializer().Deserialize<Dictionary<string, String>>(
                    new StringReader(path));
            */
           var input = new StringReader(File.ReadAllText(path));
           //Prevents empty files from breaking the plugin
           if (File.ReadAllText(path).Length > 0)
           {
               var deserializer = new DeserializerBuilder().Build();
               var values = deserializer.Deserialize<Dictionary<string, string>>(input);
               Values = values;
               //string temp;
               //Values.TryGetValue("config_name", out temp);
               //Name = temp;
               try
               {
                   Name = Values["config_name"];
               }
               catch (KeyNotFoundException e)
               {
                   Name= Path.GetFileNameWithoutExtension(path);
               }
           }


           FilePath = path;
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