using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Observer;
using Observer.MotivatingExample;

namespace Observer.MotivatingExample
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Monitor a stock ticker, when particular events occur, react
			foreach (Stock s in SampleData.getNext())
			{
				// Reactive Filters
				if (s.Symbol == "GOOG")
					Console.WriteLine("Google's new price is: {0}", s.Price);

				if (s.Symbol == "MSFT" && s.Price > 10.00m)
					Console.WriteLine("Microsoft has reached the target price: {0}", s.Price);

				if (s.Symbol == "XOM")
					Console.WriteLine("Exxon mobile's price is {0}", s.Price);
			}
		}
	}
}
