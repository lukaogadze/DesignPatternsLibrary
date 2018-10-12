using System.Collections.Generic;

namespace LazyLoad.ValueHolder
{
    public class OrderVH
    {
        public int Id { get; set; }

        public OrderVH(int id)
        {
            Id = id;
        }

        private ValueHolder<List<OrderItem>> _items;

        public List<OrderItem> Items
        {
            get { return _items.Value; }
        }

        internal void SetItems(ValueHolder<List<OrderItem>> valueHolder)
        {
            _items = valueHolder;
        }
    }
}