using System;
using System.Reflection;
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
            if (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return;
            }
            if (tower.Activated)
            {
                TowerActivationE?.Invoke(tower);
            }
        }

        public static void Call(APITower tower, APIActivator activator)
        {
            if (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return;
            }
            tower.Activator = activator;
            Call(tower);
        }

        public static void Call(string vworld, string sector, int number, string activator)
        {
            if (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return;
            }
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
        
        #region locking
        public static bool IsLocked { get; internal set; }
        /*
         * Returns true if the lock was successful. 
         */
        public static bool Lock()
        {
            if (Assembly.GetCallingAssembly().Equals(Events.Master) && !Events.LockingDisabled)
            {
                IsLocked = true;
            }

            return IsLocked;
        }
        /*
         * Returns true if the unlock was successful
         */
        public static bool UnLock()
        {
            if (IsLocked && Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                IsLocked = false;
            }

            return !IsLocked;
        }
        #endregion
    }
}
