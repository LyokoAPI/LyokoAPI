namespace LyokoAPI.Plugin
{
    public interface LyokoAPIPlugin
    {
        bool onEnable();
        bool onDisable();

        void onGameStart(bool storyMode);
        void onGameEnd(bool failed);
    }
}