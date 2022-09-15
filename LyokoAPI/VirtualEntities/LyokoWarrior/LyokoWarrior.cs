using System.Collections.Generic;
using System.Linq;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.RealWorld.Location;
using LyokoAPI.RealWorld.Location.Abstract;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.VirtualEntities.LyokoWarrior
{
    public class LyokoWarrior
    {
        public static readonly int MAX_HP = 100;
        public LyokoWarriorName WarriorName { get; internal set; }
        public GenericLocation Location { get; private set; }
        private List<LW_Status> _statuses = new List<LW_Status>();
        public IReadOnlyList<LW_Status> Statuses {  get; private set; }
        public int HP { get; private set; }

        public bool CantDevirt => _cantDevirt();

        public bool Xanafied => Statuses.Contains(LW_Status.XANAFIED) || Statuses.Contains(LW_Status.PERMXANAFIED);

        internal LyokoWarrior(LyokoWarriorName warrior)
        {
            Statuses = _statuses.AsReadOnly();
            WarriorName = warrior;
            Location = APILocations.KADIC;
            AddUniqueStatus(LW_Status.EARTH);
            HP = MAX_HP;
        }

        internal int Hurt(int damage)
        {
            if ((HP - damage) < 0 )
            {
                HP -= 0;
            }
            else
            {
                HP -= damage;
            }

            return HP;
        }
        
        internal int Heal(int ammount)
        {
            if(ammount < 0)
            {
                Hurt(ammount);
            }
            if ((HP + ammount) > MAX_HP)
            {
                HP = MAX_HP;
            }
            else
            {
                HP += ammount;
            }

            return HP;
        }

        internal int ResetHealth()
        {
            return Heal(MAX_HP);
        }

        internal LyokoWarrior Virtualize(ISector destination)
        {
            ChangeLocation(destination);
            ResetHealth();
            _statuses.Remove(LW_Status.EARTH);
            AddUniqueStatus(LW_Status.VIRTUALIZED);
            return this;
        }

        internal LyokoWarrior Frontier()
        {
            Location = APILocations.FRONTIER;
            AddUniqueStatus(LW_Status.FRONTIERED);
            if(Xanafied)
            {
                LW_DexanaficationEvent.Call(this);
            }
            return this;
        }

        internal LyokoWarrior CodeEarth(ILocation<APILocation> location)
        {
            ChangeLocation(location);
            ResetStatus();
            ResetHealth();
            return this;
        }

        internal LyokoWarrior CodeEarth()
        {
            return CodeEarth(APILocations.SCANNERS);
        }

        internal LyokoWarrior Kill()
        {
            Location = APILocations.DEAD;
            ResetStatus(LW_Status.LOST);
            HP = 0;
            return this;
        }

        internal LyokoWarrior Xanafy()
        {
            AddUniqueStatus(LW_Status.XANAFIED);
            return this;
        }

        internal LyokoWarrior Dexanafy()
        {
            _statuses.RemoveAll(status => status == LW_Status.XANAFIED || status == LW_Status.PERMXANAFIED);
            return this;
        }

        internal LyokoWarrior PermXanafy()
        {
            _statuses.Remove(LW_Status.XANAFIED);
            AddUniqueStatus(LW_Status.PERMXANAFIED);
            return this;
        }
        

        internal LyokoWarrior Translate(ILocation<APILocation> location)
        {
            ChangeLocation(location);
            AddUniqueStatus(LW_Status.TRANSLATED);
            return this;
        }

        internal LyokoWarrior DeTranslate(ILocation<ISector> location)
        {
            ChangeLocation(location);
            _statuses.Remove(LW_Status.TRANSLATED);
            return this;
        }
        internal LyokoWarrior ChangeLocation(ILocation<APILocation> location)
        {
            Location = location.AsGenericLocation();
            return this;
        }

        internal LyokoWarrior ChangeLocation(ILocation<ISector> location)
        {
            Location = location.AsGenericLocation();
            return this;
        }

        public void RemoveEarthCode()
        {
            AddUniqueStatus(LW_Status.NOEARTHCODE);
        }

        internal void GiveEarthCode()
        {
            _statuses.Remove(LW_Status.NOEARTHCODE);
        }

        internal void CorruptDNA()
        {
            AddUniqueStatus(LW_Status.DNACORRUPTED);
        }

        internal void FixDNA()
        {
            _statuses.Remove(LW_Status.DNACORRUPTED);
        }


        private bool AddUniqueStatus(LW_Status status)
        {
            if (_statuses.Contains(status))
            {
                return false;
            }

            _statuses.Add(status);
            return true;
        }

        private void ResetStatus(LW_Status status = LW_Status.EARTH)
        {
            _statuses.Clear();
            AddUniqueStatus(status);
        }

        private bool _cantDevirt()
        {
            return _statuses.Contains(LW_Status.XANAFIED) || _statuses.Contains(LW_Status.PERMXANAFIED) ||
                _statuses.Contains(LW_Status.LOST) || _statuses.Contains(LW_Status.NOEARTHCODE) || _statuses.Contains(LW_Status.DNACORRUPTED) || _statuses.Contains(LW_Status.FRONTIERED) ;
        }
    }
}