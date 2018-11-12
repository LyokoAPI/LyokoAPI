using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class XanaAwakenEvent
    {
        private static event Events.OnLyokoEvent XanaAwakenE;

        public static void Call()
        {
            
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
    }
}