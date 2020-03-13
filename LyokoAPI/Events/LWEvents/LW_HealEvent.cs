using LyokoAPI.VirtualEntities.LyokoWarrior;
using System;
namespace LyokoAPI.Events.LWEvents
{
    public class LW_HealEvent
    {
        public static event Events.OnLyokoWEvent LwE;
        
        public static void Call(LyokoWarrior warrior, int amount)
        {
            if(amount < 0)
            {
                LW_HurtEvent.Call(warrior,Math.Abs(amount));
                return;
            }
            warrior.Heal(amount);
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