using System.Collections.Generic;

namespace IFSCLAPI.VirtualStructures.Interfaces
{
    public interface IVirtualWorld
    {
        string Name { get; }
        bool isLyoko { get; }
        List<ISector> Sectors { get; }
    }
}