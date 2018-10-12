using System.Collections.Generic;
using System.Diagnostics;

namespace LazyLoad.Ghosts
{
    public class OrderItemRepository
    {
        public IEnumerable<OrderItem> ListForOrder(int orderId)
        {
            Debug.Print("Fetching order items from database");
            var items = new List<OrderItem>()
                            {
                                new OrderItem(),
                                new OrderItem(),
                                new OrderItem()
                            };
            return items;
        }
    }
}