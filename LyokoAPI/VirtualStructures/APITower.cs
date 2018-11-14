using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.VirtualStructures
{
    public class APITower : ITower
    {
        public int Number { get; }
        
        public bool Activated => Activator != APIActivator.NONE;
        
        public ISector Sector { get; }
        public APIActivator Activator { get; set; }

        public APITower(ISector sector, int number)
        {
            Number = number;
            Sector = sector;
        }

        public APITower(string vworld, string sector, int number)
        {
            Number = number;
            Sector = new APISector(vworld,sector,this);
        }

        public override bool Equals(object obj)
        {
            if (obj is ITower)
            {
                ITower otherTower = (APITower)obj;
                return otherTower.Sector.World.Name.Equals(Sector.World.Name) && otherTower.Sector.Name.Equals(Sector.Name) && otherTower.Number.Equals(Number);
            }
            else
            {
                return false;
            }
        }

        
    }
    
    
}