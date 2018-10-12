namespace LazyLoad.VirtualProxy
{
    public class OrderProxy : Order
    {
        public override Customer Customer
        {
            get
            {
                if(base.Customer == null)
                {
                    base.Customer = new Customer();
                }
                return base.Customer;
            }
            set
            {
                base.Customer = value;
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Order;
            if (other == null) return false;
            return other.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}