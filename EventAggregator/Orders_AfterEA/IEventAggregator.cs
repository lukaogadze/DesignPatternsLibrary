using System;

namespace Orders_AfterEA
{
    public interface IEventAggregator
    {
        void Subscribe(object subscriber);
        void Publish<TEvent>(TEvent eventToPublish);
    }

    public class OrderCreated
    {
        public Order Order { get; set; }
    }

    public class OrderSelected
    {
        public Order Order { get; set; }
    }

    public class OrderSaved
    {
        public Order Order { get; set; }
    }
}