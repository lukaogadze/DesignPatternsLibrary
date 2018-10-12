using System.Collections.Generic;

namespace LazyLoad.ValueHolder
{
    public class OrderFactory
    {
        public OrderVH CreateFromId(int id)
        {
            var order = new OrderVH(id);
            order.SetItems(new ValueHolder<List<OrderItem>>(new OrderItemLoader(id)));
            return order;
        }
    }
}