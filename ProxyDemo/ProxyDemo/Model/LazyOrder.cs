using System;
using System.Collections.Generic;

namespace ProxyDemo.Model
{
    public class LazyOrder : Order
    {
        private readonly Lazy<Customer> _customer;
        private readonly Lazy<List<OrderDetails>> _items;

        public LazyOrder(int id)
        {
            _id = id;
            GetEntity();
            OrderDate = OrderEntity.OrderDate;
            //_customer = new Lazy<Customer>(GetCustomer);
            _customer = new Lazy<Customer>(() => new Customer(this.OrderEntity.CustomerId));
            _items = new Lazy<List<OrderDetails>>(GetItems);
        }

        public override Customer Customer
        {
            get { return _customer.Value; }
        }

        public override List<OrderDetails> Items
        {
            get { return _items.Value; }
        }
    }
}