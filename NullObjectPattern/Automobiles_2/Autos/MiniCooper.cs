using System;

namespace Automobiles.Autos
{
    public class MiniCooper : AutomobileBase
    {
        public override Guid Id
        {
            get { return Guid.NewGuid(); }
        }

        public override string Name
        {
            get { return "Mini Cooper S"; }
        }

        public override void Start()
        {
            Console.WriteLine("Mini Cooper started. 1.6L of raw power is ready to go.");
        }

        public override void Stop()
        {
            Console.WriteLine("Mini Cooper stopped.");
        }
    }
}