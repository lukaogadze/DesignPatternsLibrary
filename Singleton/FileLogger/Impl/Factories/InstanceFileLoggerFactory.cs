using FileLoggerSample.Impl.FileLoggers;
using FileLoggerSample.Interfaces;

namespace FileLoggerSample.Impl.Factories
{
    public class InstanceFileLoggerFactory : IFileLoggerFactory
    {
        public IFileLogger Create()
        {
            return new FileLogger();
        }
    }
}