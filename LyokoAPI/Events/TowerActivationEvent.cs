using System;
using LyokoAPI.API;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class TowerActivationEvent
    {
        public delegate void onTowerActivation(ITower tower);

        private static event onTowerActivation TowerActivationE;
        
        public static void Call(ITower tower, string activator)
        {
            tower.Activated = true;
            tower.Activator = LyokoParser.ParseActivator(activator);
            TowerActivationE?.Invoke(tower);
        }

        public static void Subscribe(onTowerActivation func)
        {
           TowerActivationE += func;
        }

        public static void UnSubscribe(onTowerActivation func)
        {
            for (var index = 0; index < TowerActivationE.GetInvocationList().Length; index++)
            {
                var subscription = TowerActivationE.GetInvocationList()[index];
                if (subscription.Equals(func))
                {
                    TowerActivationE -= func;
                }
            }
        }
    }
}