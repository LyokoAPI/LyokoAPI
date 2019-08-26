using LyokoAPI.RealWorld.Location.Abstract;

namespace LyokoAPI.RealWorld.Location
{
    public class APILocation : ILocation<APILocation>
    {
        public string Name { get; private set; }

        public APILocation(string name)
        {
            Name = name;
        }

        public string GetLocationName()
        {
            return Name;
        }

        public APILocation GetInnerLocation()
        {
            return this;
        }

        public GenericLocation AsGenericLocation()
        {
            return this;
        }
    }
}