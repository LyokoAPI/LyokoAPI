using LyokoAPI.RealWorld.Location.Abstract;

namespace LyokoAPI.VirtualStructures.Interfaces
{
    public interface ITower : ILocation<ITower>
    {
        int Number { get; }
        bool Activated { get; }
        ISector Sector { get; }
        APIActivator Activator { get; }
    }
}