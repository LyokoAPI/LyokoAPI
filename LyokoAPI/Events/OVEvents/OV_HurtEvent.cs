using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events.OVEvents
{
    public class OV_HurtEvent
    {
        public static event Events.OnOvervehicleEvent OvE;

        public static void Call(Overvehicle overvehicle, int damage)
        {
            if (damage < 0)
            {
                LyokoLogger.Log("LAPI","App attempted to deal negative damage to OV");
                return;
            }
            overvehicle.Hurt(damage);
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
