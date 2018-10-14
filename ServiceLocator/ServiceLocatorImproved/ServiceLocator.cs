using System.Collections;

namespace ServiceLocatorImproved
{
    internal class ServiceLocator
    {
        private static readonly Hashtable _services = new Hashtable();

        public static void AddService<T>(T t) where T : class
        {
            _services.Add(typeof(T).Name, t);
        }
        
        public static void AddService<T>(string name, T t) where T : class
        {
            _services.Add(name, t);
        }

        public static T GetService<T>() where T : class
        {
            return (T) _services[typeof(T).Name];
        }
        
        public static object GetService<T>(string serviceName) where T : class
        {
            return (T)_services[serviceName];
        }
            
    }
}