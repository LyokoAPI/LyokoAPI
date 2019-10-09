using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events.LWEvents
{
    public class LW_MoveEvent
    {
        public static event Events.OnLyokoWEvent LwE;
        //todo: add real Locations
        public static void Call(LyokoWarrior warrior, ISector sector)
        {
            warrior.Move(sector);
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