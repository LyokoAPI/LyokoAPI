using LyokoAPI.RealWorld.Location;
using LyokoAPI.RealWorld.Location.Abstract;
using LyokoAPI.VirtualStructures.Interfaces;
using LyokoAPI.Events;

namespace LyokoAPI.VirtualEntities.Overvehicle
{
    public class Overvehicle
    {
        public static readonly int MAX_HP=100;
        public OvervehicleName OvervehicleName { get; internal set; }
        public GenericLocation Location { get; private set; } //Possibly irrevelant in the future
        public Status Status { get; private set; }
        public int HP { get; private set; }
        public LyokoWarrior.LyokoWarrior WarriorRider { get; internal set; }
        public LyokoWarrior.LyokoWarrior WarriorPassanger { get; internal set; }

        internal Overvehicle(OvervehicleName overvehicle)
        {
            OvervehicleName = overvehicle;
            Location = APILocations.DEAD;
            Status = Status.DEVIRTUALIZED;
            WarriorRider = null;
            WarriorPassanger = null;
            HP = MAX_HP;
        }

        internal int Hurt(int damage)
        {
            if ((HP - damage) < 0)
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

        internal Overvehicle Virtualize(ISector destination)
        {
            Move(destination);
            ResetHealth();
            Status = Status.VIRTUALIZED;
            return this;
        }
        
        internal Overvehicle Virtualize(LyokoWarrior.LyokoWarrior warrior)
        {
            Location = warrior.Location;
            ResetHealth();
            Status = Status.VIRTUALIZED;
            return this;
        }

        internal Overvehicle Devirtualize()
        {
            Location = APILocations.DEAD;
            WarriorRider = null;
            WarriorPassanger = null;
            Status = Status.DEVIRTUALIZED;
            return this;
        }

        internal Overvehicle Ride(LyokoWarrior.LyokoWarrior warrior)
        {
            if (WarriorRider == null)
                WarriorRider = warrior;
            else if (WarriorPassanger == null)
                WarriorPassanger = warrior;
            else
                LyokoLogger.Log("LAPI", $"{OvervehicleName} is already fully occupied.");
            return this;
        }

        internal Overvehicle GetOff(LyokoWarrior.LyokoWarrior warrior)
        {
            if (WarriorRider == warrior)
            {
                WarriorRider = WarriorPassanger;
                WarriorPassanger = null;
            }
            else if (WarriorPassanger == warrior)
                WarriorPassanger = null;
            else
                LyokoLogger.Log("LAPI", $"{warrior} is not riding {OvervehicleName}.");
            return this;
        }

        internal Overvehicle Move(ILocation<APILocation> location)
        {
            Location = location.AsGenericLocation();
            return this;
        }

        internal Overvehicle Move(ILocation<ISector> location)
        {
            Location = location.AsGenericLocation();
            return this;
        }
    }
}
