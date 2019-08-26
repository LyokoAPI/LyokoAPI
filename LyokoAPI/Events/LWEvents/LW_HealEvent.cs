using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace LyokoAPI.Events.LWEvents
{
    public class LW_HealEvent
    {
        public static event Events.OnLyokoWEvent LwE;
        
        public static void Call(LyokoWarrior warrior, int amount)
        {
            warrior.Heal(amount);
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