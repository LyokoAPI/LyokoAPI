using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LyokoAPI.Events;

namespace LyokoAPI.API
{
    public class LVersion
    {
        public int MajorVersion { get; protected set; } = 0;
        public int MinorVersion { get; protected set; } = 0;
        public int SubVersion { get; protected set; } = 0;
        public int BuildVersion { get; protected set; } = 0;
        

        public CompatiblityLevel GetCompatibility(LVersion version)
        {
            CompatiblityLevel level = CompatiblityLevel.None;
            if (MajorVersion == version.MajorVersion)
            {
                level++;
                if (MinorVersion == version.MinorVersion)
                {
                    level++;
                    if (SubVersion == version.SubVersion)
                    {
                        level++;
                        if (BuildVersion == version.SubVersion)
                        {
                            level++;
                        }
                    }
                }
            }

            return level;
        }

        public static LVersion Parse(string version)
        {
            Regex validString = new Regex(@"^\w(\.\w)+");
            if (!validString.IsMatch(version))
            {
                throw new FormatException("Version format must be minimum: X.X");
            }
            LVersion parsedVersion = new LVersion();
            var versions = version.Split('.');

            if (versions.Length > 4)
            {
                versions = new List<string>(versions).GetRange(0,4).ToArray();
            }
            switch (versions.Length)
            {
                case 4: parsedVersion.BuildVersion = Convert.ToInt32(versions[3]);
                    goto case 3;
                case 3: parsedVersion.SubVersion = Convert.ToInt32(versions[2]);
                    goto case 2;
                case 2: parsedVersion.MinorVersion = Convert.ToInt32(versions[1]);
                    goto case 1;
                case 1: parsedVersion.MajorVersion = Convert.ToInt32(versions[0]);
                    break;
            }

            return parsedVersion;
        }

        public static bool TryParse(string version, out LVersion newVersion)
        {
            newVersion = null;
            try
            {
                newVersion = Parse(version);
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }
        public static implicit operator LVersion(string versionstring)
        {
            if (!TryParse(versionstring,out var result))
            {
                result = "0.0";
            }

            return result;
        }

        public override string ToString()
        {
            string result =  $"{MajorVersion}.{MinorVersion}.{SubVersion}{(BuildVersion == 0 ? "" : $".{BuildVersion}")}";
            if (result == "0.0.0")
            {
                return "Unversioned";
            }

            return result;
        }
        
        
    }
}