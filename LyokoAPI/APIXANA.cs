using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI
{
    public class APIXANA
    {
        private bool _initizalized = false;
        public List<ITower> ActiveTowers { get; } = new List<ITower>();
        public bool IsAttacking => ActiveTowers.Count > 0;

        public APIXANA()
        {
            if (!_initizalized)
            {
                TowerActivationEvent.Subscribe(OnTowerActivation);
                TowerDeactivationEvent.Subscribe(onTowerDeactivation);
                TowerHijackEvent.Subscribe(onTowerHijack);
                _initizalized = true;
            }
        }

        private void OnTowerActivation(ITower tower)
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

        private void onTowerDeactivation(ITower tower)
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

        private void onTowerHijack(ITower tower, APIActivator old, APIActivator newact)
        {
            onTowerDeactivation(tower);
            OnTowerActivation(tower);
        }
        
        private bool HasTower(ITower tower)
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