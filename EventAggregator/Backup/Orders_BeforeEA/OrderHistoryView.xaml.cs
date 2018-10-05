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

namespace Orders_BeforeEA
{
    public partial class OrderHistoryView : UserControl, IOrderView
    {
        public OrderHistoryView()
        {
            InitializeComponent();
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
