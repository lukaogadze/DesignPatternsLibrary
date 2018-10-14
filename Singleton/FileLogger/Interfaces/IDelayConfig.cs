using System;

namespace FileLoggerSample.Interfaces
{
    public interface IDelayConfig
    {
        int DelayMilliseconds { get; }
    }
}