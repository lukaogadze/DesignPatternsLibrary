using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer.Traditional
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Monitor a stock ticker, when particular events occur, react
			StockTicker subj = new StockTicker();

			// Create New observers to listen to the stock ticker
			GoogleObserver gobs = new GoogleObserver(subj);
			MicrosoftObserver mobs = new MicrosoftObserver(subj);

			// Load the Sample Stock Data
			foreach (var s in SampleData.getNext())
				subj.Stock = s;
		}

	}
}
