using System;

namespace Factory4.Autos.BMW
{
    public abstract class BMWBase : IAutomobile
    {
        public abstract string Name { get; }

        public void TurnOn()
        {
            Console.WriteLine("The " + Name + " is on and running.");
        }

        public void TurnOff()
        {
            Console.WriteLine("The " + Name + " is off.");
        }

    }
}