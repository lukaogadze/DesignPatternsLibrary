using System.Collections.Generic;
using System.Diagnostics;

namespace LazyLoad.ValueHolder
{
    public class OrderItemLoader : IValueLoader<List<OrderItem>>
    {
        private readonly int _orderId;

        public OrderItemLoader(int orderId)
        {
            _orderId = orderId;
        }

        public List<OrderItem> Load()
        {
            // fetch items from database by _orderId
            Debug.Print("Fetching OrderItems from Database");
            return new List<OrderItem>();
        }
    }
}