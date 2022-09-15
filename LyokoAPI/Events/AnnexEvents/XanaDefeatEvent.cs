using System.Reflection;

namespace LyokoAPI.Events
{
    public class XanaDefeatEvent
    {
        private static event Events.OnLyokoEvent XanaDefeatE;
        
        public static void Call()
        {
            if (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return;
            }
            XanaDefeatE?.Invoke();
        }

        internal static Events.OnLyokoEvent Subscribe(Events.OnLyokoEvent func)
        {
            XanaDefeatE += func;
            return func;
        }

        internal static void Unsubscribe(Events.OnLyokoEvent func)
        {
            XanaDefeatE -= func;
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