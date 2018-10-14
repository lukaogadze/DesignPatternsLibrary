using System;
using System.IO;
using System.Windows;

namespace ServiceLocatorDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBlock1.Text = string.Empty;
        }

        private StreamWriter _logFile;

        private void LogUserActions(string txt)
        {
            if (_logFile == null)
            {
                _logFile = new StreamWriter("actions.log");
            }
            _logFile.WriteLine(txt);
            _logFile.Flush();
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            var msg = "Button 1 Clicked";
            TextBlock1.Text += $"{msg}{Environment.NewLine}";
            LogUserActions(msg);
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            var msg = "Button 2 Clicked";
            TextBlock1.Text += $"{msg}{Environment.NewLine}";
            LogUserActions(msg);
        }
    }
}