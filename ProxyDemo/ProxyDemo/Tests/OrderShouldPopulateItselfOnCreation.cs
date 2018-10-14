using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProxyDemo.Model;

namespace ProxyDemo.Tests
{
    [TestClass]
    public class OrderShould
    {
        [TestMethod]
        public void PopulateItselfFullyOnCreation()
        {
            var myOrder = new Order(1);
            ConsoleReporting.PrintOrderDetails(myOrder);
        }
    }

    [TestClass]
    public class OrderProxyShould
    {
        [TestMethod]
        public void DeferObjectCreationUntilAccess()
        {
            var myOrder = new OrderProxy(1);
            ConsoleReporting.PrintOrderDetails(myOrder);

            Console.WriteLine("Again: " + myOrder.Customer.Name);
            foreach (var item in myOrder.Items)
            {
                Console.WriteLine("Item: " + item.Name);
            }
        }
    }

    [TestClass]
    public class LazyOrderShould
    {
        [TestMethod]
        public void DeferObjectCreationUntilAccess()
        {
            var myOrder = new LazyOrder(1);
            ConsoleReporting.PrintOrderDetails(myOrder);
        }
    }
}