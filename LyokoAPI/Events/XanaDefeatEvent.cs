namespace LyokoAPI.Events
{
    public class XanaDefeatEvent
    {
        private static event Events.OnLyokoEvent XanaDefeatE;

        public static void Call()
        {
            XanaDefeatE?.Invoke();
        }

        public static Events.OnLyokoEvent Subscribe(Events.OnLyokoEvent func)
        {
            XanaDefeatE += func;
            return func;
        }

        public static void Unsubscribe(Events.OnLyokoEvent func)
        {
            XanaDefeatE -= func;
        }
    }
}