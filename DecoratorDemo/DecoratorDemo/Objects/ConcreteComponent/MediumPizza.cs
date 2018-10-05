using DecoratorDemo.Objects.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorDemo.Objects.ConcreteComponent
{
    public class MediumPizza : Pizza
    {
        public MediumPizza()
        {
            Description = "Medium Pizza";
        }
        public override decimal CalculateCost()
        {
            return 6.00m;
        }

        public override string GetDescription()
        {
            return Description;
        }
    }
}
