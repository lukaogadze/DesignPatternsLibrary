using System.Diagnostics;

namespace LazyLoad
{
    public class Customer
    {
        public Customer()
        {
            Debug.Print("Initializing Customer");
            CompanyName = "Company Name";
            Address = "Default Address";
        }
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}