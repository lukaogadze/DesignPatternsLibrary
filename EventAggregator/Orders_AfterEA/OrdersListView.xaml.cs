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

namespace Orders_AfterEA
{
    using System.Collections.Specialized;

    public partial class OrdersListView : UserControl
    {
        public IEventAggregator EventAggregator { get; set; }

        public OrdersListView()
        {
            InitializeComponent();
            OrdersList.SelectionChanged += this.OrdersList_SelectionChanged;
        }

        void OrdersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var order = (Order) OrdersList.SelectedItem;                        
            EventAggregator.Publish(new OrderSelected{Order = order});
        }

        public void SetOrders(ObservableCollection<Order> orders)
        {
            OrdersList.ItemsSource = orders;
            OrdersList.SelectedIndex = 0;
            orders.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(orders_CollectionChanged);
        }

        void orders_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                OrdersList.SelectedItem = e.NewItems[0];
            }
        }

    }
}
