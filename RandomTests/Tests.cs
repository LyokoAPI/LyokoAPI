using System;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using NUnit.Framework;

namespace TestProject2
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestNames()
        {
            var sector = new APISector("Lyoko","forest");
            Console.WriteLine($"{sector.Name} - {sector.World.Name}");
        }
        
    }
}