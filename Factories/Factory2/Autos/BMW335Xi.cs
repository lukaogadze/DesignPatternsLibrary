using System;

namespace Factory2.Autos
{
    public class BMW335Xi : IAuto
    {
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