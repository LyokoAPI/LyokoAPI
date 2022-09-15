namespace LyokoAPI.Commands
{
    public interface ICommand
    { 
        string Name { get; }
        string DisplayName { get; }
        void Run(string[] args);
    }
}