namespace LyokoAPI.Plugin
{
    public interface LyokoAPIPlugin
    {
        bool OnEnable();
        bool OnDisable();
        
        string GetName();
        string GetAuthor();

        bool IsEnabled();

        void OnGameStart(bool storyMode);
        void OnGameEnd(bool failed);
    }
}