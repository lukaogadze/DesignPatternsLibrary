namespace LazyLoad.LazyInit
{
    public class OrderGood
    {
        // other properties

        private Customer _customer;
        public Customer Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new Customer(); // not thread-safe
                }
                return _customer;
            }
        }

        public string PrintLabel()
        {
            return Customer.CompanyName + "\n" + Customer.Address;
        }
    }
}