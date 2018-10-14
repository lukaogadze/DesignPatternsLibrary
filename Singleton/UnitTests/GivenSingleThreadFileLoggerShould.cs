using System.IO;
using FileLoggerSample;
using FileLoggerSample.Impl;
using FileLoggerSample.Impl.Factories;
using FileLoggerSample.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GivenSingleThreadFileLoggerShould
    {
        private IUnityContainer _container;
        private INumbersToTextFile _numbersToTextFile;

        [TestInitialize]
        public void Setup()
        {
            File.Delete(@"c:\dev\scratch\logs\logfile.txt");
            _container = new UnityContainer();
            _container.RegisterType<INumbersToTextFile, NumbersToTextFile>();
            _container.RegisterType<IDelayConfig, TestDelayConfig>();
            IoC.Initialize(_container);
        }

        [TestCleanup]
        public void CleanUp()
        {
            //File.Delete(@"c:\dev\scratch\logs\logfile.txt");
        }


        private void LogNumbers()
        {
            _numbersToTextFile = _container.Resolve<INumbersToTextFile>();
            _numbersToTextFile.MaxIntegerToWrite = 1000;
            _numbersToTextFile.WriteNumbersToFile();
        }

        [TestMethod]
        public void LogNumbersWithInstanceFileLogger()
        {
            _container.RegisterType<IFileLoggerFactory, InstanceFileLoggerFactory>();
            LogNumbers();
        }

        [TestMethod]
        public void LogNumbersWithSingletonFileLogger()
        {
            _container.RegisterType<IFileLoggerFactory, SingletonFileLoggerFactory>();
            LogNumbers();
        }

        [TestMethod]
        public void LogNumbersWithLockedSingletonFileLogger()
        {
            _container.RegisterType<IFileLoggerFactory, LockedSingletonFileLoggerFactory>();
            LogNumbers();
        }

        [TestMethod]
        public void LogNumbersWithDoubleCheckLockedSingletonFileLogger()
        {
            _container.RegisterType<IFileLoggerFactory, DoubleCheckLockedSingletonFileLoggerFactory>();
            LogNumbers();
        }

        [TestMethod]
        public void LogNumbersWithLazySingletonFileLogger()
        {
            _container.RegisterType<IFileLoggerFactory, LazySingletonFileLoggerFactory>();
            LogNumbers();
        }
    }
}