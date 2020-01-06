using System;
using LyokoAPI.Plugin;

namespace TestProject2
{
    public class TestPlugin : LyokoAPIPlugin
    {
        public override string Name { get; } = "testPlugin";
        public override string Author { get; } = "LyokoAPI";
        protected override bool OnEnable()
        {
            //Console.WriteLine(ConfigManager.GetMainConfig().Values.ToString());
            ConfigManager.GetMainConfig().CreateValue("hello","hello");
            if (ConfigManager.GetMainConfig().GetValue("something") == "thesamething")
            {
                Console.WriteLine("ITS THE SAME THING AAAAAA");
            }
            else
            {
                ConfigManager.GetMainConfig().UpdateValue("something","somethingElse");
            }
            return true;
        }

        protected override bool OnDisable()
        {
            ConfigManager.SaveAllConfigs();
            return true;
        }

        public override void OnGameStart(bool storyMode)
        {
            //
        }

        public override void OnGameEnd(bool failed)
        {
            //
        }

        public override void OnInterfaceExit()
        {
            //
        }

        public override void OnInterfaceEnter()
        {
           //
        }
    }
}