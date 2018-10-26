using System;
using System.Collections;
using System.ComponentModel;
using IFSCLAPI.VirtualStructures;

namespace IFSCLAPI.API
{
    public static class LyokoParser
    {
        public static APIActivator ParseActivator(string activatorstring)
        {
            switch (activatorstring.ToUpper())
            {
                    case "XANA": return APIActivator.XANA;
                    case "JEREMIE": return APIActivator.JEREMIE;
                    case "HOPPER" : return APIActivator.HOPPER;
                    case "NONE": return APIActivator.NONE;
            }

            throw new NullReferenceException("Invalid activator: "+ activatorstring);
            
        }

        public static bool TryParseActivator(string activatorstring, out APIActivator activator)
        {
            try
            {
                activator = ParseActivator(activatorstring);
                return true;
            }
            catch (NullReferenceException e)
            {
                activator = APIActivator.NONE;
                return false;
            }
        }
    }
}