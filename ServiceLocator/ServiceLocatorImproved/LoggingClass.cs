using System.IO;

namespace ServiceLocatorImproved
{
    public class LoggingClass
    {
        public void Log(string txt)
        {
            InternalLog(txt);
        }
        
        public void LogFormat(string txt, params object[] p)
        {
            string msg = string.Format(txt, p);
            InternalLog(msg);
        }
        
        

        private StreamWriter _writer;
        private void InternalLog(string txt)
        {
            if (_writer == null)
            {
                _writer = new StreamWriter("actions.log");
            }
            _writer.WriteLine(txt);
            _writer.Flush();
        }        
    }
}