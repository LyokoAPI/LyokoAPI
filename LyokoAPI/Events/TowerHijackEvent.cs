using System.Reflection;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class TowerHijackEvent
    {
        private static event Events.OnActivatorSwitch TowerHijackE;


        public static void Call(ITower tower, APIActivator old, APIActivator newactivator)
        {
            if (Events.AllLocked || (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master)))
            {
                return;
            }
            TowerHijackE?.Invoke(tower,old,newactivator);
        }

        public static Events.OnActivatorSwitch Subscribe(Events.OnActivatorSwitch func)
        {
            TowerHijackE += func;
            return func;
        }

        public static void Unsubscribe(Events.OnActivatorSwitch func)
        {
            TowerHijackE -= func;
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