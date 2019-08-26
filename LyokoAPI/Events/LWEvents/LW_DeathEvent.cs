using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events.LWEvents
{
    public class LW_DeathEvent
    {
        public static event Events.OnLyokoWEvent LwE;
        
        public static void Call(LyokoWarrior warrior)
        {
            warrior.Kill();
            LwE?.Invoke(warrior);
        }
      
        public static Events.OnLyokoWEvent Subscribe(Events.OnLyokoWEvent func)
        {
            
            LwE += func;
            return func;
        }

        public static void Unsubscribe(Events.OnLyokoWEvent func)
        {
            LwE -= func;
        }
    }
}