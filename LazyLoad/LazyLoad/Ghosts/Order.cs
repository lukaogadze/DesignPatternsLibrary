using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LazyLoad.Ghosts
{
    public class Order : DomainObject
    {
        public Order(int id)
            : base(id)
        {
        }

        private string _shipMethod;

        public string ShipMethod
        {
            get
            {
                Load();
                return _shipMethod;
            }
            set
            {
                Load();
                _shipMethod = value;
            }
        }

        private Customer _customer;

        public Customer Customer
        {
            get
            {
                Load();
                return _customer;
            }
            set
            {
                Load();
                _customer = value;
            }
        }

        private Lazy<List<OrderItem>> _items;

        public IEnumerable<OrderItem> Items
        {
            get
            {
                Load();
                return _items.Value.AsReadOnly();
            }
        }

        protected override void DoLoadLine(ArrayList dataRow)
        {
            ShipMethod = (string) dataRow[0];
            Customer = new Customer((int) dataRow[1]);
            _items = new Lazy<List<OrderItem>>(() => new OrderItemRepository().ListForOrder(Id).ToList());
        }

        // simulates fetching a DataRow via a DataReader
        protected override ArrayList GetDataRow()
        {
            var row = new ArrayList();
            row.Add("FEDEX"); // ship method
            row.Add(123); // customer id
            return row;
        }
    }
}