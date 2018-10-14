using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LazySingletonShould
    {
        [TestMethod]
        public void ReturnSameInstance()
        {
            LazySingleton firstInstance = LazySingleton.Instance;
            LazySingleton secondInstance = LazySingleton.Instance;

            Assert.AreSame(firstInstance, secondInstance);
        }
    }
}