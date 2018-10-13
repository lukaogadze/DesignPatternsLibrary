namespace PS.Auto.Domain.ValueObjects
{
    public class PerformanceStats
    {
        public PerformanceStats()
        {}

        public PerformanceStats(int topSpeed, double zeroToSixty, double quarterMile)
        {
            TopSpeed = topSpeed;
            ZeroToSixty = zeroToSixty;
            QuarterMile = quarterMile;
        }

        public int TopSpeed { get; private set;  }
        public double ZeroToSixty { get; private set; }
        public double QuarterMile { get; private set; }
    }
}