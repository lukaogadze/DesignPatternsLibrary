using System;

namespace Automobiles.Autos
{
    public class MiniCooper : IAutomobile
    {
        public string Name
        {
            get { return "Mini Cooper"; }
        }

        public Guid Id
        {
            get { return new Guid("5E791286-902A-477A-86A4-B1424CCCB6B7"); }
        }

        public void Start()
        {
            Console.WriteLine("Mini Cooper started. 1.6L of raw power is ready to go.");
        }

        public void Stop()
        {
            Console.WriteLine("Mini Cooper stopped.");
        }
    }
}