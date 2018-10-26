using System.Collections.Generic;

namespace IFSCLAPI.VirtualStructures
{
    public class Sector : ISector
    {
        public string Name { get; }
        public List<ITower> Towers { get; }
        public IVirtualWorld World { get; }

        public Sector(string name, IVirtualWorld world , params ITower[] towers)
        {
            Name = name;
            Towers = new List<ITower>();
            Towers.AddRange(towers);
            World = world;
        }
         
    }
}