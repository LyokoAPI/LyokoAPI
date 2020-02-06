using System.Reflection;
using LyokoAPI.API;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class SectorCreationEvent
    {
        private static event Events.OnSectorEvent SectorE;
        public static void Call(ISector sector)
        {
            if (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return;
            }
            SectorE?.Invoke(sector);
        }

        public static void Call(string world, string sector, int towers = 10)
        {
            if (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return;
            }
            APISector _sector = new APISector(world, sector, towers);
            Call(_sector);
        }

        public static void Call(string sector, int towers = 10)
        {
            if (IsLocked && !Assembly.GetCallingAssembly().Equals(Events.Master))
            {
                return;
            }
            APISector _sector = new APISector("Lyoko", sector, towers);
            Call(_sector);
        }

        internal static Events.OnSectorEvent Subscribe(Events.OnSectorEvent func)
        {
            SectorE += func;
            return func;
        }

        internal static void Unsubscribe(Events.OnSectorEvent func)
        {
            SectorE -= func;
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
