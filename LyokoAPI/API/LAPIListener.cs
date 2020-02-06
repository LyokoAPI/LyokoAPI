using System;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using LyokoAPI.Events;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.Events.OVEvents;
using LyokoAPI.Plugin;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.API
{
    public abstract class LAPIListener
    {
        private bool Listening = false;
        private string _pluginName = "unknown plugin";

        public LAPIListener(string pluginName)
        {
            this._pluginName = pluginName;
        }

        public LAPIListener(LyokoAPIPlugin plugin) : this(plugin.Name)
        {
            //
        }

        public virtual void StartListening()
        {
            if (Listening)
            {
                return;
            }

            //Lyoko Warrior Events
            LW_DeathEvent.Subscribe(LW_Death);
            LW_ArriveEvent.Subscribe(LW_Arrive);
            LW_FrontierEvent.Subscribe(LW_Frontier);
            LW_HurtEvent.Subscribe(LW_Hurt);
            LW_TranslationEvent.Subscribe(LW_Trans);
            LW_VirtEvent.Subscribe(LW_Virt);
            LW_DevirtEvent.Subscribe(LW_Devirt);
            LW_HealEvent.Subscribe(LW_Heal);
            LW_XanaficationEvent.Subscribe(LW_Xanafication);
            LW_DexanaficationEvent.Subscribe(LW_Dexanafication);

            //Tower Events
            TowerActivationEvent.Subscribe(TowerActivation);
            TowerDeactivationEvent.Subscribe(TowerDeactivation);
            TowerHijackEvent.Subscribe(TowerHijack);

            //Xana Events
            XanaAwakenEvent.Subscribe(XanaAwaken);
            XanaDefeatEvent.Subscribe(XanaDefeat);

            //Command Events
            CommandInputEvent.Subscribe(CommandInput);
            CommandOutputEvent.Subscribe(CommandOutput);

            //Logger Events
            LyokoLogger.Subscribe(LyokoLog);

            //Virtual World Events
            VirtualWorldDestructionEvent.Subscribe(WorldDestruction);

            //Sector Events
            SectorDestructionEvent.Subscribe(SectorDestruction);
            SectorCreationEvent.Subscribe(SectorCreation);

            //Overvehicle events
            OV_VirtEvent.Subscribe(OV_Virt);
            OV_DevirtEvent.Subscribe(OV_Devirt);
            OV_RideEvent.Subscribe(OV_Ride); 
            OV_GetOffEvent.Subscribe(OV_GetOff);
            OV_HurtEvent.Subscribe(OV_Hurt);


            //Real World Events (possible rename?)
            RTTPEvent.Subscribe(RTTP);


            Listening = true;

        }

        public virtual void StopListening()
        {
            if (!Listening)
            {
                return;
            }

            //Lyoko Warrior Events
            LW_DeathEvent.Unsubscribe(LW_Death);
            LW_ArriveEvent.Unsubscribe(LW_Arrive);
            LW_FrontierEvent.Unsubscribe(LW_Frontier);
            LW_HurtEvent.Unsubscribe(LW_Hurt);
            LW_TranslationEvent.Unsubscribe(LW_Trans);
            LW_VirtEvent.Unsubscribe(LW_Virt);
            LW_DevirtEvent.Unsubscribe(LW_Devirt);
            LW_HealEvent.Unsubscribe(LW_Heal);
            LW_XanaficationEvent.Unsubscribe(LW_Xanafication);
            LW_DexanaficationEvent.Unsubscribe(LW_Dexanafication);

            //Tower Events
            TowerActivationEvent.Unsubscribe(TowerActivation);
            TowerDeactivationEvent.Unsubscribe(TowerDeactivation);
            TowerHijackEvent.Unsubscribe(TowerHijack);

            //Xana Events
            XanaAwakenEvent.Unsubscribe(XanaAwaken);
            XanaDefeatEvent.Unsubscribe(XanaDefeat);

            //Command Events
            CommandInputEvent.Unsubscribe(CommandInput);
            CommandOutputEvent.Unsubscribe(CommandOutput);

            //Logger Events
            LyokoLogger.Unsubscribe(LyokoLog);


            //Virtual World Events
            VirtualWorldDestructionEvent.Subscribe(WorldDestruction);

            //Sector Events
            SectorDestructionEvent.Subscribe(SectorDestruction);
            SectorCreationEvent.Subscribe(SectorCreation);

            //Overvehicle events
            OV_VirtEvent.Unsubscribe(OV_Virt);
            OV_DevirtEvent.Unsubscribe(OV_Devirt);
            OV_RideEvent.Unsubscribe(OV_Ride); 
            OV_GetOffEvent.Unsubscribe(OV_GetOff);
            OV_HurtEvent.Unsubscribe(OV_Hurt);

            //Real World Events (possible rename?)
            RTTPEvent.Unsubscribe(RTTP);


            Listening = false;

        }




        public virtual void onLW_Death(LyokoWarrior warrior)
        {
        }

        private void LW_Death(LyokoWarrior warrior)
        {
            try
            {
                onLW_Death(warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onLW_Devirt(LyokoWarrior warrior)
        {
            
        }
        private void LW_Devirt(LyokoWarrior warrior)
        {
            try
            {
                onLW_Devirt(warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }
        
        

        public virtual void onLW_Frontier(LyokoWarrior warrior)
        {
            
        }
        private void LW_Frontier(LyokoWarrior warrior)
        {
            try
            {
                onLW_Frontier(warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onLW_Heal(LyokoWarrior warrior)
        {
            
        }
        private void LW_Heal(LyokoWarrior warrior)
        {
            try
            {
                onLW_Heal(warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onLW_Hurt(LyokoWarrior warrior)
        {
            
        }
        private void LW_Hurt(LyokoWarrior warrior)
        {
            try
            {
                onLW_Hurt(warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onLW_Arrive(LyokoWarrior warrior)
        {
            
        }
        private void LW_Arrive(LyokoWarrior warrior)
        {
            try
            {
                onLW_Arrive(warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onLW_Trans(LyokoWarrior warrior)
        {
            
        }
        private void LW_Trans(LyokoWarrior warrior)
        {
            try
            {
                onLW_Trans(warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onLW_Virt(LyokoWarrior warrior)
        {

        }
        private void LW_Virt(LyokoWarrior warrior)
        {
            try
            {
                onLW_Virt(warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onLW_Xanafication(LyokoWarrior warrior)
        {
        }
        private void LW_Xanafication(LyokoWarrior warrior)
        {
            try
            {
                onLW_Xanafication(warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onLW_Dexanafication(LyokoWarrior warrior)
        {
        }
        
        private void LW_Dexanafication(LyokoWarrior warrior)
        {
            try
            {
                onLW_Dexanafication(warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }
        public virtual void onTowerActivation(ITower tower)
        {
            
        }
        private void TowerActivation(ITower tower)
        {
            try
            {
                onTowerActivation(tower);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onTowerDeactivation(ITower tower)
        {
            
        }
        private void TowerDeactivation(ITower tower)
        {
            try
            {
                onTowerDeactivation(tower);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onTowerHijack(ITower tower,APIActivator old, APIActivator newac)
        {
            
        }
        private void TowerHijack(ITower tower, APIActivator old, APIActivator newac)
        {
            try
            {
                onTowerHijack(tower, old,newac);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onXanaAwaken()
        {
            
        }
        private void XanaAwaken()
        {
            try
            {
                onXanaAwaken();
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onXanaDefeat()
        {
            
        }
        private void XanaDefeat()
        {
            try
            {
                onXanaDefeat();
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onCommandInput(string input)
        {
            
        }
        private void CommandInput(string input)
        {
            try
            {
                onCommandInput(input);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onCommandOutput(string message)
        {
            
        }
        private void CommandOutput(string output)
        {
            try
            {
                onCommandOutput(output);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }
        

        public virtual void onLyokoLog(string message)
        {
            
        }
        private void LyokoLog(string message)
        {
            try
            {
                onLyokoLog(message);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onWorldDestruction(IVirtualWorld world)
        {
            
        }

        private void WorldDestruction(IVirtualWorld world)
        {
            try
            {
                onWorldDestruction(world);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onSectorDestruction(ISector sector)
        {
            
        }
        private void SectorDestruction(ISector world)
        {
            try
            {
                onSectorDestruction(world);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onSectorCreation(ISector sector)
        {

        }
        private void SectorCreation(ISector world)
        {
            try
            {
                onSectorCreation(world);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }
        public virtual void onOV_Virt(Overvehicle overvehicle)
        {

        }
        private void OV_Virt(Overvehicle vehicle)
        {
            try
            {
                onOV_Virt(vehicle);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onOV_Devirt(Overvehicle overvehicle)
        {

        }
        private void OV_Devirt(Overvehicle vehicle)
        {
            try
            {
                onOV_Devirt(vehicle);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }
        public virtual void onOV_Ride(Overvehicle overvehicle, LyokoWarrior warrior)
        {

        }
        private void OV_Ride(Overvehicle vehicle, LyokoWarrior warrior)
        {
            try
            {
                onOV_Ride(vehicle, warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onOV_GetOff(Overvehicle overvehicle, LyokoWarrior warrior)
        {

        }
        private void OV_GetOff(Overvehicle vehicle, LyokoWarrior warrior)
        {
            try
            {
                onOV_GetOff(vehicle, warrior);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onOV_Hurt(Overvehicle overvehicle)
        {

        }
        private void OV_Hurt(Overvehicle vehicle)
        {
            try
            {
                onOV_Hurt(vehicle);
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }

        public virtual void onRTTP()
        {

        }
        private void RTTP()
        {
            try
            {
                onRTTP();
            }
            catch (Exception e)
            {
                LyokoLogger.Log(_pluginName,$"couldn't process {MethodBase.GetCurrentMethod().ReflectedType?.Name}: {e.ToString()}");
            }
        }
    }
}