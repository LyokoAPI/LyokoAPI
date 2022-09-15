using System.Runtime.Remoting.Channels;
using LyokoAPI.Events;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.Events.OVEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.API
{
    public abstract class LAPIListener
    {
        private bool Listening = false;

        public virtual void StartListening()
        {
            if (Listening)
            {
                return;
            }

            //Lyoko Warrior Events
            LW_DeathEvent.Subscribe(onLW_Death);
            LW_ArriveEvent.Subscribe(onLW_Arrive);
            LW_FrontierEvent.Subscribe(onLW_Frontier);
            LW_HurtEvent.Subscribe(onLW_Hurt);
            LW_TranslationEvent.Subscribe(onLW_Trans);
            LW_VirtEvent.Subscribe(onLW_Virt);
            LW_DevirtEvent.Subscribe(onLW_Devirt);
            LW_HealEvent.Subscribe(onLW_Heal);
            LW_XanaficationEvent.Subscribe(onLW_Xanafication);
            LW_DexanaficationEvent.Subscribe(onLW_Dexanafication);
            LW_PermXanafyEvent.Subscribe(onLW_PermXanafy);
            LW_DeTranslationEvent.Subscribe(onLW_Detrans);
            LW_CodeEarthResolvedEvent.Subscribe(onLW_CodeEarthResolved);
            LW_DNACorruptionEvent.Subscribe(onLW_DNACorruption);
            LW_FixedDNAEvent.Subscribe(onLW_FixedDNA);

            //Tower Events
            TowerActivationEvent.Subscribe(onTowerActivation);
            TowerDeactivationEvent.Subscribe(onTowerDeactivation);
            TowerHijackEvent.Subscribe(onTowerHijack);

            //Xana Events
            XanaAwakenEvent.Subscribe(onXanaAwaken);
            XanaDefeatEvent.Subscribe(onXanaDefeat);

            //Command Events
            CommandInputEvent.Subscribe(onCommandInput);
            CommandOutputEvent.Subscribe(onCommandOutput);

            //Logger Events
            LyokoLogger.Subscribe(onLyokoLog);

            //Virtual World Events
            VirtualWorldDestructionEvent.Subscribe(onWorldDestruction);

            //Sector Events
            SectorDestructionEvent.Subscribe(onSectorDestruction);
            SectorCreationEvent.Subscribe(onSectorCreation);

            //Overvehicle events
            OV_VirtEvent.Subscribe(onOV_Virt);
            OV_DevirtEvent.Subscribe(onOV_Devirt);
            OV_RideEvent.Subscribe(onOV_Ride); 
            OV_GetOffEvent.Subscribe(onOV_GetOff);
            OV_HurtEvent.Subscribe(onOV_Hurt);


            //Real World Events (possible rename?)
            RTTPEvent.Subscribe(onRTTP);


            Listening = true;

        }

        public virtual void StopListening()
        {
            if (!Listening)
            {
                return;
            }

            //Lyoko Warrior Events
            LW_DeathEvent.Unsubscribe(onLW_Death);
            LW_ArriveEvent.Unsubscribe(onLW_Arrive);
            LW_FrontierEvent.Unsubscribe(onLW_Frontier);
            LW_HurtEvent.Unsubscribe(onLW_Hurt);
            LW_TranslationEvent.Unsubscribe(onLW_Trans);
            LW_VirtEvent.Unsubscribe(onLW_Virt);
            LW_DevirtEvent.Unsubscribe(onLW_Devirt);
            LW_HealEvent.Unsubscribe(onLW_Heal);
            LW_XanaficationEvent.Unsubscribe(onLW_Xanafication);
            LW_DexanaficationEvent.Unsubscribe(onLW_Dexanafication);
            LW_PermXanafyEvent.Unsubscribe(onLW_PermXanafy);
            LW_DeTranslationEvent.Unsubscribe(onLW_Detrans);
            LW_CodeEarthResolvedEvent.Unsubscribe(onLW_CodeEarthResolved);
            LW_DNACorruptionEvent.Unsubscribe(onLW_DNACorruption);
            LW_FixedDNAEvent.Unsubscribe(onLW_FixedDNA);

            //Tower Events
            TowerActivationEvent.Unsubscribe(onTowerActivation);
            TowerDeactivationEvent.Unsubscribe(onTowerDeactivation);
            TowerHijackEvent.Unsubscribe(onTowerHijack);

            //Xana Events
            XanaAwakenEvent.Unsubscribe(onXanaAwaken);
            XanaDefeatEvent.Unsubscribe(onXanaDefeat);

            //Command Events
            CommandInputEvent.Unsubscribe(onCommandInput);
            CommandOutputEvent.Unsubscribe(onCommandOutput);

            //Logger Events
            LyokoLogger.Unsubscribe(onLyokoLog);


            //Virtual World Events
            VirtualWorldDestructionEvent.Subscribe(onWorldDestruction);

            //Sector Events
            SectorDestructionEvent.Subscribe(onSectorDestruction);
            SectorCreationEvent.Subscribe(onSectorCreation);

            //Overvehicle events
            OV_VirtEvent.Unsubscribe(onOV_Virt);
            OV_DevirtEvent.Unsubscribe(onOV_Devirt);
            OV_RideEvent.Unsubscribe(onOV_Ride); 
            OV_GetOffEvent.Unsubscribe(onOV_GetOff);
            OV_HurtEvent.Unsubscribe(onOV_Hurt);

            //Real World Events (possible rename?)
            RTTPEvent.Unsubscribe(onRTTP);


            Listening = false;

        }




        public virtual void onLW_Death(LyokoWarrior warrior)
        {
        }

        public virtual void onLW_Devirt(LyokoWarrior warrior)
        {
            
        }

        public virtual void onLW_Frontier(LyokoWarrior warrior)
        {
            
        }

        public virtual void onLW_Heal(LyokoWarrior warrior)
        {
            
        }

        public virtual void onLW_Hurt(LyokoWarrior warrior)
        {
            
        }

        public virtual void onLW_Arrive(LyokoWarrior warrior)
        {
            
        }

        public virtual void onLW_Trans(LyokoWarrior warrior)
        {
            
        }

        public virtual void onLW_Detrans(LyokoWarrior warrior)
        {

        }

        public virtual void onLW_Virt(LyokoWarrior warrior)
        {

        }

        public virtual void onLW_Xanafication(LyokoWarrior warrior)
        {
        }

        public virtual void onLW_Dexanafication(LyokoWarrior warrior)
        {
        }

        public virtual void onLW_CodeEarthResolved(LyokoWarrior warrior)
        {

        }

        public virtual void onLW_DNACorruption(LyokoWarrior warrior)
        {

        }

        public virtual void onLW_FixedDNA(LyokoWarrior warrior)
        {

        }

        public virtual void onTowerActivation(ITower tower)
        {
            
        }

        public virtual void onTowerDeactivation(ITower tower)
        {
            
        }

        public virtual void onTowerHijack(ITower tower,APIActivator old, APIActivator newac)
        {
            
        }

        public virtual void onXanaAwaken()
        {
            
        }

        public virtual void onXanaDefeat()
        {
            
        }

        public virtual void onCommandInput(string input)
        {
            
        }

        public virtual void onCommandOutput(string message)
        {
            
        }

        public virtual void onLyokoLog(string message)
        {
            
        }

        public virtual void onWorldDestruction(IVirtualWorld world)
        {
            
        }

        public virtual void onSectorDestruction(ISector sector)
        {
            
        }

        public virtual void onSectorCreation(ISector sector)
        {

        }

        public virtual void onOV_Virt(Overvehicle overvehicle)
        {

        }

        public virtual void onOV_Devirt(Overvehicle overvehicle)
        {

        }

        public virtual void onOV_Ride(Overvehicle overvehicle, LyokoWarrior warrior)
        {

        }

        public virtual void onOV_GetOff(Overvehicle overvehicle, LyokoWarrior warrior)
        {

        }

        public virtual void onOV_Hurt(Overvehicle overvehicle)
        {

        }

        public virtual void onRTTP()
        {

        }

        public virtual void onLW_PermXanafy(LyokoWarrior warrior)
        {
            
        }
    }
}