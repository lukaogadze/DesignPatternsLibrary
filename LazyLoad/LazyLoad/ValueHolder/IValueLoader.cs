namespace LazyLoad.ValueHolder
{
    public interface IValueLoader<T>
    {
        T Load();
    }
}