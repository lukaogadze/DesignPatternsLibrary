using System;

namespace Pluralsight.Mediator
{
    public class Boeing737200 : Aircraft
    {
        public Boeing737200(string callSign) : base(callSign)
        {
        }

        public override int Ceiling
        {
            get { return 35000; }
        }

        public override bool IsTrailingGapAcceptable()
        {
            throw new NotImplementedException();
        }
    }
}