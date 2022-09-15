using LyokoAPI.VirtualEntities.LyokoWarrior;
using System;
namespace LyokoAPI.Events.LWEvents
{
    public class LW_HurtEvent
    {
        public static event Events.OnLyokoWEvent LwE;
        
        public static void Call(LyokoWarrior warrior, int damage)
        {
            if(damage < 0)
            {
                LW_HurtEvent.Call(warrior,Math.Abs(damage));
                return;
            }
            warrior.Hurt(damage);
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