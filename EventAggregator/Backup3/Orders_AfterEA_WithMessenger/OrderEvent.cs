using System;

namespace Orders_AfterEA_WithMessenger
{
    public class OrderEvent
    {
        public Order Order { get; set; }
    }

    public class OrderSelected : OrderEvent {}
    public class OrderCreated : OrderEvent {}
    public class OrderSaved : OrderEvent{}
}