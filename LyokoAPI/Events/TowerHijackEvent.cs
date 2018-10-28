using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class TowerHijackEvent
    {
        private static event Events.OnActivatorSwitch TowerHijackE;

        public static void Call(ITower tower, APIActivator old, APIActivator newactivator)
        {
            TowerHijackE?.Invoke(tower,old,newactivator);
        }

        public static Events.OnActivatorSwitch Subscribe(Events.OnActivatorSwitch func)
        {
            TowerHijackE += func;
            return func;
        }

        public static void Unsubscribe(Events.OnActivatorSwitch func)
        {
            TowerHijackE -= func;
        }
    }
}