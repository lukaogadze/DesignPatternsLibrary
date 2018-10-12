using System;

namespace Pluralsight.Mediator
{
    public class Embraer190 : Aircraft
    {
        public Embraer190(string callSign) : base(callSign)
        {
        }

        public override int Ceiling
        {
            get { return 41000; }
        }

        public override bool IsTrailingGapAcceptable()
        {
            throw new NotImplementedException();
        }
    }
}