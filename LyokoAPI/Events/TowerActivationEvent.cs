using System;
using LyokoAPI.API;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class TowerActivationEvent
    {

        private static event Events.OnTowerEvent TowerActivationE;

        public static void Call(ITower tower)
        {
            if (tower.Activated)
            {
                TowerActivationE?.Invoke(tower);
            }
        }

        public static void Call(APITower tower, APIActivator activator)
        {
            tower.Activator = activator;
            Call(tower);
        }

        public static void Call(string vworld, string sector, int number, string activator)
        {
            APITower tower = new APITower(vworld,sector,number);
            tower.Activator = LyokoParser.ParseActivator(activator);
            Call(tower);
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
