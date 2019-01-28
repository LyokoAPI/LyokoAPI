
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LyokoAPI.API
{
    public static class Info
    {
        public static LVersion Version()
        {
            return typeof(LVersion).Assembly.GetName().Version.ToString();
        }
  
    }
}