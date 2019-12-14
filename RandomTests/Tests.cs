using System;
using LyokoAPI.Events.LWEvents;
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
            var sector = new APISector("Lyoko","forest");
            Console.WriteLine($"{sector.Name} - {sector.World.Name}");
            APITower tower = new APITower("lyoko", "forest", 1);

            tower.Activator = APIActivator.XANA;
            ITower itower = tower;
            
            Assert.AreEqual(APIActivator.XANA.ToString(), $"{itower.Activator}");


        }
        
    }
}