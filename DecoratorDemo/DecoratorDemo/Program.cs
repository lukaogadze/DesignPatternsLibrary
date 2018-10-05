using DecoratorDemo.Objects.Component;
using DecoratorDemo.Objects.ConcreteComponent;
using DecoratorDemo.Objects.ConcreteDecoratrors;
using static System.Console;

namespace DecoratorDemo
{
    static class Program
    {
        static void Main()
        {
            Pizza largePizza = new LargePizza();
            largePizza = new Cheese(largePizza);
            largePizza = new Ham(largePizza);
            largePizza = new Pappers(largePizza);

            WriteLine(largePizza.GetDescription());
            WriteLine($"{largePizza.CalculateCost():C2}");
        }
    }
}
