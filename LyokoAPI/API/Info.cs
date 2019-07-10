
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LyokoAPI.API
{
    public static class Info
    {
        private static string ConfigPath = "";
        public static LVersion Version()
        {
            return typeof(LVersion).Assembly.GetName().Version.ToString();
        }

        internal static string GetConfigPath()
        {
            if (ConfigPath == String.Empty)
            {
                throw new NullReferenceException("ConfigPath is undefined");
            }
            return ConfigPath;
        }

        public static void SetConfigPath(string path)
        {
            if (ConfigPath != String.Empty)
            {
                throw new InvalidOperationException("A config path was already set!");
            }

            if (File.Exists(path))
            {
                throw new InvalidOperationException("config path must be a directory");
            }

            if (Directory.Exists(path))
            {
                ConfigPath = path;
            }
            else
            {
                Directory.CreateDirectory(path);
                ConfigPath = path;
            }
        }

        public static bool HasConfigPath()
        {
            try
            {
                GetConfigPath();
                return true;
            }
            catch (NullReferenceException e)
            {
                return false;
            }
        }
    }
}