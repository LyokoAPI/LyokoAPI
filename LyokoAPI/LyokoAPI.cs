namespace LyokoAPI
{
    public static class LyokoAPI
    {
        private static bool _initialized = false;
        /*
         * Returns wether or not LyokoAPI had to be initialized 
         */
        public static bool EnsureInitialized()
        {
            if (!_initialized)
            {
                Initialize();
                _initialized = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        private static void Initialize()
        {
            APIXANA.Initialize();
        }
    }
}