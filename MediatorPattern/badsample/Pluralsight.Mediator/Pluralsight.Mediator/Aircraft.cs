using System.Collections.Generic;

namespace Pluralsight.Mediator
{
    public abstract class Aircraft
    {
        private int _currentAltitude;
        protected IList<Aircraft> _acknowledgedAircraft = new List<Aircraft>();

        protected Aircraft(string callSign)
        {
            CallSign = callSign;
        }

        public void Acknowledges(Aircraft aircraft)
        {
            _acknowledgedAircraft.Add(aircraft);
        }

        public abstract int Ceiling { get; }

        public abstract bool IsTrailingGapAcceptable();

        public string CallSign { get; private set; }

        public int Altitude
        {
            get { return _currentAltitude; }
            set
            {
                _currentAltitude = value;
            }
        }

        public void Climb(int heightToClimb)
        {
            Altitude += heightToClimb;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            var incoming = (Aircraft) obj;
            return this.CallSign.Equals(incoming.CallSign);
        }
    }
}