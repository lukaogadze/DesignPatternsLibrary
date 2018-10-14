using System;
using System.Windows;

namespace ServiceLocatorImproved
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private LoggingClass log = ServiceLocator.GetService<LoggingClass>();
        public MainWindow()
        {
            InitializeComponent();
            TextBlock1.Text = string.Empty;
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            var msg = "Button 1 Clicked";
            TextBlock1.Text += $"{msg}{Environment.NewLine}";
            log.Log(msg);
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            var msg = "Button 2 Clicked";
            TextBlock1.Text += $"{msg}{Environment.NewLine}";
            log.Log(msg);
        }
    }
}