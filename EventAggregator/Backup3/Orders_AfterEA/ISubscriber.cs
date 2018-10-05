namespace Orders_AfterEA
{
    public interface ISubscriber<T>
    {
        void OnEvent(T e);
    }
}