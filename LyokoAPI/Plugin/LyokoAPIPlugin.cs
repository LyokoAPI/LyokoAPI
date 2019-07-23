using System;
using System.Collections.Generic;
using System.Reflection;
using LyokoAPI.API;
using LyokoAPI.Events;

namespace LyokoAPI.Plugin
{
    public abstract class LyokoAPIPlugin
    {
        public LyokoAPIPlugin()
        {
            ConfigManager = new ConfigManager(this);
        }

        public abstract string Name { get; }
        public abstract string Author { get; }
        public bool Enabled { get; private set; }
        public virtual LVersion Version { get; } = "0.0";
        public virtual List<LVersion> CompatibleLAPIVersions { get;} = new List<LVersion>(){"0.0"};
        protected internal ConfigManager ConfigManager { get;  set; }
        public virtual List<Dependency> Dependencies { get; } = new List<Dependency>(){};
        protected abstract bool OnEnable();
        protected abstract bool OnDisable();

        public bool Enable()
        {
            try
            {
                bool succeeded = OnEnable();
                if (!succeeded)
                {
                    LyokoLogger.Log("LyokoAPIPlugin",$"{ToString()} Didn't enable sucessfully, attempting to disable");
                    Disable();
                }
                else
                {
                    LyokoLogger.Log("LyokoAPIPlugin",$"{ToString()} Was enabled sucessfully");
                    Enabled = true;
                }
            }
            catch (Exception e)
            {
                LyokoLogger.Log("LyokoAPIPlugin",$"{ToString()} threw an exception while enabling: {e.ToString() + (e.Message)}");
                Disable();
            }

            return Enabled;
        }
        public bool Disable()
        {
            try
            {
                bool succeeded = OnDisable();
                if (!succeeded)
                {
                    LyokoLogger.Log("LyokoAPIPlugin",$"{ToString()} Didn't disable sucessfully");
                    Enabled = true;
                }
                else
                {
                    LyokoLogger.Log("LyokoAPIPlugin",$"{ToString()} Was disabled sucessfully");
                    Enabled = false;
                }
            }
            catch (Exception e)
            {
                LyokoLogger.Log("LyokoAPIPlugin",$"{ToString()} threw an exception while disabling: {e.GetType()} {e.StackTrace + (e.Message)}");
            }
            

            return Enabled;
        }
        

        public override string ToString()
        {
            return $"The plugin {Name} by {Author} (V {Version})";
        }

        public abstract void OnGameStart(bool storyMode);
        public abstract void OnGameEnd(bool failed);

        public abstract void OnInterfaceExit();
        public abstract void OnInterfaceEnter();
    }
}