using System.Collections;
using System.Configuration;
using System.Reflection;

namespace ServiceLocatorAdvanced
{
    internal static class ServiceLocator
    {
        private static readonly Hashtable services = new Hashtable();

        public static void AddService<T>(T t)
        {
            services.Add(typeof (T).Name, t);
        }

        public static void AddService<T>(string name, T t)
        {
            services.Add(name, t);
        }

        public static T GetService<T>()
        {
            return (T) services[typeof (T).Name];
        }

        public static T GetService<T>(string serviceName)
        {
            return (T) services[serviceName];
        }

        public static void RegisterServiceFromAppSettings(string serviceName)
        {
            var loggerEntry = ConfigurationManager.AppSettings[serviceName];
            var loggingObject = Assembly.GetExecutingAssembly().CreateInstance(loggerEntry);
            ServiceLocator.AddService(serviceName, loggingObject);
        }
            
    }
}