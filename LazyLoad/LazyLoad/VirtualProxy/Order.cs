namespace LazyLoad.VirtualProxy
{
    public class Order
    {
        // other properties
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public string PrintLabel()
        {
            return Customer.CompanyName + "\n" + Customer.Address;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}