using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer.IObserver
{
	class GoogleMonitor : IObserver<Stock>
	{
		public void OnCompleted()
		{
			Console.WriteLine("End of trading day");
		}

		public void OnError(Exception error)
		{
			Console.WriteLine("Error occured in the stock ticker");
		}

		public void OnNext(Stock value)
		{
			if (value.Symbol == "GOOG")
				Console.WriteLine("Google's new price is: {0}", value.Price);
		}
	}
}
