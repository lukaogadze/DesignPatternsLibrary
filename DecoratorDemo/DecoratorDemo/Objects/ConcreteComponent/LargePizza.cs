using DecoratorDemo.Objects.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorDemo.Objects.ConcreteComponent
{
    public class LargePizza : Pizza
    {
        public LargePizza()
        {
            Description = "Large Pizza";
        }
        public override decimal CalculateCost()
        {
            return 9.00m;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }
}
