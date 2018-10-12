namespace Pluralsight.Mediator
{
    public class Airbus321 : Aircraft
    {
        public Airbus321(string callSign) : base(callSign)
        {
        }

        public override int Ceiling
        {
            get { return 41000; }
        }

        public override bool IsTrailingGapAcceptable()
        {
            foreach (var acknowledgedAircraft in _acknowledgedAircraft)
            {
                if (acknowledgedAircraft.GetType() == typeof (Boeing737200))
                {
                    //logic to calculate distance between planes    
                }
                if (acknowledgedAircraft.GetType() == typeof (Embraer190))
                {
                    //logic to calculate distance between planes
                }
            }
            return false;
        }
    }
}