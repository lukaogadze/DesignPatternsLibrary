using System;

namespace Automobiles.Autos
{
    public class BMW335XI : IAutomobile
    {
        public string Name
        {
            get { return "BMW 335 Xi"; }
        }

        public Guid Id
        {
            get { return new Guid("68BECCDC-0FBD-4FB9-B0BB-D5D8A2AFD9F8"); }
        }

        public void Start()
        {
            Console.WriteLine("Beemer started. All 4 wheels under power.");
        }

        public void Stop()
        {
            Console.WriteLine("Beemer stopped.");
        }
    }
}