using System;
using NUnit.Framework;

namespace LazyLoad.LazyInit
{
    [TestFixture]
    public class OrderShould
    {
        [Test]
        public void PrintLabelWithGoodOrder()
        {
            var order = new OrderGood();

            var result = order.PrintLabel();

            Assert.AreEqual("Company Name\nDefault Address", result);
        }

        [Test]
        public void PrintLabelWithBadOrder()
        {
            var order = new OrderBad();

            // var result = order.PrintLabel();

            // Assert.AreEqual("Company Name\nDefault Address", result);

            Assert.Throws<NullReferenceException>(() => order.PrintLabel());
        }

        [Test]
        public void PrintLabelWithLazyOrder()
        {
            var order = new OrderLazy();

            var result = order.PrintLabel();

            Assert.AreEqual("Company Name\nDefault Address", result);
        }
    }
}