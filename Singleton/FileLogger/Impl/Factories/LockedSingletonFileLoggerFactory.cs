using FileLoggerSample.Impl.FileLoggers;
using FileLoggerSample.Interfaces;

namespace FileLoggerSample.Impl.Factories
{
    public class LockedSingletonFileLoggerFactory : IFileLoggerFactory
    {
        public IFileLogger Create()
        {
            return FileLoggerThreadSafeSingleton.Instance;
        }
    }
}