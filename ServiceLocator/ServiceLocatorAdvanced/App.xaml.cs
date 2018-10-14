using System.Windows;
using log4net.Config;

namespace ServiceLocatorAdvanced
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            XmlConfigurator.Configure();
            
            //ServiceLocator.AddService<ILog>("logger", new LoggingClass());
            ServiceLocator.RegisterServiceFromAppSettings("logger");
        }
    }
}