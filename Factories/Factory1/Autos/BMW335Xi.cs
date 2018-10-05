using System;

namespace Factory1.Autos
{
    public class BMW335Xi : IAuto
    {
        public string Name
        {
            get { return "BMW 335Xi"; }
        }

        public void TurnOn()
        {
            Console.WriteLine("The BMW 335Xi is on and running.");
        }

        public void TurnOff()
        {
            Console.WriteLine("The BMW 335Xi is off.");
        }
    }
}