namespace LyokoAPI.VirtualStructures.Interfaces
{
    public interface ITower
    {
        int Number { get; }
        bool Activated { get; set; }
        ISector Sector { get; }
        APIActivator Activator { get; set; }
    }
}