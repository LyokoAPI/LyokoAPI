using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class XanaAwakenEvent
    {
        private static event Events.OnTowerEvent XanaAwakenE;

        public static void Call(ITower tower)
        {
            if (tower.Activated && tower.Activator == APIActivator.XANA)
            {
                XanaAwakenE?.Invoke(tower);
            }
        }

        public static Events.OnTowerEvent Subscribe(Events.OnTowerEvent func)
        {
            XanaAwakenE += func;
            return func;
        }

        public static void Unsubscribe(Events.OnTowerEvent func)
        {
            XanaAwakenE += func;
        }
    }
}