using DecoratorDemo.Objects.Component;

namespace DecoratorDemo.Objects.Decorator
{
    public class PizzaDecorator : Pizza
    {
        protected Pizza Pizza { get; }

        public PizzaDecorator(Pizza pizza)
        {
            Pizza = pizza;
        }

        public override decimal CalculateCost()
        {
            return Pizza.CalculateCost();
        }

        public override string GetDescription()
        {
            return Pizza.Description;
        }
    }
}
