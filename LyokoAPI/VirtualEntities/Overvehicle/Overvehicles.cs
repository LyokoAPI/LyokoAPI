using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using LyokoAPI.Events;

namespace LyokoAPI.VirtualEntities.Overvehicle
{
    public static class Overvehicles
    {
        private static List<Overvehicle> _overvehicles = new List<Overvehicle>()
        {
            new Overvehicle(OvervehicleName.OVERBIKE),
            new Overvehicle(OvervehicleName.OVERBOARD),
            new Overvehicle(OvervehicleName.OVERWING),
        };

        public static Overvehicle OVERBIKE = GetByName(OvervehicleName.OVERBIKE);
        public static Overvehicle OVERBOARD = GetByName(OvervehicleName.OVERBOARD);
        public static Overvehicle OVERWING = GetByName(OvervehicleName.OVERWING);

        public static Overvehicle GetByName(string name)
        {
            try
            {
                OvervehicleName overvehicleName = (OvervehicleName)Enum.Parse(typeof(OvervehicleName), name, true);
                return GetByName(overvehicleName);
            }
            catch (ArgumentException e)
            {
                LyokoLogger.Log("LAPI", $"{name} is not an overvehicle!");
                return null;
            }
        }

        public static Overvehicle GetByName(OvervehicleName name)
        {
            return _overvehicles.First(overvehicle => overvehicle.OvervehicleName.Equals(name));
        }

        public static ReadOnlyCollection<Overvehicle> GetAll()
        {
            return _overvehicles.AsReadOnly();
        }
    }
}
