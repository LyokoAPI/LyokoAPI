using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.Events.LWEvents
{
    public class LW_MoveEvent
    {
        public static event Events.OnLyokoWEvent CDLwE;
        public static event Events.OnLyokoWEvent ALwE;
        //todo: add real Locations
        //Change Directions
        public static void Call(LyokoWarrior warrior, ISector sector)
        {
            warrior.Move(sector);
            CDLwE?.Invoke(warrior);
        }
        public static void Call(LyokoWarrior warrior, APISector sector)
        {
            Call(warrior, sector);
        }
        public static void Call(LyokoWarrior warrior, string virtualworld, string sector)
        {
            Call(warrior, new APISector(virtualworld, sector));
        }
        public static void Call(LyokoWarrior warrior, string sector)
        {
            Call(warrior, new APISector("Lyoko", sector));
        }

        //Arrive
        public static void Call(LyokoWarrior warrior)
        {
            warrior.Arrive();
            ALwE?.Invoke(warrior);
        }

        public static Events.OnLyokoWEvent SubscribeChangeDestination(Events.OnLyokoWEvent func)
        {

            CDLwE += func;
            return func;
        }

        public static void UnsubscribeChangeDestination(Events.OnLyokoWEvent func)
        {
            CDLwE -= func;
        }

        public static Events.OnLyokoWEvent SubscribeArrive(Events.OnLyokoWEvent func)
        {

            ALwE += func;
            return func;
        }

        public static void UnsubscribeArrive(Events.OnLyokoWEvent func)
        {
            ALwE -= func;
        }
    }
}