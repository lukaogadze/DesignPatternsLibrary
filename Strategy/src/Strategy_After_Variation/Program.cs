using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strategy_After_Variation.Domain;

namespace Strategy_After_Variation
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Func<Order, double> fedExStrategy = CalcForFedEx;
            Func<Order, double> upsStrategy = delegate(Order order) { return 4.00d; };
            Func<Order, double> uspsStrategy = order => 3.25d;

            Order theOrder = Mother.CreateOrder();
            
            var calculatorService = new ShippingCostCalculatorService();
            Console.WriteLine("FedEx Shipping Cost: " + 
                calculatorService.CalculateShippingCost(theOrder, fedExStrategy));

            Console.WriteLine("UPS Shipping Cost: " +
                calculatorService.CalculateShippingCost(theOrder, upsStrategy));

            Console.WriteLine("USPS Shipping Cost: " +
                calculatorService.CalculateShippingCost(theOrder, uspsStrategy));
            
            Console.ReadKey();
        }

        internal static double CalcForFedEx(Order arg)
        {
            return 5.00d;
        }
    }
}
