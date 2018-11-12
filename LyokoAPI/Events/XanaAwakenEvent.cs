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
            if (Events.AllLocked || (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master)))
            {
                return;
            }
            XanaAwakenE?.Invoke();
            
        }

        public static Events.OnLyokoEvent Subscribe(Events.OnLyokoEvent func)
        {
            XanaAwakenE += func;
            return func;
        }

        public static void Unsubscribe(Events.OnLyokoEvent func)
        {
            XanaAwakenE += func;
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