using Automobiles.Autos;

namespace Automobiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var autoRepository = new AutoRepository();
            
            AutomobileBase automobile = autoRepository.Find("bmw");

            if (automobile == AutomobileBase.NULL)
                return;

            automobile.Start();
            automobile.Stop();
        }
    }
}