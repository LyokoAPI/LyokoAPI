using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class TowerDeactivationEvent
    {

        private static event Events.onTowerEvent TowerDeactivationE;

        public static void Call(ITower tower)
        {
            tower.Activated = false;
            tower.Activator = APIActivator.NONE;
            TowerDeactivationE.Invoke(tower);
        }

        public static Events.onTowerEvent Subscribe(Events.onTowerEvent func)
        {
            TowerDeactivationE += func;
            return func;
        }

        public static void UnSubscribe(Events.onTowerEvent func)
        {
            /*for (var index = 0; index < TowerDeactivationE.GetInvocationList().Length; index++)
            {
                var subcription = TowerDeactivationE.GetInvocationList()[index];
                if (subcription.Equals(func))
                {
                    TowerDeactivationE -= func;
                }
            }*/
            TowerDeactivationE -= func;
        }
    }
}