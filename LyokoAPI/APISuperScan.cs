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
        public bool XanaIsAttacking => XanaTowers.Count > 0;

        public APISuperScan()
        {
            
             TowerActivationEvent.Subscribe(OnTowerActivation);
             TowerDeactivationEvent.Subscribe(OnTowerDeactivation);
             TowerHijackEvent.Subscribe(OnTowerHijack);
        }

        private void OnTowerActivation(ITower tower)
        {
            if (HasTower(tower)) return;
            switch (tower.Activator)
            {
                case APIActivator.XANA:
                    XanaTowers.Add(tower);
                    if (!XanaIsAttacking)
                    {
                        XanaAwakenEvent.Call(tower);
                    }
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
            if (!HasTower(tower)) return;
            switch (tower.Activator)
            {
                case APIActivator.XANA:
                    if (XanaIsAttacking)
                    {
                        XanaTowers.Remove(tower);
                        if (!XanaIsAttacking)
                        {
                            XanaDefeatEvent.Call();
                        }
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

        private void OnTowerHijack(ITower tower, APIActivator old, APIActivator newact)
        {
            OnTowerDeactivation(tower);
            OnTowerActivation(tower);
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