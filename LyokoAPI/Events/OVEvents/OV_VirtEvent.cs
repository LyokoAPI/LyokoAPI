using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events.OVEvents
{
    public class OV_VirtEvent
    {
        public static event Events.OnOvervehicleEvent OvE;

        public static void Call(Overvehicle overvehicle, ISector sector)
        {
            overvehicle.Virtualize(sector);
            OvE?.Invoke(overvehicle);
        }

        public static void Call(Overvehicle overvehicle, LyokoWarrior warrior)
        {
            overvehicle.Virtualize(warrior);
            OvE?.Invoke(overvehicle);
        }
        public static void Call(Overvehicle overvehicle, string virtualworld, string sector)
        {
            Call(overvehicle, new APISector(virtualworld, sector));
        }
        public static void Call(Overvehicle overvehicle, string sector)
        {
            Call(overvehicle, new APISector("Lyoko", sector));
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
