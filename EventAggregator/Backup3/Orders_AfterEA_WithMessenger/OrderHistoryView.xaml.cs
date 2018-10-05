using System;
using System.Collections.Generic;
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
    public partial class OrderHistoryView : UserControl
    {
        public OrderHistoryView(IMessenger messenger)
        {
            InitializeComponent();
            messenger.Register<OrderSelected>(this, m => OnOrderSelected(m.Order));
            messenger.Register<OrderCreated>(this, m => OnOrderSelected(m.Order));
            messenger.Register<OrderSaved>(this, m => OnOrderSaved(m.Order));
        }

        public void OnOrderSelected(Order o)
        {
            this.Label.Text = string.Format("Order History: {0}", o.OrderNumber);
        }

        public void OnOrderSaved(Order o)
        {
            this.Label.Text = string.Format("Order Saved: {0}", o.OrderNumber);
        }
    }
}
