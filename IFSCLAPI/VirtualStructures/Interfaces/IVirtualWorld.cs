using System.Collections.Generic;

namespace IFSCLAPI
{
    public interface IVirtualWorld
    {
        string Name { get; }
        bool isLyoko { get; }
        List<ISector> Sectors { get; }
    }
}