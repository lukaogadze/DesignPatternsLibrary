using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Orders_BeforeEA
{
    public partial class MainPage : UserControl
    {
        public event EventHandler<OrderEventArgs> OrderCreated;
        public event EventHandler<OrderEventArgs> OrderSaved;
        
        private ObservableCollection<Order> _orders;

        public MainPage()
        {
            InitializeComponent();
            AddOrderViews();
            LoadOrders();

            this.New.Click += new RoutedEventHandler(New_Click);
            this.Save.Click += new RoutedEventHandler(Save_Click);
        }

        private void AddOrderViews()
        {
            var tabs = this.OrderViews.Items;
            tabs.Add(new TabItem() {Header = "Header", Content = new OrderView()});
            tabs.Add(new TabItem() {Header="Detail", Content=new OrderDetail()});
            tabs.Add(new TabItem() {Header = "Order History", Content = new OrderHistoryView()});
            
            foreach(TabItem tab in tabs)
            {
                var view = (IOrderView) tab.Content;
                OrderCreated += (s,e)=>view.OnOrderSelected(e.Order);
                OrderSaved += (s, e) => view.OnOrderSaved(e.Order);
                OrderListView.OrderSelected += (s, e) => view.OnOrderSelected(e.Order);
            }
        }

        private void LoadOrders()
        {
            _orders = new ObservableCollection<Order>();
            _orders.Add(new Order { OrderNumber = "1000", Description = "An Order" });
            _orders.Add(new Order { OrderNumber = "2000", Description = "Another Order" });
            _orders.Add(new Order { OrderNumber = "3000", Description = "Yet Another Order" });
            OrderListView.SetOrders(_orders);
        }

        void New_Click(object sender, RoutedEventArgs e)
        {
            var order = new Order { Description = "New Order", OrderNumber = "New " + Order.NewID };
            _orders.Add(order);

            var handler = OrderCreated;
            
            if (handler == null)
                return;

            OrderCreated(this, new OrderEventArgs { Order = order });
        }

        void Save_Click(object sender, RoutedEventArgs e)
        {
            var handler = OrderSaved;
            if (handler == null)
                return;
            
            var order = (Order) this.OrderListView.OrdersList.SelectedItem;

            OrderSaved(this, new OrderEventArgs {Order = order});

        }
    }
}
