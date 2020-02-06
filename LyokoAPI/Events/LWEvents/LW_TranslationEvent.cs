using LyokoAPI.RealWorld.Location;
using LyokoAPI.RealWorld.Location.Abstract;
using LyokoAPI.VirtualEntities.LyokoWarrior;

namespace LyokoAPI.Events.LWEvents
{
    public class LW_TranslationEvent
    {
        public static event Events.OnLyokoWEvent LwE;
        
        public static void Call(LyokoWarrior warrior, ILocation<APILocation> location)
        {
            warrior.ChangeLocation(location);
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