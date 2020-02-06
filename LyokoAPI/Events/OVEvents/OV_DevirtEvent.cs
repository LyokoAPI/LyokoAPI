using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events.OVEvents
{
    public class OV_DevirtEvent
    {
        public static event Events.OnOvervehicleEvent OvE;

        public static void Call(Overvehicle overvehicle)
        {
            overvehicle.Devirtualize();
            OvE?.Invoke(overvehicle);
        }

        internal static Events.OnOvervehicleEvent Subscribe(Events.OnOvervehicleEvent func)
        {

            OvE += func;
            return func;
        }

        internal static void Unsubscribe(Events.OnOvervehicleEvent func)
        {
            OvE -= func;
        }
    }
}
