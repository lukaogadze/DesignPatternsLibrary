using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer.Traditional
{
	public abstract class AbstractSubject
	{
		List<AbstractObserver> observers = new List<AbstractObserver>();

		public void Register(AbstractObserver observer)
		{
			observers.Add(observer);
		}

		public void Unregister(AbstractObserver observer)
		{
			observers.Remove(observer);
		}

		public void Notify()
		{
			foreach (var o in observers)
				o.Update();
		}
	}
}
