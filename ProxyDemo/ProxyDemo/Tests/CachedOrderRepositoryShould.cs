using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyDemo.Repositories;

namespace ProxyDemo.Tests
{
    [TestClass]
    public class CachedOrderRepositoryShould
    {
        [TestMethod]
        public void LoadOrderFromSourceOnlyOnce()
        {
            var orderEntity1 = new CachedOrderRepository().GetById(1);
            var orderEntity2 = new CachedOrderRepository().GetById(1);
            var orderEntity3 = new CachedOrderRepository().GetById(1);
        }
    }
}