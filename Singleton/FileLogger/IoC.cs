using Microsoft.Practices.Unity;

namespace FileLoggerSample
{
    public static class IoC
    {
        private static IUnityContainer _container;

        public static void Initialize(IUnityContainer container)
        {
            _container = container;
        }

        public static TBase Resolve<TBase>()
        {
            return _container.Resolve<TBase>();
        }
    }
}