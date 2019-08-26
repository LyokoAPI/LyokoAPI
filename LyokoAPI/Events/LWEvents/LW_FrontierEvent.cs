using LyokoAPI.RealWorld.Location;
using LyokoAPI.RealWorld.Location.Abstract;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace LyokoAPI.Events.LWEvents
{
    public class LW_FrontierEvent
    {
        
        public static event Events.OnLyokoWEvent LwE;
        
        public static void Call(LyokoWarrior warrior)
        {
            warrior.Frontier();
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