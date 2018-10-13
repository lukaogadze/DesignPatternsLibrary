using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer.IObserver
{
	class StockTicker : IObservable<Stock>
	{
		List<IObserver<Stock>> observers = new List<IObserver<Stock>>();

		private Stock stock;
		public Stock Stock
		{
			get { return stock; }
			set
			{
				stock = value;
				this.Notify(this.stock);
			}
		}

		private void Notify(Stock s)
		{
			foreach (var o in observers)
			{
				if (s.Symbol == null || s.Price < 0)
					o.OnError(new Exception("Bad Stock Data"));
				else
					o.OnNext(s);
			}
		}
		private void Stop()
		{
			foreach (var observer in observers.ToArray())
				if (observers.Contains(observer))
					observer.OnCompleted();
			observers.Clear();
		}

		public IDisposable Subscribe(IObserver<Stock> observer)
		{
			if (!observers.Contains(observer))
				observers.Add(observer);
			return new Unsubscriber(observers, observer);
		}

		private class Unsubscriber : IDisposable
		{
			private List<IObserver<Stock>> _observers;
			private IObserver<Stock> _observer;

			public Unsubscriber(List<IObserver<Stock>> observers, IObserver<Stock> observer)
			{
				this._observers = observers;
				this._observer = observer;
			}

			public void Dispose()
			{
				if (_observer != null && _observers.Contains(_observer))
					_observers.Remove(_observer);
			}
		}
	}
}
