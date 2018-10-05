namespace Orders_AfterEA_WithPrism
{
    public class Order
    {
        private static int _newID = 1;
        public static int NewID { get { return _newID; } }

        public Order()
        {
            OrderID = _newID++;
        }

        public int OrderID { get; private set; }
        public string OrderNumber { get; set; }
        public string Description { get; set; }
    }
}