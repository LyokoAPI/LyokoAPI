using System;
using LyokoAPI.API;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class TowerActivationEvent
    {

        private static event Events.OnTowerEvent TowerActivationE;
        
        public static void Call(ITower tower, string activator)
        {
            tower.Activated = true;
            tower.Activator = LyokoParser.ParseActivator(activator);
            TowerActivationE?.Invoke(tower);
        }

        public static Events.OnTowerEvent Subscribe(Events.OnTowerEvent func)
        {
           TowerActivationE += func;
            return func;
        }

        public static void UnSubscribe(Events.OnTowerEvent func)
        {
           TowerActivationE -= func;
        }
    }
}