using Factory2.Autos;

namespace Factory2
{
    /// <summary>
    /// simple factory
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string carName = args[0];

            AutoFactory factory = new AutoFactory();

            IAuto car = factory.CreateInstance(carName);

            car.TurnOn();
            car.TurnOff();
        }
    }
}
