using DecoratorDemo.Objects.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorDemo.Objects.ConcreteComponent
{
    public class SmallPizza : Pizza
    {
        public SmallPizza()
        {
            Description = "Small Pizza";
        }
        public override decimal CalculateCost()
        {
            return 3.00m;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }
}
