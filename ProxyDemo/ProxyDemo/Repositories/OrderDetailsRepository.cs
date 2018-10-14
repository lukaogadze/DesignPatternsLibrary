using System;
using ProxyDemo.Entities;

namespace ProxyDemo.Repositories
{
    public class OrderDetailsRepository : Repository<OrderDetailsEntity>
    {
        public override OrderDetailsEntity GetById(int id)
        {
            Console.WriteLine("--> Fetching Order Details Item " + id);
            return new OrderDetailsEntity()
                       {
                           Id = id,
                           Name = "Product " + id,
                           Price = id*1.23m
                       };
        }
    }
}