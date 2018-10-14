using System;
using System.Collections.Generic;
using ProxyDemo.Entities;
using ProxyDemo.Repositories;

namespace ProxyDemo.Model
{
    public class Order
    {
        public Order()
        {
        }
        public Order(int id)
        {
            _id = id;
            GetEntity();
            this.OrderDate = this.OrderEntity.OrderDate;
            this.Customer = GetCustomer();
            this.Items = GetItems();
        }

        protected virtual void GetEntity()
        {
            this.OrderEntity = new OrderRepository().GetById(Id);
        }

        protected virtual Customer GetCustomer()
        {
            return new Customer(this.OrderEntity.CustomerId);
        }

        protected virtual List<OrderDetails> GetItems()
        {
            var items = new List<OrderDetails>();
            foreach (var orderDetailId in this.OrderEntity.OrderDetails)
            {
                items.Add(new OrderDetails(orderDetailId));
            }
            return items;
        }

        protected OrderEntity OrderEntity;
        public virtual DateTime OrderDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<OrderDetails> Items { get; set; }
        protected int _id;
        public int Id
        {
            get
            {
                return _id;
            }
        }
    }
}