using System;
using FileLoggerSample.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SingletonShould
    {
        [TestMethod]
        public void ReturnSameInstance()
        {
            Singleton firstInstance = Singleton.Instance;
            Singleton secondInstance = Singleton.Instance;

            Assert.AreSame(firstInstance, secondInstance);
        }
    }
}