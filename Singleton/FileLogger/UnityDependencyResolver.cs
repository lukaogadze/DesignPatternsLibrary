using FileLoggerSample.Impl;
using FileLoggerSample.Impl.Factories;
using FileLoggerSample.Interfaces;
using Microsoft.Practices.Unity;

namespace FileLoggerSample
{
    public class UnityDependencyResolver
    {
        private static readonly IUnityContainer _container;
        static UnityDependencyResolver()
        {
            _container = new UnityContainer();
            IoC.Initialize(_container);
        }

        public void EnsureDependenciesRegistered()
        {
            _container.RegisterType<IFileLoggerFactory, LazySingletonFileLoggerFactory>();
            _container.RegisterType<IDelayConfig, DefaultDelayConfig>();
        }

        public IUnityContainer Container
        {
            get
            {
                return _container;
            }
        }
    }
}