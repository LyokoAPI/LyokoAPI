using LyokoAPI.Events;
using LyokoAPI.Plugin;

namespace TestProject2
{
    public class DummyPlugin : LyokoAPIPlugin
    {
        public override string Name { get; } = "Dummy";
        public override string Author { get; } = "LyokoAPI";
        protected override bool OnEnable()
        {
            string value = "";
            if (ConfigManager.GetMainConfig().Values.ContainsKey("test"))
            {
                value = ConfigManager.GetMainConfig().Values["test"];
            }
            else
            {
                ConfigManager.GetMainConfig().Values["test"] = "no";
            }
            LyokoLogger.Log(Name,"Value:"+value);
            return true;
        }

        protected override bool OnDisable()
        {
            ConfigManager.SaveAllConfigs();
            return true;
        }

        public override void OnGameStart(bool storyMode)
        {
            //do nothing

        }

        public override void OnGameEnd(bool failed)
        {
            //do nothing
        }

        public override void OnInterfaceExit()
        {
            //do nothing
        }

        public override void OnInterfaceEnter()
        {
            //do nothing
        }
    }
}