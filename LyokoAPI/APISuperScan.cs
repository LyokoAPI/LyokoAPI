using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LyokoAPI.Events;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI
{
    public class APISuperScan
    {
        public List<ITower> XanaTowers { get; } = new List<ITower>();
        public List<ITower> HopperTowers { get; } = new List<ITower>();
        public List<ITower> JeremieTowers { get; } = new List<ITower>();
        public bool XanaIsAttacking;
        private static APISuperScan _superScan;

        public static APISuperScan GetOrCreate()
        {
            if (_superScan == null)
            {
                _superScan = new APISuperScan();
            }

            return _superScan;
        }
        
        private APISuperScan()
        {
            
             TowerActivationEvent.Subscribe(OnTowerActivation);
             TowerDeactivationEvent.Subscribe(OnTowerDeactivation);
             TowerHijackEvent.Subscribe(OnTowerHijack);
        }
        
        

        private void onXanaAwaken()
        {
            XanaIsAttacking = true;
        }

        private void onXanaDefeat()
        {
            XanaIsAttacking = false;
        }

        private void OnTowerActivation(ITower tower)
        {
            OnTowerActivation(tower, tower.Activator);
        }
        
        private void OnTowerActivation(ITower tower, APIActivator activator)
        {
            if (HasTower(tower)) return;
            switch (activator)
            {
                case APIActivator.XANA:
                    if (XanaTowers.Count == 0) {
                        onXanaAwaken();
                    }
                    XanaTowers.Add(tower);
                    break;
                case APIActivator.HOPPER:
                    HopperTowers.Add(tower);
                    break;
                case APIActivator.JEREMIE:
                    JeremieTowers.Add(tower);
                    break;
            }
        }
        
        private void OnTowerDeactivation(ITower tower)
        {
            OnTowerDeactivation(tower, tower.Activator);
        }

        private void OnTowerDeactivation(ITower tower, APIActivator activator)
        {
            if (!HasTower(tower)) return;
            switch (activator)
            {
                case APIActivator.XANA:
                    XanaTowers.Remove(tower);
                    if (XanaTowers.Count == 0) {
                        onXanaDefeat();
                    }
                    break;
                case APIActivator.HOPPER:
                    HopperTowers.Remove(tower);
                    break;
                case APIActivator.JEREMIE:
                    JeremieTowers.Remove(tower);
                    break;
            }
            
        }

        private void OnTowerHijack(ITower tower, APIActivator oldActivator, APIActivator newActivator)
        {
            OnTowerDeactivation(tower, oldActivator);
            OnTowerActivation(tower, newActivator);
        }
        
        private bool HasTower(ITower tower)
        {
            bool contains = false;
            foreach (var listtower in GetAllRegisteredTowers())
            {
                if (listtower.Equals(tower))
                {
                    contains = true;
                }
            }

            return contains;
        }

        public IEnumerable<ITower> GetAllRegisteredTowers()
        {
            List<ITower> towers = new List<ITower>();
            towers.AddRange(XanaTowers);
            towers.AddRange(HopperTowers);
            towers.AddRange(JeremieTowers);
            return towers;
        }
        
    }
}