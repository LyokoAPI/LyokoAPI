using System.Collections.Generic;

namespace IFSCLAPI
{
    public interface ISector
    {
        string Name { get; }
        List<ITower> Towers { get; }
        IVirtualWorld World { get; }
    }
}