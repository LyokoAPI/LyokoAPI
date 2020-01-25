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
        public OV_Status Status { get; private set; }
        public int HP { get; private set; }
        public LyokoWarrior.LyokoWarrior WarriorRider { get; internal set; }
        public LyokoWarrior.LyokoWarrior WarriorPassenger { get; internal set; }

        internal Overvehicle(OvervehicleName overvehicle)
        {
            OvervehicleName = overvehicle;
            Location = APILocations.DEAD;
            Status = OV_Status.DEVIRTUALIZED;
            WarriorRider = null;
            WarriorPassenger = null;
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
            Status = OV_Status.VIRTUALIZED;
            return this;
        }
        
        internal Overvehicle Virtualize(LyokoWarrior.LyokoWarrior warrior)
        {
            Location = warrior.Location;
            ResetHealth();
            Status = OV_Status.VIRTUALIZED;
            return this;
        }

        internal Overvehicle Devirtualize()
        {
            Location = APILocations.DEAD;
            WarriorRider = null;
            WarriorPassenger = null;
            Status = OV_Status.DEVIRTUALIZED;
            return this;
        }

        internal Overvehicle Ride(LyokoWarrior.LyokoWarrior warrior)
        {
            if (WarriorRider == null)
                WarriorRider = warrior;
            else if (WarriorPassenger == null)
                WarriorPassenger = warrior;
            else
                LyokoLogger.Log("LAPI", $"{OvervehicleName} is already fully occupied.");
            return this;
        }

        internal Overvehicle GetOff(LyokoWarrior.LyokoWarrior warrior)
        {
            if (WarriorRider == warrior)
            {
                WarriorRider = WarriorPassenger;
                WarriorPassenger = null;
            }
            else if (WarriorPassenger == warrior)
                WarriorPassenger = null;
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
