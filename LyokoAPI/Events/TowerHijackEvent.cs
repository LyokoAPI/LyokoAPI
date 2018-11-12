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
            if ((IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master)))
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