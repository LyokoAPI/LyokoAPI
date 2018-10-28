using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class Events
    {
        public delegate void OnTowerEvent(ITower tower);

        public delegate void OnLyokoEvent();
    }
}