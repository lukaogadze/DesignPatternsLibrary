using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer.EventAndDelegate
{
	class StockTicker
	{
		private Stock stock;
		public Stock Stock
		{
			get { return stock; }
			set
			{
				stock = value;
                OnStockChange(new StockChangeEventArgs(this.stock));
			}
		}

		public event EventHandler<StockChangeEventArgs> StockChange;

		protected virtual void OnStockChange(StockChangeEventArgs e)
		{
            StockChange?.Invoke(this, e);
        }
	}
}
