using DecoratorDemo.Objects.Decorator;
using DecoratorDemo.Objects.Component;

namespace DecoratorDemo.Objects.ConcreteDecoratrors
{
    public class Ham : PizzaDecorator
    {
        public Ham(Pizza pizza) : base(pizza)
        {
            Description = "Ham";
        }

        public override string GetDescription()
        {
            return $"{Pizza.GetDescription()}, {Description}";
        }

        public override decimal CalculateCost()
        {
            return Pizza.CalculateCost() + 1.00m;
        }
    }
}
