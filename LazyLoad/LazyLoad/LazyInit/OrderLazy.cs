using System;

namespace LazyLoad.LazyInit
{
    public class OrderLazy
    {
        public OrderLazy()
        {
            // Lazy<T> defaults to thread safe - set isThreadSafe to false if not needed
            _customerInitializer = new Lazy<Customer>(() => new Customer());
        }

        // other properties

        private Lazy<Customer> _customerInitializer;
        public Customer Customer => _customerInitializer.Value;

        public string PrintLabel()
        {
            string result = Customer.CompanyName; // ok to access Customer
            return result + "\n" + _customerInitializer.Value.Address; // ok to access via .Value
        }
    }
}
