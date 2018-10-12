using System;
using System.Collections;
using NUnit.Framework;

namespace Iterator
{
    [TestFixture]
    public class IteratorSamples
    {
        [Test]
        public void ArrayIteration()
        {
            var stocks = new[] {"MSFT", "GOOG", "AAPL"};
            for (int i = 0; i < stocks.Length; i++)
            {
                Console.WriteLine(stocks[i]);
            }
        }

        [Test]
        public void Enumerator()
        {
            var stocks = new[] {"MSFT", "GOOG", "AAPL"};
            IEnumerator enumerator = stocks.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        [Test]
        public void Foreach()
        {
            var stocks = new[] {"MSFT", "GOOG", "AAPL"};
            foreach (string stock in stocks)
            {
                Console.WriteLine(stock);
            }
        }

        [Test]
        public void ListIteration()
        {
            var stocks = new SuperCollection {"MSFT", "GOOG", "AAPL"};
            for (int i = 0; i < stocks.Count; i++)
            {
                Console.WriteLine(stocks.Get(i));
            }
        }
    }
}