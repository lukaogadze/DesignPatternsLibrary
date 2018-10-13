using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Stack<IMomento> _states = new Stack<IMomento>();

        public MainWindow()
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Undo, OnExecutedCommands));

            InkCanvasWithUndo1.MouseUp += InkCanvasWithUndo1_MouseUp;

            // initialize with empty state
            StoreState();
        }

        private void InkCanvasWithUndo1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StoreState();
        }

        private void OnExecutedCommands(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)sender;
            if (e.Command == ApplicationCommands.Undo)
            {
                mainWindow.Undo(sender, e);
            }
        }

        private void Undo(object sender, ExecutedRoutedEventArgs e)
        {
            if (_states.Count > 1)
            {
                // discard current state
                _states.Pop();
                var lastState = _states.Peek();
                InkCanvasWithUndo1.SetMomento(lastState);
            }
            label1.Content = _states.Count;
        }

        private void StoreState()
        {
            // Save state to momento
            var momento = InkCanvasWithUndo1.CreateMomento();
            _states.Push(momento);
            label1.Content = _states.Count;
        }


    }
}
