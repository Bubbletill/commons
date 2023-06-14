namespace BT_COMMONS.Helpers
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}