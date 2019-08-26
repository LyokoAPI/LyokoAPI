using System;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace LyokoAPI.RealWorld.Location.Abstract
{
    public class GenericLocation
    {
        private dynamic location;
        private Type _type;
        internal static GenericLocation MakeGenericLocation<T>(T innerLocation)
        {
           return new GenericLocation() {location = innerLocation, _type = innerLocation.GetType()};
        }

        public bool IsSector()
        {
            return _type == typeof(ISector);
        }

        public bool IsTower()
        {
            return _type == typeof(ITower);
        }

        public bool IsAPILocation()
        {
            return _type == typeof(APILocation);
        }
        public bool TryGetInnerSector(out ISector sector)
        {
            if (IsSector())
            {
                sector = ((ILocation<ISector>) location).GetInnerLocation();
                return true;
            }
            else
            {
                sector = null;
                return false;
            }
        }

        public dynamic GetDynamicInnerLocation()
        {
            return location.GetInnerLocation();
        }

        public bool TryGetInnerTower(out ITower tower)
        {
            if (IsTower())
            {
                tower = ((ILocation<ITower>) location).GetInnerLocation();
                return true;
            }
            else
            {
                tower = null;
                return false;
            }
            
        }
        public LocationType GetLocationType()
        {
            if (IsSector())
            {
                return LocationType.SECTOR;
            }else if (IsTower())
            {
                return LocationType.TOWER;
            }

            return LocationType.API;
        }

        public string GetLocationName()
        {
            return location.GetLocationName();
        }

        public static implicit operator GenericLocation(APILocation apiLocation)
        {
            return MakeGenericLocation(apiLocation);
        }

        public static implicit operator GenericLocation(APISector sectorLocation)
        {
            return MakeGenericLocation(sectorLocation);
        }

        public static implicit operator GenericLocation(APITower sectorTower)
        {
            return MakeGenericLocation(sectorTower);
        }


    }
}