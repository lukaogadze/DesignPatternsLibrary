namespace Pluralsight.Mediator
{
    public class Airbus321 : Aircraft
    {
        public Airbus321(string callSign, IAirTrafficControl atc) : base(callSign, atc)
        {
        }

        public override int Ceiling
        {
            get { return 41000; }
        }
    }
}