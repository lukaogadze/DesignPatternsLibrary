using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyDemo.Model;

namespace ProxyDemo.Tests
{
    [TestClass]
    public class OrderFromServiceShould
    {
        [TestMethod]
        public void LoadDetailsFromWcf()
        {
            var myOrder = new RemoteOrder(1);
            ConsoleReporting.PrintOrderDetails(myOrder);
        }
    }
}