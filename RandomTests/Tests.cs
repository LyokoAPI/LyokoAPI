using System;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using NUnit.Framework;

namespace TestProject2
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var warrior = LyokoWarriors.GetByName("ODD");
            Console.WriteLine(warrior.WarriorName);
            try
            {
                LW_VirtEvent.Call(warrior,"forest");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(warrior.Location.GetLocationName());
            
            
        }
        
    }
}