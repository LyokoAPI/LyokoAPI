namespace LyokoAPI.RealWorld.Location.Abstract
{
    public interface ILocation<T>
    {
        string GetLocationName();
        T GetInnerLocation();
        GenericLocation AsGenericLocation();
    }
}