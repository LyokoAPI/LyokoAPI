using System.Collections.Generic;

namespace IFSCLAPI.VirtualStructures
{
    public class VirtualWorld : IVirtualWorld
    {
        public string Name { get; }

        public bool isLyoko { get; }

        public List<ISector> Sectors { get; }

        public VirtualWorld(string name,params ISector[] sectors )
        {
            Name = name;
            Sectors = new List<ISector>();
            Sectors.AddRange(sectors);
            if (name.ToLower().Equals("lyoko"))
            {
                isLyoko = true;
            }
            else
            {
                isLyoko = false;
            }
        }
    }
}