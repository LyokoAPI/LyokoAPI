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
            if ((IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master)))
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
            if ((IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master)))
            {
                return;
            }
            tower.Activator = activator;
            Call(tower);
        }

        public static void Call(string vworld, string sector, int number, string activator)
        {
            if ((IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master)))
            {
                return;
            }
            APITower tower = new APITower(vworld,sector,number);
            tower.Activator = LyokoParser.ParseActivator(activator);
            Call(tower);
        }

        internal static Events.OnTowerEvent Subscribe(Events.OnTowerEvent func)
        {
            TowerActivationE += func;
            return func;
        }

        internal static void Unsubscribe(Events.OnTowerEvent func)
        {
           TowerActivationE -= func;
        }

        #region locking
        private static bool _isLocked;
        public static bool IsLocked
        {
            get => _isLocked || Events.AllLocked;
            internal set => _isLocked = value;
        }
        /*
         * Returns true if the lock was successful. 
         */
        public static bool Lock()
        {
            if (Events.hasMaster && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return false;
            }
            IsLocked = true;
            return IsLocked;
        }
        /*
         * Returns true if the unlock was successful
         */
        public static bool UnLock()
        {
            if (Events.hasMaster && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return false;
            }
            IsLocked = false;
            return !IsLocked;
        }
        #endregion
    }
}
