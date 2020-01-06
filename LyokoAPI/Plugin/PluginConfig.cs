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
        private Dictionary<string, string> Values { get;  set; }
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
                Name = Path.GetFileName(path).Replace(".yaml","");
                FilePath = path;
                Values = new Dictionary<string, string>();
                Values.Add("config_name",Name);
            }

        }

        //This prevents plugins from wiping the Values variable and causing in errors

        public string GetValue(string key)
        {
            /*if (Values.ContainsKey(key))
                return Values[key];
            return "";*/
            string value;
            Values.TryGetValue(key, out value);
            return value;
        }
        
        public void CreateValue(string key, string value)
        {
            if (!Values.ContainsKey(key))
                Values[key] = value;
            else
            {
                UpdateValue(key, value);
            }
        }

        public void UpdateValue(string key, string value)
        {
            if (Values.ContainsKey(key))
                Values[key] = value;
            else
            {
                CreateValue(key,value);
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
               Name = GetValue("config_name");
               Console.WriteLine(Name);
           }
           else{
               Values=new Dictionary<string, string>();
               Values.Add("empty","empty");
           }

           FilePath = path;
        }



        public void Write()
        {
            var serializer = new YamlDotNet.Serialization.Serializer();
            var file = serializer.Serialize(Values);
            Console.WriteLine(file);
            File.Delete(FilePath);
            File.WriteAllText(new FileInfo(FilePath).FullName, file);
        }
    }
}