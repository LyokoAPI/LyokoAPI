using LyokoAPI.RealWorld.Location;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events.LWEvents
{
    public class LW_ArriveEvent
    {
        public static event Events.OnLyokoWEvent LwE;
        public static void Call(LyokoWarrior warrior, ISector sector)
        {
            warrior.ChangeLocation(sector);
            LwE?.Invoke(warrior);
        }
        public static void Call(LyokoWarrior warrior, APISector sector)
        {
            Call(warrior,sector);
        }
        public static void Call(LyokoWarrior warrior, string virtualworld, string sector)
        {
            Call(warrior,new APISector(virtualworld, sector));
        }
        public static void Call(LyokoWarrior warrior,string sector)
        {
            Call(warrior,new APISector("Lyoko", sector));
        }

        public static void Call(LyokoWarrior warrior, APILocation location)
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