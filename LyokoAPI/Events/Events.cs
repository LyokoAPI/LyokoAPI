using System.Runtime.Remoting.Activation;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class Events
    {
        public delegate void OnTowerEvent(ITower tower);

        public delegate void OnLyokoEvent();
        public delegate void OnActivatorSwitch(ITower tower, APIActivator old,APIActivator newactivator);

        public delegate void OnLogEvent(string message);
    }
}