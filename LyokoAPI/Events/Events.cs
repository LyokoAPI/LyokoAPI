using System;
using System.Reflection;
using System.Runtime.Remoting.Activation;
using LyokoAPI.Events.EventArgs;
using LyokoAPI.VirtualEntities;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class Events
    {
        public static Assembly Master { get; private set; }
        public static bool hasMaster => Master != null;
        public static bool AllLocked { get; private set; }
        [Obsolete("This won't actually do anything, though it might be re-enabled in the future")]
        public static bool SetMaster()
        {
            /*if (!hasMaster)
            {
                Master = Assembly.GetCallingAssembly();
            }*/

            return hasMaster;
        }

        public static bool LockAll()
        {
            if ( hasMaster && Assembly.GetCallingAssembly().Equals(Master))
            {
                AllLocked = true;
            }
 
            return AllLocked;
        }

        public static bool UnlockAll()
        {
            if ( hasMaster && Assembly.GetCallingAssembly().Equals(Master))
            {
                AllLocked = false;
            }

            return !AllLocked;
        }
        public delegate void OnTowerEvent(ITower tower);

        public delegate void OnLyokoEvent();
        public delegate void OnActivatorSwitch(ITower tower, APIActivator old,APIActivator newactivator);
        
        public delegate void OnLogEvent(string arg);//Should properly deprecate this

        public delegate void OnStringEvent(string arg);

        public delegate void OnLyokoWEvent(LyokoWarriorName warriorName);


    }
}