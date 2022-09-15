using System;
using System.IO;
using LyokoAPI.API;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.Plugin;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;
using NUnit.Framework;

namespace TestProject2
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestNames()
        {
            Info.SetConfigPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"LAPIDev","Plugins"));
            var plugin = new TestPlugin();
            plugin.Enable();
            plugin.Disable();

        }
        
    }
}