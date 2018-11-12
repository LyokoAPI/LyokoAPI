using System.Reflection;
using System.Runtime.Remoting.Activation;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class Events
    {
        public static Assembly Master { get; private set; }
        public static bool hasMaster => Master != null;
        public static bool LockingDisabled { get; private set; }
        public static bool SetMaster()
        {
            if (!hasMaster)
            {
                Master = Assembly.GetCallingAssembly();
            }

            return hasMaster;
        }

        public static bool DisableLocking()
        {
            if ( hasMaster && Assembly.GetCallingAssembly().Equals(Master))
            {
                LockingDisabled = true;
            }

            return LockingDisabled;
        }
        public delegate void OnTowerEvent(ITower tower);

        public delegate void OnLyokoEvent();
        public delegate void OnActivatorSwitch(ITower tower, APIActivator old,APIActivator newactivator);

        public delegate void OnLogEvent(string message);
    }
}