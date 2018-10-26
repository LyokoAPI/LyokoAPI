using System.Collections.Generic;
using IFSCLAPI.VirtualStructures.Interfaces;

namespace IFSCLAPI.VirtualStructures
{
    public class APISector : ISector
    {
        public string Name { get; }
        public List<ITower> Towers { get; }
        public IVirtualWorld World { get; }

        public APISector(IVirtualWorld world ,string name, params ITower[] towers)
        {
            Name = name;
            Towers = new List<ITower>();
            Towers.AddRange(towers);
            World = world;
        }

        public APISector(string virtualworldName, string sectorName, params ITower[] towers) 
            : this(new APIVirtualWorld(virtualworldName), sectorName, towers)
        {
            World.Sectors.Add(this);
        }
         
    }
}