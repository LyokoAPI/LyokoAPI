using System;
using LyokoAPI.Events;

namespace LyokoAPI.Plugin
{
    public abstract class LyokoAPIPlugin
    {
        public abstract string Name { get; }
        public abstract string Author { get; }
        public bool Enabled { get; private set; }

    
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
                LyokoLogger.Log("LyokoAPIPlugin",$"{ToString()} threw an exception while enabling: {e.StackTrace}");
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
                LyokoLogger.Log("LyokoAPIPlugin",$"{ToString()} threw an exception while disabling: {e.StackTrace}");
            }
            

            return Enabled;
        }
        

        public override string ToString()
        {
            return $"The plugin {Name} by {Author}";
        }

        public abstract void OnGameStart(bool storyMode);
        public abstract void OnGameEnd(bool failed);
    }
}