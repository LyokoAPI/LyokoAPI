using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LyokoAPI.Events;
using LyokoAPI.Events.LWEvents;

namespace LyokoAPI.VirtualEntities.LyokoWarrior
{
    public static class LyokoWarriors
    {
        private static List<LyokoWarrior> _warriors = new List<LyokoWarrior>()
        {
            new LyokoWarrior(LyokoWarriorName.AELITA),
            new LyokoWarrior(LyokoWarriorName.ULRICH),
            new LyokoWarrior(LyokoWarriorName.YUMI),
            new LyokoWarrior(LyokoWarriorName.ODD),
            new LyokoWarrior(LyokoWarriorName.WILLIAM)
        };

        public static LyokoWarrior AELITA = GetByName(LyokoWarriorName.AELITA);
        public static LyokoWarrior ULRICH = GetByName(LyokoWarriorName.ULRICH);
        public static LyokoWarrior YUMI = GetByName(LyokoWarriorName.YUMI);
        public static LyokoWarrior ODD = GetByName(LyokoWarriorName.ODD);
        public static LyokoWarrior WILLIAM = GetByName(LyokoWarriorName.WILLIAM);

        public static LyokoWarrior GetByName(string name)
        {
            try
            {
                LyokoWarriorName warriorName = (LyokoWarriorName) Enum.Parse(typeof(LyokoWarriorName), name, true);
                return GetByName(warriorName);
            }
            catch (ArgumentException e)
            {
                LyokoLogger.Log("LAPI",$"{name} is not a lyokowarrior!");
                return null;
            }
        }

        public static LyokoWarrior GetByName(LyokoWarriorName name)
        {
            return _warriors.First(warrior => warrior.WarriorName.Equals(name));
        }

        public static ReadOnlyCollection<LyokoWarrior> GetAll()
        {
            return _warriors.AsReadOnly();
        }

        internal static void ResetAll(IEnumerable<LyokoWarrior> warriors)
        {
            foreach (var lyokoWarrior in warriors)
            {
                LW_DevirtEvent.Call(lyokoWarrior);
            }
        }

        internal static void ResetAll(bool realistic = true)
        {
            if (realistic)
            {
                ResetAll(GetAll().Where(warrior => warrior.Status != LW_Status.PERMXANAFIED || warrior.Status != LW_Status.LOST || warrior.Status !=LW_Status.FRONTIERED));
            }
            else
            {
                ResetAll(GetAll());
            }
        }
        
    }
}