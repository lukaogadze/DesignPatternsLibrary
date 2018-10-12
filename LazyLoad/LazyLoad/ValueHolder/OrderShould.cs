using LazyLoad.LazyInit;
using NUnit.Framework;

namespace LazyLoad.ValueHolder
{
    [TestFixture]
    public class OrderShould
    {
        [Test]
        public void NotLoadItemsUntilReferenced()
        {
            int orderId = 123;
            var order = new OrderFactory().CreateFromId(orderId);

            Assert.AreEqual(orderId, order.Id);

            // should trigger DB call
            var items = order.Items;

            Assert.AreEqual(0, items.Count);
        }
    }
}