using FileLoggerSample.Interfaces;

namespace FileLoggerSample.Impl
{
    public class DefaultDelayConfig : IDelayConfig
    {
        private int _delayMilliseconds = 50;
        public int DelayMilliseconds
        {
            get { return _delayMilliseconds; }
            set { _delayMilliseconds = value; }
        }
    }
}