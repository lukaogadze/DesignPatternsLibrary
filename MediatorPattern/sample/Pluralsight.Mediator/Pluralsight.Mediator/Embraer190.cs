namespace Pluralsight.Mediator
{
    public class Embraer190 : Aircraft
    {
        public Embraer190(string callSign, IAirTrafficControl atc) : base(callSign, atc)
        {
        }

        public override int Ceiling
        {
            get { return 41000; }
        }
    }
}