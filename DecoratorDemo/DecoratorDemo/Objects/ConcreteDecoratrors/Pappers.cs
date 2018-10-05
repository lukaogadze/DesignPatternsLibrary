using DecoratorDemo.Objects.Decorator;
using DecoratorDemo.Objects.Component;

namespace DecoratorDemo.Objects.ConcreteDecoratrors
{
    public class Pappers : PizzaDecorator
    {
        public Pappers(Pizza pizza) : base(pizza)
        {
            Description = "Pappers";
        }

        public override string GetDescription()
        {
            return $"{Pizza.GetDescription()}, {Description}";
        }

        public override decimal CalculateCost()
        {
            return Pizza.CalculateCost() + 2.00m;
        }
    }
}
