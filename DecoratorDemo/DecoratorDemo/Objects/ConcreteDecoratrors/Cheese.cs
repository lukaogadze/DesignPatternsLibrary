using DecoratorDemo.Objects.Decorator;
using DecoratorDemo.Objects.Component;

namespace DecoratorDemo.Objects.ConcreteDecoratrors
{
    public class Cheese : PizzaDecorator
    {
        public Cheese(Pizza pizza) : base(pizza)
        {
            Description = "Cheese";
        }

        public override string GetDescription()
        {
            return $"{Pizza.GetDescription()}, {Description}";
        }

        public override decimal CalculateCost()
        {
            return Pizza.CalculateCost() + 1.25m;
        }
    }
}
