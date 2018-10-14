using System.Collections.Generic;
using ProxyDemo.Entities;
using ProxyDemo.Repositories;

namespace ProxyDemo.Model
{
    public class Customer
    {
        private readonly int _id;

        public Customer()
        {
            
        }
        public Customer(int id)
        {
            _id = id;
            CustomerEntity customerEntity = new CustomerRepository().GetById(id);
            this.Name = customerEntity.Name;
        }

        public string Name { get; set;}
        public List<Order> Orders { get; set; }
    }
}