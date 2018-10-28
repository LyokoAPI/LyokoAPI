using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI
{
    public static class APIXANA
    {
        private static bool _initizalized = false;
        public static List<ITower> ActiveTowers { get; } = new List<ITower>();
        public static bool IsAttacking => ActiveTowers.Count > 0;

        internal static void Initialize()
        {
            if (!_initizalized)
            {
                TowerActivationEvent.Subscribe(OnTowerActivation);
                TowerDeactivationEvent.Subscribe(onTowerDeactivation);
                _initizalized = true;
            }
        }

        private static void OnTowerActivation(ITower tower)
        {
            if (!HasTower(tower))
            {
                if (!IsAttacking)
                {
                    if (tower.Activator == APIActivator.XANA)
                    {
                        ActiveTowers.Add(tower);
                        XanaAwakenEvent.Call(tower);
                        
                    }
                }
               
            }
        }

        private static void onTowerDeactivation(ITower tower)
        {
            if (HasTower(tower))
            {
                if (IsAttacking)
                {
                    ActiveTowers.Remove(tower);
                    if (!IsAttacking)
                    {
                        XanaDefeatEvent.Call();
                    }
                }
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