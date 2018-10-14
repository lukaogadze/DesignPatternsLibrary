namespace ServiceLocatorAdvanced
{
    public interface ILog
    {
        void Log(string text);
        void LogFormat(string text, params object[] parameters);
    }
}