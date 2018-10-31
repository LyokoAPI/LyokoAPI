namespace LyokoAPI.Plugin
{
    public interface LyokoAPIPlugin
    {
        string Name { get; }
        string Author { get; }
        bool Enabled { get; }
        
        bool OnEnable();
        bool OnDisable();

        void OnGameStart(bool storyMode);
        void OnGameEnd(bool failed);
    }
}