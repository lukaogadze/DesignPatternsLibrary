using System;

namespace ProxyDemo.Entities
{
    [Serializable]
    public class OrderEntity
    {
        public int Id;
        public int CustomerId;
        public int[] OrderDetails;
        public DateTime OrderDate;
    }
}