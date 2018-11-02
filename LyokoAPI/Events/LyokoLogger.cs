namespace LyokoAPI.Events
{
    public static class LyokoLogger
    {
        private static event Events.OnLogEvent LogE;

        public static void Log(string sender, string message)
        {
            LogE?.Invoke($"[{sender}] {message}");
        }

        public static Events.OnLogEvent Subscribe(Events.OnLogEvent func)
        {
            LogE += func;
            return func;
        }

        public static void Unsubscribe(Events.OnLogEvent func)
        {
            LogE -= func;
        }
    }
}