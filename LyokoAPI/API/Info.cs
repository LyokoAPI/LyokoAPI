
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LyokoAPI.API
{
    public static class Info
    {
        public static string Version()
        {
            return typeof(Version).Assembly.GetName().Version.ToString();
        }

        public static bool IsCompatible(string version)
        {
            var myVersion = ParseVersion(Info.Version());
            var externalVersion = ParseVersion(version);

            if (myVersion["MajorVersion"] == externalVersion["MajorVersion"])
            {
                //add exceptions here
                return true;
            }

            return false;
        }


        private static IDictionary<string, int> ParseVersion(string version)
        {
            Dictionary<string,int> dictionary = new Dictionary<string, int>();
            Stack<String> versions = new Stack<string>(version.Split('.'));
            dictionary.Add("MajorVersion",0);
            dictionary.Add("MinorVersion",0);
            dictionary.Add("BugFix",0);
            dictionary.Add("BuildVersion",0);

            foreach (var keyValuePair in dictionary)
            {
                if (versions.Any())
                {
                    if (Int32.TryParse(versions.Pop(),out var versionNumber))
                    {
                        dictionary[keyValuePair.Key] = versionNumber;
                    }
                    
                }
            }

            return dictionary;

        }
    }
}