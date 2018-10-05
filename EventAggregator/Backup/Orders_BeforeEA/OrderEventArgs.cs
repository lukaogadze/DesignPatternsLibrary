using System;

namespace Orders_BeforeEA
{
    public class OrderEventArgs : EventArgs
    {
        public Order Order { get; set; }
    }
}