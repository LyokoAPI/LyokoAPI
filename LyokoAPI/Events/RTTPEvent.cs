using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events
{
    public class RTTPEvent
    {
        public static event Events.OnRealWorldEvent rttpE;

        public static void Call() {
            rttpE?.Invoke();
        }

        public static Events.OnRealWorldEvent Subscribe(Events.OnRealWorldEvent func)
        {
            rttpE += func;
            return func;
        }

        public static void Unsubscribe(Events.OnRealWorldEvent func)
        {
            rttpE -= func;
        }
    }
}
