using FileLoggerSample.Impl.FileLoggers;
using FileLoggerSample.Interfaces;

namespace FileLoggerSample.Impl.Factories
{
    public class LazySingletonFileLoggerFactory : IFileLoggerFactory
    {
        public IFileLogger Create()
        {
            return FileLoggerLazySingleton.Instance;
        }
    }
}