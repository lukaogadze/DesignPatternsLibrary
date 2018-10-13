using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer.Traditional
{
	public class MicrosoftObserver : AbstractObserver
	{
		private StockTicker DataSource { get; set; }

		public MicrosoftObserver(StockTicker subj)
		{
			this.DataSource = subj;
			subj.Register(this);
		}

		public override void Update()
		{
			decimal price = DataSource.Stock.Price;
			string symbol = DataSource.Stock.Symbol;

			// Reactive Filters
			if (symbol == "MSFT" && price > 10.00m)
				Console.WriteLine("Microsoft has reached the target price: {0}", price);
		}
	}
}
