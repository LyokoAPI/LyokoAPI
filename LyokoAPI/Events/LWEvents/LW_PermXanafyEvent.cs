using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace LyokoAPI.Events.LWEvents
{
    public class LW_PermXanafyEvent
    {
        public static event Events.OnLyokoWEvent LwE;
        
        public static void Call(LyokoWarrior warrior)
        {
            warrior.PermXanafy();
            LwE?.Invoke(warrior);
        }
      
        internal static Events.OnLyokoWEvent Subscribe(Events.OnLyokoWEvent func)
        {
            
            LwE += func;
            return func;
        }

        internal static void Unsubscribe(Events.OnLyokoWEvent func)
        {
            LwE -= func;
        }
    }
}