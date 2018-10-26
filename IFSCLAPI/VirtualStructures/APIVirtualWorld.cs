using System.Collections.Generic;
using IFSCLAPI.VirtualStructures.Interfaces;

namespace IFSCLAPI.VirtualStructures
{
    public class APIVirtualWorld : IVirtualWorld
    {
        public string Name { get; }

        public bool isLyoko { get; }

        public List<ISector> Sectors { get; }

        public APIVirtualWorld(string name,params ISector[] sectors )
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