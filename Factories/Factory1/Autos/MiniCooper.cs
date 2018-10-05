using System;

namespace Factory1.Autos
{
    public class MiniCooper : IAuto
    {
        public string Name
        {
            get { return "Mini Cooper"; }
        }

        public void TurnOn()
        {
            Console.WriteLine("The Mini Cooper is on! 1.6 Liters of brutal force is churning.");
        }

        public void TurnOff()
        {
            Console.WriteLine("The Mini Cooper is has turned off.");
        }
    }
}