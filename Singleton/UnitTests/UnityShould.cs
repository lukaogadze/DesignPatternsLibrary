using System.IO;
using FileLoggerSample;
using FileLoggerSample.Impl;
using FileLoggerSample.Impl.FileLoggers;
using FileLoggerSample.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnityShould
    {
        private UnityContainer _container;
        [TestInitialize]
        public void Setup()
        {
            _container = new UnityContainer();
            IoC.Initialize(_container);
            _container.RegisterType<IDelayConfig, DefaultDelayConfig>();
        }

        [TestMethod]
        [ExpectedException(typeof(ResolutionFailedException))]
        public void ReturnNewInstanceByDefault()
        {
            _container.RegisterType<IFileLogger, FileLogger>();

            var firstInstance = _container.Resolve<IFileLogger>();
            var secondInstance = _container.Resolve<IFileLogger>();

            Assert.AreNotSame(firstInstance, secondInstance);
        }

        [TestMethod]
        public void ReturnSameInstanceWhenConfiguredToDoSo()
        {
            _container.RegisterType<IFileLogger, FileLogger>(new ContainerControlledLifetimeManager());

            var firstInstance = _container.Resolve<IFileLogger>();
            var secondInstance = _container.Resolve<IFileLogger>();

            Assert.AreSame(firstInstance, secondInstance);
        }
    }
}