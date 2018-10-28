using System.Collections.Generic;
using System.Runtime.InteropServices;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI
{
    public static class APIXANA
    {

        public static List<ITower> ActiveTowers { get; } = new List<ITower>();
        public static bool IsAttacking => ActiveTowers.Count > 0;

        static APIXANA()
        {
            TowerActivationEvent.Subscribe(OnTowerActivation);
            TowerDeactivationEvent.Subscribe(onTowerDeactivation);
        }

        private static void OnTowerActivation(ITower tower)
        {
            if (!HasTower(tower))
            {
              ActiveTowers.Add(tower);  
            }
        }

        private static void onTowerDeactivation(ITower tower)
        {
            if (!HasTower(tower))
            {
                ActiveTowers.Remove(tower);
            }
        }
        
        private static bool HasTower(ITower tower)
        {
            bool contains = false;
            foreach (var listtower in ActiveTowers)
            {
                if (listtower.Equals(tower))
                {
                    contains = true;
                }
            }

            return contains;
        }
    }
}