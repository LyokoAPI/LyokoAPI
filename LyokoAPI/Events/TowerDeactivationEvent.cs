using System.Reflection;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class TowerDeactivationEvent
    {

        private static event Events.OnTowerEvent TowerDeactivationE;

        public static void Call(ITower tower)
        {
            if ((IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master)))
            {
                return;
            }
            if (!tower.Activated)
            {
                TowerDeactivationE?.Invoke(tower);
            }
        }

        public static Events.OnTowerEvent Subscribe(Events.OnTowerEvent func)
        {
            TowerDeactivationE += func;
            return func;
        }

        public static void UnSubscribe(Events.OnTowerEvent func)
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
            return IsLocked = true;
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