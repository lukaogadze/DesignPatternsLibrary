using FileLoggerSample.Interfaces;

namespace Tests
{
    public class TestDelayConfig : IDelayConfig
    {
        public int DelayMilliseconds
        {
            get { return 5; }
        }
    }
}