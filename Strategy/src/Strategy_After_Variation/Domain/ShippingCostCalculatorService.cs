

using System;

namespace Strategy_After_Variation.Domain
{
    public class ShippingCostCalculatorService
    {
        public double CalculateShippingCost(Order order, Func<Order, double> shippingCostStrategy)
        {
           return shippingCostStrategy(order);
        }
    }
}
