using System;

namespace WcfServiceLibrary1
{
    public class OrderService : IOrderService
    {
        public OrderDTO GetDataUsingDataContract(int orderId)
        {
            return new OrderDTO
                       {
                           Id = orderId,
                           CustomerId = 123,
                           OrderDate = DateTime.Now,
                           OrderItems = new[] {1, 2, 3, 4, 5}
                       };
        }
    }
}