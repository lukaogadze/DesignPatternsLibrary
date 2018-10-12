using NUnit.Framework;

namespace LazyLoad.VirtualProxy
{
    [TestFixture]
    public class OrderShould
    {
        [Test]
        public void PrintLabelWithOrderProxy()
        {
            int testOrderId = 123;
            var order = new OrderFactory().CreateFromId(testOrderId);

            Assert.AreEqual(testOrderId, order.Id); // should not have constructed Customer at this point

            string result = order.PrintLabel();

            Assert.AreEqual("Company Name\nDefault Address", result);
        }
    }
}