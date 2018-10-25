using System.Collections.Generic;

namespace IFSCLAPI.VirtualStructures
{
    public class VirtualWorld : IVirtualWorld
    {
        public string Name { get; }
        public bool isLyoko { get; }
        public List<ISector> Sectors { get; }

        public VirtualWorld(string name, bool Lyoko = false,params ISector[] sectors )
        {
            Name = name;
            isLyoko = Lyoko;
            Sectors = new List<ISector>();
            Sectors.AddRange(sectors);
        }
    }
}