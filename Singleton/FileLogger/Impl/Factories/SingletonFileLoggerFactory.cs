using FileLoggerSample.Impl.FileLoggers;
using FileLoggerSample.Interfaces;

namespace FileLoggerSample.Impl.Factories
{
    public class SingletonFileLoggerFactory : IFileLoggerFactory
    {
        public IFileLogger Create()
        {
            return FileLoggerSingleton.Instance;
        }
    }
}