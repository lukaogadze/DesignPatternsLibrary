using System;
using Orders_AfterEA;

namespace Orders_AfterEA
{
    public class OrderEventArgs : EventArgs
    {
        public Order Order { get; set; }
    }
}