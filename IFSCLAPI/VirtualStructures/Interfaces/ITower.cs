namespace IFSCLAPI
{
    public interface ITower
    {
        int Number { get; }
        bool Activated { get; }
        ISector Sector { get; }
    }
}