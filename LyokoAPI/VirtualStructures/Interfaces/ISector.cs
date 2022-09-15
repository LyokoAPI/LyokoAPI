using System.Collections.Generic;
using LyokoAPI.RealWorld.Location;
using LyokoAPI.RealWorld.Location.Abstract;

namespace LyokoAPI.VirtualStructures.Interfaces
{
    public interface ISector : ILocation<ISector>
    {
        string Name { get; }
        List<ITower> Towers { get; }
        IVirtualWorld World { get; }
    }
}