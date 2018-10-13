using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Observer.IObserver;

namespace Observer.IObserver
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Monitor a stock ticker, when particular events occur, react
			StockTicker st = new StockTicker();

			GoogleMonitor gf = new GoogleMonitor();
			MicrosoftMonitor mf = new MicrosoftMonitor();

			using (st.Subscribe(gf))
			using (st.Subscribe(mf))
			{
				// Load the Sample Stock Data
				foreach (var s in SampleData.getNext())
					st.Stock = s;
			}

		}
	}
}
