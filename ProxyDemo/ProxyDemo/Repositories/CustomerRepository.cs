using System;
using ProxyDemo.Entities;

namespace ProxyDemo.Repositories
{
    public class CustomerRepository : Repository<CustomerEntity>
    {
        public override CustomerEntity GetById(int id)
        {
            Console.WriteLine("--> Fetching Customer " + id);
            return new CustomerEntity()
                       {
                           Id = id,
                           Name = "Customer " + id
                       };
        }
    }
}