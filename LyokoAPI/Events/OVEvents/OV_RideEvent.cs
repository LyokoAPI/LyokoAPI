using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events.OVEvents
{
    public class OV_RideEvent
    {
        public static event Events.OnOvervehicleRideEvent OvRE;

        public static void Call(Overvehicle overvehicle, LyokoWarrior warrior)
        {
            overvehicle.Ride(warrior);
            OvRE?.Invoke(overvehicle, warrior);
        }

        public static Events.OnOvervehicleRideEvent Subscribe(Events.OnOvervehicleRideEvent func)
        {
            OvRE += func;
            return func;
        }

        public static void Unsubscribe(Events.OnOvervehicleRideEvent func)
        {
            OvRE -= func;
        }
    }
}
