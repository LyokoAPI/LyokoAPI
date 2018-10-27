using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class TowerDeactivationEvent
    {
        public delegate void onTowerDeactivation(ITower tower);

        private static event onTowerDeactivation TowerDeactivationE;

        public static void Call(ITower tower)
        {
            tower.Activated = false;
            tower.Activator = APIActivator.NONE;
            TowerDeactivationE.Invoke(tower);
        }

        public static void Subscribe(onTowerDeactivation func)
        {
            TowerDeactivationE += func;
        }

        public static void UnSubscribe(onTowerDeactivation func)
        {
            for (var index = 0; index < TowerDeactivationE.GetInvocationList().Length; index++)
            {
                var subcription = TowerDeactivationE.GetInvocationList()[index];
                if (subcription.Equals(func))
                {
                    TowerDeactivationE -= func;
                }
            }
        }
    }
}