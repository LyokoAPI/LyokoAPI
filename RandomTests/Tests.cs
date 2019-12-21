using System;
using LyokoAPI.API;
using LyokoAPI.Events;
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
            LyokoLogger.Subscribe(Console.WriteLine);
            Info.SetConfigPath("C:\\Users\\delog\\Documents\\New folder");
            var plugin = new DummyPlugin();
            
            plugin.Enable();
            plugin.Disable();



        }
        
    }
}