using System.Reflection;

namespace LyokoAPI.Events
{
    public class CommandOutputEvent
    {
        private static event Events.OnStringEvent stringE;
        public static void Call(string sender, string message)
        {
            if (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return;
            }

            stringE?.Invoke($"[{sender}] {message}");
        }

        public static Events.OnStringEvent Subscribe(Events.OnStringEvent func)
        {
            stringE += func;
            return func;
        }

        public static void Unsubscribe(Events.OnStringEvent func)
        {
            stringE -= func;
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