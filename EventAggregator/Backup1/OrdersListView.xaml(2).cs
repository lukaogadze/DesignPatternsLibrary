using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;

namespace Orders_AfterEA_WithMessenger
{
    public partial class OrdersListView : UserControl
    {
        public IMessenger Messenger { get; set; }

        public OrdersListView()
        {
            InitializeComponent();
            OrdersList.SelectionChanged += new SelectionChangedEventHandler(OrdersList_SelectionChanged);
        }

        void OrdersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var order = (Order) OrdersList.SelectedItem;                        
            Messenger.Send(new OrderSelected {Order = order});
        }

    }
}
