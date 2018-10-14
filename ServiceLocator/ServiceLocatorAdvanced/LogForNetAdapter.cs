namespace ServiceLocatorAdvanced
{
    public class LogForNetAdapter : ILog
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(typeof(LogForNetAdapter));
        
        public void Log(string text)
        {
            log.Info(text);
        }

        public void LogFormat(string text, params object[] parameters)
        {
            log.InfoFormat(text, parameters);
        }
    }
}