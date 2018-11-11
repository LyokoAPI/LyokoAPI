using System.Collections.Generic;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.VirtualStructures
{
    public class APISector : ISector
    {
        public string Name { get; }
        public List<ITower> Towers { get; }
        public IVirtualWorld World { get; }

        internal APISector(IVirtualWorld world ,string name, params ITower[] towers)
        {
            Name = name;
            Towers = new List<ITower>();
            Towers.AddRange(towers);
            World = world;
            World.Sectors.Add(this);
        }

        internal APISector(string virtualworldName, string sectorName, params ITower[] towers) 
            : this(new APIVirtualWorld(virtualworldName), sectorName, towers)
        {
            World.Sectors.Add(this);
        }

        public APISector(IVirtualWorld virtualworld, string sectorName, int towers = 0)
        {
            Name = sectorName;
            Towers = new List<ITower>();
            for (int i = 1; i <= towers; i++)
            {
                Towers.Add(new APITower(i,this));
            }

            World = virtualworld;
            if (!World.Sectors.Contains(this))
            {
                World.Sectors.Add(this);
            }
        }

        public APISector(string virtualworldName, string sectorName, int towers = 0)
            : this(new APIVirtualWorld(sectorName), sectorName, towers){}

    }
}