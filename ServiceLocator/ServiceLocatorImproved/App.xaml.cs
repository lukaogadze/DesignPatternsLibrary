using System.Windows;

namespace ServiceLocatorImproved
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Start(object sender, StartupEventArgs e)
        {
            ServiceLocator.AddService(new LoggingClass());
        }
    }
}