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

        public static onTowerActivation Subscribe(onTowerActivation func)
        {
           TowerActivationE += func;
            return func;
        }

        public static void UnSubscribe(onTowerActivation func)
        {
           TowerActivationE -= func;
        }
    }
}