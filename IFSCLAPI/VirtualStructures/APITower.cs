using IFSCLAPI.VirtualStructures.Interfaces;

namespace IFSCLAPI.VirtualStructures
{
    public class APITower : ITower
    {
        public int Number { get; }
        public bool Activated { get; }
        public ISector Sector { get; }
        public APIActivator Activator { get; set; }

        public APITower(int number, ISector sector, bool activated = false)
        {
            Number = number;
            Sector = sector;
            Activated = activated;
        }

        public APITower(string vworld, string sector, int number, bool activated = false)
        {
            Number = number;
            Activated = activated;
            Sector = new APISector(vworld,sector,this);
        }
    }
    
}