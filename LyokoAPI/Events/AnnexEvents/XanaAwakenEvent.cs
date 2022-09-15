using System.Reflection;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class XanaAwakenEvent
    {
        private static event Events.OnLyokoEvent XanaAwakenE;
        
        public static void Call()
        {
            if (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return;
            }
            XanaAwakenE?.Invoke();
            
        }

        internal static Events.OnLyokoEvent Subscribe(Events.OnLyokoEvent func)
        {
            XanaAwakenE += func;
            return func;
        }

        internal static void Unsubscribe(Events.OnLyokoEvent func)
        {
            XanaAwakenE -= func;
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