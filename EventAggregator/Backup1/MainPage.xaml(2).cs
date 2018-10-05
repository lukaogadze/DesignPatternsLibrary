using System;
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
    public partial class MainPage : UserControl
    {
        private IMessenger _messenger;

        public MainPage()
        {
            InitializeComponent();
            this.New.Click += new RoutedEventHandler(New_Click);
            this.Save.Click += new RoutedEventHandler(Save_Click);

            var orders = new ObservableCollection<Order>();
            orders.Add(new Order {OrderNumber = "1000", Description="An Order"});
            orders.Add(new Order {OrderNumber = "2000", Description="Another Order"});
            orders.Add(new Order { OrderNumber = "3000", Description = "Yet Another Order" });
            this.OrderListView.OrdersList.ItemsSource = orders;

            _messenger = new Messenger();
            this.OrderListView.Messenger = _messenger;

            var views = new List<TabItem>();
            views.Add(new TabItem() {Header = "Header", Content = new OrderView(_messenger)});
            views.Add(new TabItem() {Header="Detail", Content=new OrderDetail(_messenger)});
            views.Add(new TabItem() {Header = "Order History", Content = new OrderHistoryView(_messenger)});
            this.OrderViews.ItemsSource = views;
            
            this.OrderListView.OrdersList.SelectedIndex = 0;
            
        }

        void New_Click(object sender, RoutedEventArgs e)
        {
        var order = new Order { Description = "New Order", OrderNumber = "New " + Order.NewID };
            var list = (ObservableCollection<Order>)this.OrderListView.OrdersList.ItemsSource;
            list.Add(order);
            this.OrderListView.OrdersList.SelectedItem = order;
            _messenger.Send<OrderCreated>(new OrderCreated {Order = order});
        }

        void Save_Click(object sender, RoutedEventArgs e)
        {
            var order = (Order)this.OrderListView.OrdersList.SelectedItem;
            _messenger.Send<OrderSaved>(new OrderSaved { Order = order });

        }
    }
}
