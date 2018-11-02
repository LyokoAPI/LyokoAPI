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
            bool succeeded = OnEnable();
            if (!succeeded)
            {
                Logger.Log("LyokoAPIPlugin",$"{ToString()} Didn't enable sucessfully");
                Enabled = false;
            }
            else
            {
                Enabled = true;
            }

            return Enabled;
        }
        public bool Disable()
        {
            bool succeeded = OnDisable();
            if (!succeeded)
            {
                Logger.Log("LyokoAPIPlugin",$"{ToString()} Didn't disable sucessfully");
                Enabled = true;
            }
            else
            {
                Enabled = false;
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