using LyokoAPI.RealWorld.Location;
using LyokoAPI.RealWorld.Location.Abstract;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.VirtualEntities.LyokoWarrior
{
    public class LyokoWarrior
    {
        public static readonly int MAX_HP = 100;
        public LyokoWarriorName WarriorName { get; internal set; }
        public GenericLocation Location { get; private set; }
        public LW_Status Status { get; private set; }
        public int HP { get; private set; }

        internal LyokoWarrior(LyokoWarriorName warrior)
        {
            WarriorName = warrior;
            Location = APILocations.KADIC;
            Status = LW_Status.EARTH;
            HP = MAX_HP;
        }

        internal int Hurt(int damage)
        {
            if ((HP - damage) < 0 )
            {
                HP -= 0;
            }
            else
            {
                HP -= damage;
            }

            return HP;
        }
        
        internal int Heal(int ammount)
        {
            if ((HP + ammount) > MAX_HP)
            {
                HP = MAX_HP;
            }
            else
            {
                HP += ammount;
            }

            return HP;
        }

        internal int ResetHealth()
        {
            return Heal(MAX_HP);
        }

        internal LyokoWarrior Virtualize(ISector destination)
        {
            ChangeLocation(destination);
            ResetHealth();
            Status = LW_Status.VIRTUALIZED;
            return this;
        }

        internal LyokoWarrior Frontier()
        {
            Location = APILocations.FRONTIER;
            Status = LW_Status.FRONTIERED;
            return this;
        }

        internal LyokoWarrior CodeEarth(ILocation<APILocation> location)
        {
            ChangeLocation(location);
            Status = LW_Status.EARTH;
            ResetHealth();
            return this;
        }

        internal LyokoWarrior CodeEarth()
        {
            return CodeEarth(APILocations.SCANNERS);
        }

        internal LyokoWarrior Kill()
        {
            Location = APILocations.DEAD;
            Status = LW_Status.LOST;
            HP = 0;
            return this;
        }

        internal LyokoWarrior Xanafy()
        {
            Status = LW_Status.XANAFIED;
            return this;
        }

        internal LyokoWarrior Dexanafy()
        {
            Location = APILocations.SCANNERS;
            Status = LW_Status.EARTH;
            ResetHealth();
            return this;
        }

        internal LyokoWarrior Translate(ILocation<APILocation> location)
        {
            ChangeLocation(location);
            Status = LW_Status.TRANSLATED;
            return this;
        }
        
        internal LyokoWarrior ChangeLocation(ILocation<APILocation> location)
        {
            Location = location.AsGenericLocation();
            return this;
        }

        internal LyokoWarrior ChangeLocation(ILocation<ISector> location)
        {
            Location = location.AsGenericLocation();
            return this;
        }

    }
}