using FileLoggerSample.Impl.FileLoggers;
using FileLoggerSample.Interfaces;

namespace FileLoggerSample.Impl.Factories
{
    public class DoubleCheckLockedSingletonFileLoggerFactory : IFileLoggerFactory
    {
        public IFileLogger Create()
        {
            return FileLoggerDoubleCheckLocking.Instance;
        }
    }
}