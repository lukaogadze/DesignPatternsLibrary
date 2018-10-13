using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer.EventAndDelegate
{
	class GoogleMonitor
	{
		public GoogleMonitor(StockTicker st)
		{
			st.StockChange += new EventHandler<StockChangeEventArgs>(st_StockChange);
		}

		void st_StockChange(object sender, StockChangeEventArgs e)
		{
			CheckFilter(e.Stock);
		}

		private void CheckFilter(Stock value)
		{
			if (value.Symbol == "GOOG")
				Console.WriteLine("Google's new price is: {0}", value.Price);
		}
	}
}
