namespace IFSCLAPI.VirtualStructures
{
    public class Tower : ITower
    {
        public int Number { get; }
        public bool Activated { get; }
        public ISector Sector { get; }

        public Tower(int number, ISector sector, bool activated = false)
        {
            Number = number;
            Sector = sector;
            Activated = activated;
        }
    }
}