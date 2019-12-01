using LyokoAPI.Events;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.API
{
    public abstract class LAPIListener
    {
        private bool Listening = false;

        public void StartListening()
        {
            if (Listening)
            {
                return;
            }

            LW_DeathEvent.Subscribe(onLW_Death);
            LW_MoveEvent.Subscribe(onLW_Move);
            LW_FrontierEvent.Subscribe(onLW_Frontier);
            LW_HurtEvent.Subscribe(onLW_Hurt);
            LW_TranslationEvent.Subscribe(onLW_Trans);
            LW_VirtEvent.Subscribe(onLW_Virt);
            LW_DeathEvent.Subscribe(onLW_Devirt);
            LW_HealEvent.Subscribe(onLW_Heal);
            LW_XanaficationEvent.Subscribe(onLW_Xanafication);
            TowerActivationEvent.Subscribe(onTowerActivation);
            TowerDeactivationEvent.Subscribe(onTowerDeactivation);
            TowerHijackEvent.Subscribe(onTowerHijack);
            XanaAwakenEvent.Subscribe(onXanaAwaken);
            XanaDefeatEvent.Subscribe(onXanaDefeat);
            CommandInputEvent.Subscribe(onCommandInput);
            CommandOutputEvent.Subscribe(onCommandOutput);
            Listening = true;

        }

        public void StopListening()
        {
            if (!Listening)
            {
                return;
            }

            LW_DeathEvent.Unsubscribe(onLW_Death);
            LW_MoveEvent.Unsubscribe(onLW_Move);
            LW_FrontierEvent.Unsubscribe(onLW_Frontier);
            LW_HurtEvent.Unsubscribe(onLW_Hurt);
            LW_TranslationEvent.Unsubscribe(onLW_Trans);
            LW_VirtEvent.Unsubscribe(onLW_Virt);
            LW_DeathEvent.Unsubscribe(onLW_Devirt);
            LW_HealEvent.Unsubscribe(onLW_Heal);
            LW_XanaficationEvent.Unsubscribe(onLW_Xanafication);
            TowerActivationEvent.Unsubscribe(onTowerActivation);
            TowerDeactivationEvent.Unsubscribe(onTowerDeactivation);
            TowerHijackEvent.Unsubscribe(onTowerHijack);
            XanaAwakenEvent.Unsubscribe(onXanaAwaken);
            XanaDefeatEvent.Unsubscribe(onXanaDefeat);
            CommandInputEvent.Unsubscribe(onCommandInput);
            CommandOutputEvent.Unsubscribe(onCommandOutput);
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

        public virtual void onLW_Move(LyokoWarrior warrior)
        {
            
        }

        public virtual void onLW_Trans(LyokoWarrior warrior)
        {
            
        }

        public virtual void onLW_Virt(LyokoWarrior warrior)
        {
            
        }

        public virtual void onLW_Xanafication(LyokoWarrior warrior)
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
    }
}